using System.ServiceProcess;
using System.Threading.Tasks;
using Tesla.Model;

namespace Tesla.Server.Service
{
    public partial class MainService : ServiceBase
    {
        MainWork mainWork;

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
