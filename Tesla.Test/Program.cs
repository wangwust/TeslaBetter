using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesla.Service;
using Tesla.Model;

namespace Tesla.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            MainWork work = new MainWork();
            work.Start();

            Console.Read();
        }
    }
}
