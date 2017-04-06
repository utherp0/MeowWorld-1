using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MeowWorld.Controllers
{
    public class CatController : Controller
    {
        [HttpGet("cat/{cat}")]
        public string Cat(string cat)
        {
            switch (cat)
            {
                case "bill":
                    return "Meow!";
                case "steve":
                    return "Purr.";
            }

            return String.Empty;
        }

        [HttpGet("cat/all")]
        public IActionResult All()
        {
            return View();
        }
    }
}