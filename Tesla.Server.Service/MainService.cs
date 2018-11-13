using System.ServiceProcess;
using System.Threading.Tasks;

namespace Tesla.Server.Service
{
    public partial class MainService : ServiceBase
    {
        public MainService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            Task.Run(() =>
            {
                new MainWork().Run();
            });
        }

        protected override void OnStop()
        {
        }
    }
}
