using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CET_2007_ASSIGNMENT
{
    public class LoginSearchManager
    {
        public List<LoginAttempt>SearchByUsername(List<LoginAttempt>attempts, string username)
        {
            List<LoginAttempt> results = new List<LoginAttempt>();
            foreach(LoginAttempt attempt in attempts)
            {
                if(attempt.Username == username)
                {
                    results.Add(attempt);
                }

               
            }
            return results;
        }
    }
}
