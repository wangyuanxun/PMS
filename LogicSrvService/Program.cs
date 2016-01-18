using System.Collections.Generic;
using System.ServiceProcess;
using System.Text;

namespace LogicSrvService
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        static void Main()
        {
            ServiceBase[] ServicesToRun = new ServiceBase[] { new WinService() };
            ServiceBase.Run(ServicesToRun);
        }
    }
}