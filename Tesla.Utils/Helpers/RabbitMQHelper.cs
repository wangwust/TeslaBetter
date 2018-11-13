using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Text.RegularExpressions;

namespace Tesla.Utils
{
    /// <summary>
    /// RabbitMQHelper
    /// </summary>
    public class RabbitMQHelper
    {
        private static ConnectionFactory _connectionFactory = null;

        /// <summary>
        /// 构造函数
        /// </summary>
        static RabbitMQHelper()
        {
            string connectString = ConfigurationManager.AppSettings["RabbitMQ"] ?? "";
            Regex regex = new Regex(@"host=(?<host>[^;]*);port=(?<port>[^;]*);virtualhost=(?<virtualhost>[^;]*);username=(?<username>[^;]*);password=(?<password>[^;]*)", RegexOptions.IgnoreCase);
            Match match = regex.Match(connectString);
            if (!match.Success)
            {
                throw new Exception("RabbitMQ配置错误，请检查配置文件！");
            }

            _connectionFactory = new ConnectionFactory();
            _connectionFactory.HostName = match.Groups["host"].Value;
            _connectionFactory.Port = Convert.ToInt32(match.Groups["port"].Value);
            _connectionFactory.UserName = match.Groups["username"].Value;
            _connectionFactory.Password = match.Groups["password"].Value;
            _connectionFactory.VirtualHost = match.Groups["virtualhost"].Value;

            _connectionFactory.AutomaticRecoveryEnabled = true;
        }

