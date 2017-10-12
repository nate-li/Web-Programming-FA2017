﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hobbits.Services
{
    public class LoggingService : ILoggingService
    {

        private IRequestIdGenerator requestIdGenerator;

        private DateTimeProvider dateTimeProvider;

        public LoggingService(IRequestIdGenerator requestIdGenerator, DateTimeProvider dateTimeProvider)
        {
            this.requestIdGenerator = requestIdGenerator;
            this.dateTimeProvider = dateTimeProvider;
        }

        public void Log(string message)
        {
            Console.Write(message + " " + this.requestIdGenerator.RequestId() + " " + this.dateTimeProvider.GetCurrentTime());
        }
    }
}
