using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CET_2007_ASSIGNMENT
{
    public class SecurityAlertLogger
    {
        private SecurityAlertLogger() { }

        private static SecurityAlertLogger instance = new SecurityAlertLogger();
        public static SecurityAlertLogger GetInstance()
        {
            return instance;
        }
    
       public void LogAlert(SecurityAlert alert)
       {
            File.AppendAllText("SecurityAlerts.txt", alert.GetAlertMessage() + Environment.NewLine);
       }
    }
  
}
    

