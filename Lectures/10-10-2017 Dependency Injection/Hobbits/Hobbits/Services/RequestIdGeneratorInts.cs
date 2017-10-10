using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hobbits.Services
{
    public class RequestIdGeneratorInts : IRequestIdGenerator
    {

        private int current = 1;

        public string RequestId()
        {
            return current++.ToString();
        }
    }
}
