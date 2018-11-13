namespace Tesla.Model
{
    /// <summary>
    /// 任务停止原因
    /// </summary>
    public static class TaskStopReason
    {
        /// <summary>
        /// 未启动
        /// </summary>
        public static int NotStarted => 0;

        /// <summary>
        /// 服务端掉线
        /// </summary>
        public static int ServerToken => 1;

        /// <summary>
        /// 服务端余额不足
        /// </summary>
        public static int ServerMoney => 2;

        /// <summary>
        /// 服务端投注异常
        /// </summary>
        public static int ServerException => 3;

        /// <summary>
        /// 客户端掉线
        /// </summary>
        public static int ClientToken => 4;

        /// <summary>
        /// 客户端余额不足
        /// </summary>
        public static int ClientMoney => 5;

        /// <summary>
        /// 客户端投注异常
        /// </summary>
        public static int ClientException => 6;

        /// <summary>
        /// 手动停止
        /// </summary>
        public static int Manual => 7;
    }
}
