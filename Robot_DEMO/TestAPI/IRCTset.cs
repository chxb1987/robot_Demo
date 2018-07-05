using System;
using System.Collections.Generic;
using System.Drawing;
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
        public ControllerInfoCollection infoControllers;
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
                Console.WriteLine("当前一共有 \t{0} 个实例运行，列表信息为：", infoControllers.Count);
                foreach (ControllerInfo item in infoControllers)
                {
                    Console.WriteLine(("").PadRight(70, '-'));
                    Console.WriteLine("Controller-Name:\t{0}", item.ControllerName);
                    Console.WriteLine("System-ID:\t{0}", item.SystemId);
                    Console.WriteLine("Base-Path:\t{0}", item.BaseDirectory);
                    Console.WriteLine("Virtual-Real?:\t{0}", item.IsVirtual);
                    Console.WriteLine("System-Name:\t{0}", item.SystemName);
                    Console.WriteLine("System-Version:\t{0}", item.Version);
                    Console.WriteLine("System-IPAddress:\t{0}", item.IPAddress);
                    Console.WriteLine(("").PadRight(70, '-'));
                    if
                        (item.Availability == Availability.Available)
                    {
                        if (this.controller != null)
                        {
                            this.controller.Logoff();
                            this.controller.Dispose();
                            this.controller = null;
                        }
                        this.controller = ControllerFactory.CreateFrom(item);
                        this.controller.Logon(UserInfo.DefaultUser);
                        if (controller.OperatingMode == ControllerOperatingMode.Auto)
                        {
                            tasks = controller.Rapid.GetTasks();
                            using (Mastership m = Mastership.Request(controller.Rapid))
                            {
                                //Perform operation
                                // this.controller.Restart();
                                tasks[0].Start();
                            }
                        }
                    }
                }
            }
        }
    }
}
