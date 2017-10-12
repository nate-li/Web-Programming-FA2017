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

        public bool Add(HobbitModel hobbit)
        {
            hobbits.Add(hobbit);
            return true;
        }

        public bool Add(HobbitModel hobbit, int id)
        {
            if (id < 0 || id > hobbits.Count)
            {
                return false;
            }

            hobbits[id] = hobbit;

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
