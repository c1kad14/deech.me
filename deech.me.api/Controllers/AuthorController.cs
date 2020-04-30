using Microsoft.AspNetCore.Mvc;

using deech.me.data.entities;
using deech.me.logic.abstractions;

namespace deech.me.api.controllers
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
        public ActionResult GetByName(string name)
        {
            var author = name.ToLower().Trim();
            var result = this._readDataService.GetMultiple(a => (a.FirstName + " " + a.LastName).ToLower().Contains(author)
            || (a.FirstName + " " + a.MiddleName + " " + a.LastName).ToLower().Contains(author)
            || a.Nickname.ToLower().Contains(author));

            return new JsonResult(result);
        }

        [HttpGet("byId")]
        public ActionResult GetById(int id) => new JsonResult(this._readDataService.GetSingle(a => a.Id == id));
    }
}