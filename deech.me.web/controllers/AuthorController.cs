using Microsoft.AspNetCore.Mvc;

using deech.me.data.entities;
using deech.me.logic.abstractions;

namespace deech.me.web.controllers
{
    [Route("[controller]")]
    public class AuthorController : ControllerBase
    {
        private readonly IReadDataService<Author> _readDataService;

        public AuthorController(IReadDataService<Author> readDataService)
        {
            this._readDataService = readDataService;
        }

        [HttpGet("byName")]
        public ActionResult GetByName(string name, int skip = 0, int take = 20)
        {
            var author = name.ToLower().Trim();
            var result = this._readDataService.GetMultiple(a => (a.FirstName + " " + a.LastName).ToLower().Contains(author)
            || (a.FirstName + " " + a.MiddleName + " " + a.LastName).ToLower().Contains(author)
            || a.Nickname.ToLower().Contains(author), skip, take);

            return Ok(result);
        }

        [HttpGet("byId")]
        public ActionResult GetById(int id) => Ok(this._readDataService.GetSingle(a => a.Id == id));
    }
}