using System;
using System.Configuration;
using System.ServiceProcess;
using System.Runtime.Remoting;
using System.Collections.Specialized;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using LogicSrvLib;

namespace LogicSrvService
{
    public partial class WinService : ServiceBase
    {
        public WinService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            try
            {
                NameValueCollection config = (NameValueCollection)ConfigurationManager.GetSection("appSettings");
                TcpChannel server = new TcpChannel(Convert.ToInt32(config["Prot"]));
                TY.DatabaseOperation.DataOperator.SetConnectionString(config["DBConnect"], config["KEY"], config["IV"]);
                ChannelServices.RegisterChannel(server, false);
                RemotingConfiguration.RegisterWellKnownServiceType(typeof(LogicSrvLib.Services), "LogicServices", WellKnownObjectMode.Singleton);
                MCache.Cache.init();
            }
            catch (Exception) { }
        }

        protected override void OnStop()
        {

        }
    }
}
