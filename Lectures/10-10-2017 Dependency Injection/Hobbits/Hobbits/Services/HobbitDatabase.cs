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

        public void Add(HobbitModel hobbit)
        {
            this.hobbits.Add(hobbit);
        }

        public void Add(HobbitModel hobbit, int id)
        {
            this.hobbits[id] = hobbit;
        }

        public HobbitModel Get(int id)
        {
            return this.hobbits[id];
        }

        public bool Delete(int id)
        {
            this.hobbits.RemoveAt(id);
            return true;
        }
    }
}
