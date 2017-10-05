using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarryPotterMvc.Models
{
    public class SpellModel
    {
        public string Name { get; set; }
    }

    public class AllSpellsModel
    {
        public AllSpellsModel()
        {
            spells = new List<SpellModel>() {
                new SpellModel() { Name = "Avada Kavarda" },
                new SpellModel() { Name = "Wingardium Leviosa" }
            };
        }

        public List<SpellModel> spells { get; set; }

        public List<SpellModel> Mix(string one, string two)
        {
            return spells;
        }
    
    }
}
