using Microsoft.AspNetCore.Mvc;
using MyApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.Controllers
{
    public class TagController : Controller
    {
        private readonly AppDbContext _db;

        public TagController(AppDbContext db)
        {
            _db = db;
        }

        [Route("api/tag")]
        public IActionResult Get() =>
             Ok(_db.Tags.Take(1000));

        [Route("api/tag/{term}")]
        public IActionResult GetSearch(string term) =>
             Ok(_db.Tags.Where(t=>t.Name.StartsWith(term)));


    }
}
