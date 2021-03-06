using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Activation;
using CacheSrvInterfaceLib;

namespace CacheClientLib
{
    public class CacheClient
    {
        private static bool inited = false;
        public static void Init(string host)
        {
            if (!inited)
            {
                services = Register(host, "CacheServices", typeof(IServices)) as IServices;
                inited = true;
            }
        }
        private static object Register(string host, string appName, Type type)
        {
            string url = string.Format("tcp://{0}/{1}", host, appName);
            return Activator.GetObject(type, url);
        }
        private static IServices services;
        public static IServices Services
        {
            get { return services; }
        }
    }
}
