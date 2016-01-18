using System;
using System.Configuration;
using System.ServiceProcess;
using System.Runtime.Remoting;
using System.Collections.Specialized;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using CacheSrvLib;

namespace CacheSrvService
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
                var config = (NameValueCollection)ConfigurationManager.GetSection("appSettings");
                var server = new TcpChannel(Convert.ToInt32(config["Prot"]));
                TY.DatabaseOperation.DataOperator.SetConnectionString(config["DBConnect"], config["KEY"], config["IV"]);
                ChannelServices.RegisterChannel(server, false);
                RemotingConfiguration.RegisterWellKnownServiceType(typeof(CacheSrvLib.Services), "CacheServices", WellKnownObjectMode.Singleton);
                RemotingConfiguration.CustomErrorsMode = CustomErrorsModes.Off;
                RemotingConfiguration.CustomErrorsEnabled(false);
                MCache.Cache.init();
            }
            catch (Exception) { }
        }

        protected override void OnStop()
        {

        }
    }
}
