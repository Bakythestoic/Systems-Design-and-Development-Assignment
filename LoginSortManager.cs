using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CET_2007_ASSIGNMENT
{
   public class LoginSortManager
   {
        
        
            public List<LoginAttempt> SortByTimestamp(List<LoginAttempt> attempts)

            {
                List<LoginAttempt> SortedAttempts = new List<LoginAttempt>(attempts);
                for (int i = 0; i < SortedAttempts.Count - 1; i++)
                {
                    for (int j = 0; j < SortedAttempts.Count - i - 1; j++)
                    {
                        if (SortedAttempts[j].Timestamp > SortedAttempts[j + 1].Timestamp)
                        {
                            LoginAttempt temp = SortedAttempts[j];
                            SortedAttempts[j] = SortedAttempts[j + 1];
                            SortedAttempts[j + 1] = temp;
                        }
                    }
                }
                return SortedAttempts;
            }
        
    }
}
