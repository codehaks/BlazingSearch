using Microsoft.AspNetCore.Mvc;
using MyApp.Data;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.Controllers
{
    public class TagController : Controller
    {

        private readonly IDatabase _db;
        public TagController()
        {


            var redis = ConnectionMultiplexer.Connect("localhost:6379");
            _db = redis.GetDatabase();
        }

        [Route("api/tag")]
        public IActionResult Get() =>
             Ok(_db.HashGetAll("tags").Select(h=> new {Id=h.Name.ToString(),Name=h.Value.ToString() }));

        [Route("api/tag/{term}")]
        public IActionResult GetSearch(string term) =>
             Ok(_db.HashGetAll("tags").Select(h => new { Id = h.Name.ToString(), Name = h.Value.ToString() }).Where(t => t.Name.StartsWith(term)).OrderBy(t=>t.Name.Length));


    }
}
