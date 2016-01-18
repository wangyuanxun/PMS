using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Web.Management;

namespace CommonLib
{
    public class ServiceLog
    {
        private EventLog eventLog;
        public ServiceLog(string source, string log)
        {
            try
            {
                if (!EventLog.SourceExists(source))
                    EventLog.CreateEventSource(source, log);
                eventLog = new EventLog();
                eventLog.Source = source;
                eventLog.Log = log;
            }
            catch { }
        }

        public void WriteError(string message, params object[] args)
        {
            this.Write(string.Format(message, args), EventLogEntryType.Error);
        }

        public void WriteError(string message)
        {
            Write(message, EventLogEntryType.Error);
        }

        public void WriteWarning(string message)
        {
            Write(message, EventLogEntryType.Warning);
        }

        public void WriteInfo(string message)
        {
            Write(message, EventLogEntryType.Information);
        }

        public void Write(string message, EventLogEntryType type)
        {
            try
            {
                eventLog.WriteEntry(message, type);
            }
            catch { }
        }

        public void Write(string message, EventLogEntryType type, params object[] args)
        {
            try
            {
                eventLog.WriteEntry(string.Format(message, args), type);
            }
            catch { }
        }
    }
}
