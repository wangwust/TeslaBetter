using System.Threading.Tasks;

namespace Tesla.Service
{
    /// <summary>
    /// MainWork
    /// </summary>
    public class MainWork
    {
        private LHCServerWork _lhcServer;
        private LHCClientWork _lhcClient;

        /// <summary>
        /// 构造函数
        /// </summary>
        public MainWork()
        {
            this._lhcServer = new LHCServerWork();
            this._lhcClient = new LHCClientWork();
        }

        /// <summary>
        /// 开始
        /// </summary>
        public void Start()
        {
            this.RunLHCServer();
            this.RunLHCClient();
        }

        /// <summary>
        /// 停止
        /// </summary>
        public void Stop()
        {
            this._lhcServer.Stop();
            this._lhcClient.Stop();
        }

        /// <summary>
        /// RunLHCServer
        /// </summary>
        private void RunLHCServer()
        {
            Task.Run(() =>
            {
                this._lhcServer.Start();
            });
        }

        /// <summary>
        /// RunLHCClient
        /// </summary>
        private void RunLHCClient()
        {
            Task.Run(() =>
            {
                this._lhcClient.Start();
            });
        }
    }
}
