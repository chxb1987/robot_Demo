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
        private ControllerInfoCollection infoControllers;
        private ABB.Robotics.Controllers.RapidDomain.Task[] tasks;
        private NetworkWatcher networkwatcher;
        private List<ControllerInfo> listControllers;

        public ControllerInfoCollection getCanner()
        {
            this.scanner = new NetworkScanner();
            this.scanner.Scan();
            return scanner.Controllers;
        }
    }
}
