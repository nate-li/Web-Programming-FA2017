using Hobbits.Entities;
using Hobbits.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hobbits.Services
{
    public class HobbitDatabase
    {
        private List<HobbitModel> hobbits = new List<HobbitModel>();

        private ILoggingService loggingService;

        public HobbitDatabase(ILoggingService loggingService)
        {
            this.loggingService = loggingService;
        }

        public bool Add(HobbitModel hobbit)
        {
            hobbits.Add(hobbit);
            return true;
        }

        public bool Add(HobbitModel hobbit, int id)
        {
            if (id < 0 || id > hobbits.Count)
            {
                this.loggingService.Log("The id was invalid for the request.");
                return false;
            }

            hobbits[id] = hobbit;

            this.loggingService.Log("A hobbit was added.");
            return true;
        }

        public HobbitModel Get(int id)
        {
            return hobbits[id];
        }

        public bool Delete(int id)
        {
            hobbits.RemoveAt(id);
            return true;
        }
    }
}
