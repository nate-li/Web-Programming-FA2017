using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hobbits.Services
{
    public class DateTimeProvider
    {

        public DateTime GetCurrentTime()
        {
            return DateTime.UtcNow;
        }
    }
}
