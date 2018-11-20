using System;
using Tesla.App;
using Tesla.Model;
using Tesla.Utils;

namespace Tesla
{
    /// <summary>
    /// MQ帮助类
    /// </summary>
    public static class MQHelper
    {
        /// <summary>
        /// 推送
        /// </summary>
        /// <param name="betParam"></param>
        public static bool Publish(BetParams betParam)
        {
            try
            {
                RabbitMQHelper.Publish(MQConfig.BetExchange, "topic", "", betParam);
                return true;
            }
            catch (Exception ex)
            {
                Log4NetHelper.Error(typeof(MQHelper), $"推送投注信息异常。投注信息：{betParam.ToJson()}。异常：{ex.ToString()}");
                return false;
            }
        }
    }
}
