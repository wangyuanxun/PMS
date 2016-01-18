using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogicSrvInterfaceLib
{
    public interface ILogService
    {
        void WriteLog(string logInfo, string objID, EntityLib.Model.Log.Level logLevel, EntityLib.Model.Log.Type logType, string remark = "");
    }
}
