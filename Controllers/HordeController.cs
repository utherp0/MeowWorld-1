using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MeowWorld.Controllers
{
    public class HordeController : Controller
    {
        private Dictionary<string, string> _Cats = new Dictionary<string, string>();

        [HttpPost("horde/{cat}")]
        public string Post(string cat, [FromBody]string sound)
        {
            _Cats[cat] = sound;

            return String.Format("{0} added to the horde!", cat);
        }

        [HttpGet("horde/{cat}")]
        public string Get(string cat)
        {
            if (!_Cats.ContainsKey(cat))
            {
                return "Cat not found.";
            }

            return _Cats[cat];
        }

        [HttpPatch("horde/{cat}")]
        public string Patch(string cat, [FromBody]string sound)
        {
            if (!_Cats.ContainsKey(cat))
            {
                return "Cat not found.";
            }

            _Cats[cat] = sound;

            return "Cat updated.";
        }

        [HttpDelete("horde/{cat}")]
        public string Delete(string cat)
        {
            if (!_Cats.ContainsKey(cat))
            {
                return "Cat not found.";
            }

            _Cats.Remove(cat);

            return "Cat deleted.";
        }
    }
}
