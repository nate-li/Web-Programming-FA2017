﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hobbits.Services
{
    public class RequestIdGenerator : IRequestIdGenerator
    {
        private string requestId;

        public RequestIdGenerator()
        {
            this.requestId = Guid.NewGuid().ToString();
        }

        public string RequestId()
        {
            return this.requestId;
        }
    }
}
