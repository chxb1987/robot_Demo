using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ABB.Robotics.Controllers.Discovery;
using ABB.Robotics.Controllers;
using ABB.Robotics.Controllers.RapidDomain;

namespace ABB_DEMO_TEST
{
    public class NetDumpRapid
    {
        private NetworkScanner networkScanner;
        private ControllerInfo[] controllerInfos;

        public void getControllers(NetworkScanner scanner)
        {
            if (scanner != null)
            {
                networkScanner = scanner;
                controllerInfos = scanner.GetControllers();
                foreach (var controller in controllerInfos)
                {
                    TestContrall(controller);
                }
            }
        }
        private void TestContrall(ControllerInfo ctrl)
        {
            Console.WriteLine("Controller: {0} is Version: {1} SystemName: {2}", ctrl.HostName, ctrl.Version, ctrl.SystemName);

            Controller controller = ControllerFactory.CreateFrom(ctrl);
            ABB.Robotics.Controllers.RapidDomain.Task[] tasks = controller.Rapid.GetTasks();
            foreach (ABB.Robotics.Controllers.RapidDomain.Task t in tasks)
            {
                TraceTask(t);
            }
        }

        private void TraceTask(ABB.Robotics.Controllers.RapidDomain.Task t)
        {
            Console.WriteLine("\t Task: {0}", t.Name);
            Module[] modules = t.GetModules();
            foreach (Module m in modules)
            {
                TraceModule(m);
            }
        }

        private void TraceModule(Module m)
        {
            Console.WriteLine("\t\t Module: {0}", m.Name);
            Routine[] routines = m.GetRoutines();
            foreach (Routine r in routines)
            {
                TraceRoutine(r);
            }
        }

        private void TraceRoutine(Routine r)
        {
            Console.WriteLine("\t\t\t Routine: {0}", r.Name);
        }
    }
}
