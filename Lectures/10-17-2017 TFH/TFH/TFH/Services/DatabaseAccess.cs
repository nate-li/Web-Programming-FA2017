using Microsoft.Practices.EnterpriseLibrary.TransientFaultHandling;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace TFH.Services
{
    public class DatabaseAccess
    {
        RetryPolicy rp = new RetryPolicy(new DetectionStrategy(), 10);

        public string Get(string id)
        {
            
            var result = rp.ExecuteAction(() =>
            {
                var myRequest = WebRequest.Create("www.google.com");
                var response = myRequest.GetResponse();
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                return responseString;
            });

            return result;
        }
    }
}
