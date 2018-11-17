using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesla.Client.Service;
using Tesla.Model;

namespace Tesla.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //MainWork work = new MainWork();
            //work.Run();

            RegisterParams param = new RegisterParams
            {
                UserName = "octest007",
                RealName = "欧彩测试007",
                Phone = "18636963568",
                Password = "qq123456",
                PayPwd = "0000",
                IP = "154.48.247.21",
                PlatformId = "08F22DF8F31643C78ADB8DC135E6DC92",
                ClientType = "Web",
                Api = "http://148.66.31.130:8012"
            };
            ApiResponse<RegisterResponse> res = RegisterHelper.Register(param);

            Console.Read();
        }
    }
}
