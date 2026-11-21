using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CET_2007_ASSIGNMENT
{
    public class LoginSecurityAnalyzer
    {
        public List<string> DetectMultipleFailedLogins(List<LoginAttempt> attempts)
        {
            var failedLogins = attempts.Where(a => !a.IsSuccessful)
                                     .GroupBy(a => a.Username)
                                     .Where(g => g.Count() >=3)
                                     .Select(g => g.Key)
                                     .ToList();
            return failedLogins;

        }

        public List<string> DetectSuccessfulLoginAfterFailures(List<LoginAttempt> attempts)
        {
            var orderedAttempts = attempts.OrderBy(a => a.Timestamp).ToList();
            Dictionary<string,int> failedAttemptsCount = new Dictionary<string, int>();

            List<string>flaggedUsers = new List<string>();

           foreach (var attempt in orderedAttempts)
           {
                if (!attempt.IsSuccessful)
                {
                    if (failedAttemptsCount.TryGetValue(attempt.Username, out int count))
                    {
                        failedAttemptsCount[attempt.Username] = count + 1;
                    }
                    else
                    {
                        failedAttemptsCount[attempt.Username] = 1;
                    }

                }

                else
                {
                    if(failedAttemptsCount.TryGetValue(attempt.Username, out int count) && count >= 3)
                    {
                        if (!flaggedUsers.Contains(attempt.Username))
                        {
                            flaggedUsers.Add(attempt.Username);
                        }
                    }

                }
               
           }
            return flaggedUsers;
        }
        public List<string> DetectExcessiveIPAttempts(List<LoginAttempt> attempts)
        {
            var excesiveIPAttempts = attempts.GroupBy(a => a.IPAddress)
                                              .Where(g => g.Count() >10)
                                              .Select(g => g.Key)
                                              .ToList();
            return excesiveIPAttempts;
        }
    }
}
