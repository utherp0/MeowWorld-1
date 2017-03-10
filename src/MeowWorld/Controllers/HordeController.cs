using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MeowWorld.Controllers
{
    public class HordeController : Controller
    {
        [HttpGet("horde/add/{cat}")]
        public string Add(string cat, string sound)
        {
            HttpContext.Session.Set(cat, System.Text.Encoding.Unicode.GetBytes(sound));

            return String.Format("{1} added to the horde!\n{0}", HttpContext.Session.Id, cat);
        }

        [HttpGet("horde/{cat}")]
        public string Get(string cat)
        {
            byte[] bytes;

            if (!HttpContext.Session.TryGetValue(cat, out bytes))
            {
                return "Cat not found.";
            }

            string sound = System.Text.Encoding.Unicode.GetString(bytes);

            return String.Format("{1} says: {2}\n{0}", HttpContext.Session.Id, cat, sound);
        }
    }
}