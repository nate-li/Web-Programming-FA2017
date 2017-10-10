using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hobbits.Services
{
    public class LoggingService
    {

        public void Log(string message)
        {
            Console.Write(message);
        }
    }
}