        #region 单消息入队
        /// <summary>
        /// 单消息入队
        /// </summary>
        /// <param name="exchangeName">交换器名称</param>
        /// <param name="exchangeType">交换器类型</param>
        /// <param name="routingKey">路由关键字</param>
        /// <param name="message">消息实例</param>
        /// <param name="properties">消息头</param>
        public static void Publish<T>(string exchangeName, string exchangeType, string routingKey, T message, IBasicProperties properties = null)
        {
            if (message == null)
            {
                throw new NullReferenceException("实体不能NULL");
            }

            try
            {
                using (IConnection connection = _connectionFactory.CreateConnection())
                {
                    using (IModel channel = connection.CreateModel())
                    {
                        channel.ExchangeDeclare(exchangeName, exchangeType, true);
                        string messageString = message.ToJson();
                        byte[] body = Encoding.UTF8.GetBytes(messageString);

                        if (properties == null)
                        {
                            properties = channel.CreateBasicProperties();
                        }

                        properties.Persistent = true; //使消息持久化
                        channel.BasicPublish(exchangeName, routingKey, properties, body);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region 消息批量入队
        /// <summary>
        /// 消息批量入队
        /// </summary>
        /// <param name="exchangeName">交换器名称</param>
        /// <param name="exchangeType">交换器类型</param>
        /// <param name="routingKey">路由关键字</param>
        /// <param name="list">消息集合</param>
        public static void Publish<T>(string exchangeName, string exchangeType, string routingKey, List<T> list)
        {
            if (list == null || list.Count == 0)
            {
                throw new NullReferenceException("实体不能NULL");
            }

            try
            {
                using (IConnection connection = _connectionFactory.CreateConnection())
                {
                    using (IModel channel = connection.CreateModel())
                    {
                        foreach (T item in list)
                        {
                            if (item != null)
                            {
                                channel.ExchangeDeclare(exchangeName, exchangeType, true, false, null);
                                string messageString = item.ToJson();
                                byte[] body = Encoding.UTF8.GetBytes(messageString);
                                var properties = channel.CreateBasicProperties();//使消息持久化
                                properties.Persistent = true;
                                channel.BasicPublish(exchangeName, routingKey, properties, body);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        /// <summary>
        /// 消费消息队列
        /// </summary>
        /// <typeparam name="T">消息对象</typeparam>
        /// <param name="exchangeName">交换器名称</param>
        /// <param name="exchangeType">交换器类型</param>
        /// <param name="routingKey">路由关键字</param>
        /// <param name="queueName">队列名称</param>
        /// <param name="func">消费消息的具体操作</param>
        /// <param name="tryTimes">消费失败后，继续尝试消费的次数</param>
        public static void Receive<T>(string exchangeName, string exchangeType, string routingKey, string queueName, Func<T, bool> func, int tryTimes = 5)
        {
            using (IConnection connection = _connectionFactory.CreateConnection())
            {
                using (IModel channel = connection.CreateModel())
                {
                    channel.ExchangeDeclare(exchangeName, exchangeType, true, false, null);
                    channel.QueueDeclare(queueName, true, false, false, null);
                    channel.QueueBind(queueName, exchangeName, routingKey);
                    QueueingBasicConsumer consumer = new QueueingBasicConsumer(channel);
                    channel.BasicConsume(queueName, false, consumer);
                    while (true)
                    {
                        try
                        {
                            int consumeCount = 0;//尝试消费次数
                            bool isConsumeSuccess = false;// 是否消费成功

                            var ea = (BasicDeliverEventArgs)consumer.Queue.Dequeue();
                            var body = ea.Body;
                            if (body == null)
                            {
                                channel.BasicAck(ea.DeliveryTag, false);
                                continue;
                            }

                            var message = Encoding.UTF8.GetString(body);
                            if (string.IsNullOrEmpty(message))
                            {
                                channel.BasicAck(ea.DeliveryTag, false);
                                continue;
                            }

                            T queueMessage = default(T);
                            try
                            {
                                queueMessage = message.ToEntity<T>();
                            }
                            catch
                            {

                            }

                            while (!isConsumeSuccess)
                            {
                                consumeCount++;
                                isConsumeSuccess = func(queueMessage);
                                if (isConsumeSuccess)
                                {
                                    channel.BasicAck(ea.DeliveryTag, false);//将队列里面的消息进行释放
                                }
                                else if (consumeCount >= tryTimes)
                                {
                                    isConsumeSuccess = true;
                                    channel.BasicAck(ea.DeliveryTag, false);//将队列里面的消息进行释放
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Log4NetHelper.Fatal(typeof(RabbitMQHelper), $"MQ消费异常。详情：{ex.Message}，堆栈：{ex.StackTrace}");
                            //throw ex;//此处如果throw出去，则监听将停止
                        }
                    }
                }
            }
        }

        #region 消费消息队列(新的方式)
        /// <summary>
        /// 消费消息队列
        /// </summary>
        /// <typeparam name="T">消息对象</typeparam>
        /// <param name="exchangeName">交换器名称</param>
        /// <param name="exchangeType">交换器类型</param>
        /// <param name="routingKey">路由关键字</param>
        /// <param name="queueName">队列名称</param>
        /// <param name="func">消费消息的具体操作</param>
        /// <param name="tryTimes">消费失败后，继续尝试消费的次数</param>
        public static void ReceiveEx<T>(string exchangeName, string exchangeType, string routingKey, string queueName, Func<T, bool> func, int tryTimes = 5)
        {
            int consumeCount = 0;//尝试消费次数
            bool isConsumeSuccess = false;//是否消费成功
            using (IConnection connection = _connectionFactory.CreateConnection())
            {
                using (IModel channel = connection.CreateModel())
                {
                    channel.ExchangeDeclare(exchangeName, exchangeType, true);
                    channel.QueueDeclare(queueName, true, false, false, null);
                    channel.QueueBind(queueName, exchangeName, routingKey);
                    EventingBasicConsumer consumer = new EventingBasicConsumer(channel);
                    channel.BasicConsume(queueName, false, consumer);
                    consumer.Received += (sender, eventArgs) =>
                    {
                        byte[] body = eventArgs.Body;
                        if (body != null && body.Length > 0)
                        {
                            string message = Encoding.UTF8.GetString(body);
                            if (!string.IsNullOrWhiteSpace(message))
                            {
                                T queueMessage = default(T);
                                try
                                {
                                    queueMessage = message.ToEntity<T>();
                                }
                                catch
                                {

                                }

                                while (!isConsumeSuccess)
                                {
                                    consumeCount++;
                                    isConsumeSuccess = func(queueMessage);
                                    if (isConsumeSuccess || consumeCount >= tryTimes) channel.BasicAck(eventArgs.DeliveryTag, false);
                                }

                            }
                        }
                    };
                }
            }
        }

        #endregion
    }
}
