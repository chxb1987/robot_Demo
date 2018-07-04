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
    class IRCTset
    {
        private NetworkScanner scanner;
        private Controller controller;
        private NetworkWatcher watcher;
        private ControllerInfoCollection infoControllers;
        private ABB.Robotics.Controllers.RapidDomain.Task[] tasks;
        private NetworkWatcher networkwatcher;
        private List<ControllerInfo> listControllers;

        public ControllerInfoCollection getCanner()
        {
            this.scanner = new NetworkScanner();
            this.scanner.Scan();
            infoControllers = scanner.Controllers;
            return infoControllers;
        }

        public void regWatcher()
        {
            if (infoControllers.Count != 0)
            {
                this.watcher = new NetworkWatcher(infoControllers);
                this.watcher.Found += Watcher_Found;
                this.watcher.Lost += Watcher_Lost;
            }
        }

        private void Watcher_Lost(object sender, NetworkWatcherEventArgs e)
        {
            Console.WriteLine("有实例下线");
        }

        private void Watcher_Found(object sender, NetworkWatcherEventArgs e)
        {
            Console.WriteLine("找到新的实例");
        }

        public void getScannerControllersView()
        {
            if (infoControllers.Count != 0)
            {
                foreach (ControllerInfo item in infoControllers)
                {
                    Console.WriteLine("当前一共有 {0} 个实例运行，列表信息为：", infoControllers.Count);
                    Console.Write("systemname:{0}", item.ControllerName);




                }
            }
 
        }
    }
}
