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
            Console.WriteLine(iRCTset.getCanner().ToString());


            Console.ReadKey();



        }
    }
}
