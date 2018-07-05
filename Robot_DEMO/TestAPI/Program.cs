using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ABB.Robotics.Controllers;
using ABB.Robotics.Controllers.Discovery;
using ABB.Robotics.Controllers.RapidDomain;

namespace TestAPI
{
    class Program
    {

        static void Main(string[] args)
        {
            IRCTset iRCTset = new IRCTset();
            iRCTset.getCanner();
            iRCTset.getScannerControllersView();
           // Console.WriteLine("请输入要选的实例，例如：1，2，3...");
          //  var id = Console.ReadLine();
 

            Console.ReadKey();



        }
    }
}
