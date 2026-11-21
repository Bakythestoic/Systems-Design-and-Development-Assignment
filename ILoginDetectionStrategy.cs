using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CET_2007_ASSIGNMENT
{
    public interface ILoginDetectionStrategy
    {
        List<string> Detect(List<LoginAttempt> attempts);
    }
}
