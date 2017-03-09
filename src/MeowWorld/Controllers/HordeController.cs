using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MeowWorld.Controllers
{
    public class HordeController : Controller
    {
        private static Dictionary<string, string> _Cats = new Dictionary<string, string>();

        [HttpGet("horde/add/{cat}")]
        public string Add(string cat, string sound)
        {
            string key = String.Format("{0}-{1}", cat, HttpContext.Session.Id);

            _Cats[key] = sound;

            return String.Format("{1} added to the horde!\n{0}", HttpContext.Session.Id, cat);
        }

        [HttpGet("horde/{cat}")]
        public string Get(string cat)
        {
            string key = String.Format("{0}-{1}", cat, HttpContext.Session.Id);

            if (!_Cats.ContainsKey(key))
            {
                return "Cat not found.";
            }

            return String.Format("{1} says: {2}\n{0}", HttpContext.Session.Id, cat, _Cats[cat]);
        }
    }
}