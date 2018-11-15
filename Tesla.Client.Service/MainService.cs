using System.ServiceProcess;
using System.Threading.Tasks;

namespace Tesla.Client.Service
{
    public partial class MainService : ServiceBase
    {
        private MainWork mainWork;

        public MainService()
        {
            InitializeComponent();
            mainWork = new MainWork();
        }

        protected override void OnStart(string[] args)
        {
            Task.Run(() =>
            {
                mainWork.Run();
            });
        }

        protected override void OnStop()
        {
            mainWork.Stop();
        }
    }
}
