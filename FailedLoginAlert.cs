using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CET_2007_ASSIGNMENT
{
    public class FailedLoginAlert:SecurityAlert
    {
        public string Username { get; set; }
        public FailedLoginAlert(string description,DateTime alertTime,string username):base(description, alertTime)
        {
           
            Username = username;
        }
        public override string GetAlertMessage()
        {
            return $"Security Alert:{Username} has experienced multiple failed login attempts.";
        }
    }
   
}
