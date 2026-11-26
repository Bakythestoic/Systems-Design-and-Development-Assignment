using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CET_2007_ASSIGNMENT
{
    public class SecurityAlert:IAlert
    {
        public string Description { get; set; }
        public DateTime AlertTime { get; set; }
        public SecurityAlert(string description, DateTime alertTime)
        {
            Description = description;
            AlertTime = alertTime;
           
        }
        public virtual string GetAlertMessage()
        {
            return Description;
        }
    }

}
