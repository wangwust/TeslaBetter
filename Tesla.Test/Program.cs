using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesla.Service;
using Tesla.Model;
using Tesla.Utils;

namespace Tesla.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //MainWork work = new MainWork();
            //work.Start();

            SCBetter better = new SCBetter();
            better.Start();

            //BJKCPicker.Run();

            //bool b = EmailHelper.Send("1277955953@qq.com", "测试", "这是一条测试邮件");

            Console.Read();
        }
    }
}
