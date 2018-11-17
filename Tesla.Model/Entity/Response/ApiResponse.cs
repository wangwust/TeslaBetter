namespace Tesla.Model
{
    /// <summary>
    /// Api请求反馈
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ApiResponse<T>
    {
        /// <summary>
        /// 状态码
        /// </summary>
        public int code { get; set; }

        /// <summary>
        /// 消息
        /// </summary>
        public string msg { get; set; }

        /// <summary>
        /// 数据
        /// </summary>
        public T data { get; set; }

        /// <summary>
        /// 操作是否成功
        /// </summary>
        public bool IsSucceed => this.code == 200;
    }
}
