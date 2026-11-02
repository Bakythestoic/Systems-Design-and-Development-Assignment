using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CET_2007_ASSIGNMENT
{
    internal class LoginAttempt
    {
        public string Username {  get; set; }
        public string IPAddress {  get; set; }
        public DateTime Timestamp {  get; set; }

        public bool IsSuccessful {  get; set; }

        public LoginAttempt(string username,string ipaddress, DateTime timestamp,bool issuccessful)
        {
            Username = username;
            IPAddress = ipaddress;
            Timestamp = timestamp;
            IsSuccessful = issuccessful;
        }
    }
}
