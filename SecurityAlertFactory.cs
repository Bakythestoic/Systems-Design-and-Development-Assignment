using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CET_2007_ASSIGNMENT
{
    public class SecurityAlertFactory
    {
        public SecurityAlert CreateAlert(AlertType type, string description, DateTime alertTime, string identifier)
        {
            switch (type)
            {

                case AlertType.FailedLogin:
                    return new FailedLoginAlert(description, alertTime, identifier);
               
                case AlertType.ExcessiveIP:
                    return new ExcessiveIPAlert(description, alertTime, identifier);

                case AlertType.SuccessfulLoginAfterFailures:
                    return new SuccessfulLoginAfterFailuresAlert(description, alertTime, identifier);
                default:
                    return null;



            }

        }

    }

    public class ExcessiveIPAlert : SecurityAlert 
    { 
        public string IPAddress { get; set; }
        
        public ExcessiveIPAlert(string description,DateTime alertTime, string ipAddress) : base(description, alertTime)
        {
            IPAddress = ipAddress;
        }

        public override string GetAlertMessage()
        {
            return $"Security Alert:Excessive login attempts detected from IP address {IPAddress}";
        }
    }
    public class SuccessfulLoginAfterFailuresAlert : SecurityAlert
    {
        public string Username { get; set; }
       

        public SuccessfulLoginAfterFailuresAlert(string description,DateTime alertTime,string username) : base(description, alertTime)
        {
            Username = username;
        }

        public override string GetAlertMessage()
        {
            return $"Security Alert:{Username} successfully logged in after multiple failed attempts";
        }
    }
}
