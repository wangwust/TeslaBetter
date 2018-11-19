using System.ServiceProcess;

namespace Tesla.Service
{
    public partial class MainService : ServiceBase
    {
        private MainWork mainWork;

        public MainService()
        {
            InitializeComponent();
            this.mainWork = new MainWork();
        }

        protected override void OnStart(string[] args)
        {
            this.mainWork.Start();
        }

        protected override void OnStop()
        {
            this.mainWork.Stop();
        }
    }
}
