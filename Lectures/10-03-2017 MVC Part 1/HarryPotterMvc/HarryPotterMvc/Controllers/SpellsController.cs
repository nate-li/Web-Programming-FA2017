using HarryPotterMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarryPotterMvc.Controllers
{
    public class SpellsController : Controller
    {
        
        public static AllSpellsModel spells = new AllSpellsModel();


        public IActionResult Index()
        {
            return View(spells);
        }

        [HttpPost]
        public IActionResult Add()
        {
            if (Request.HasFormContentType)
            {
                if (Request.Form.TryGetValue("spell", out StringValues spellValue))
                {
                    spells.spells.Add(new SpellModel() { Name = spellValue[0] });
                }
            }
            return RedirectToAction("index");
        }
    }
}
