using System.Linq;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using deech.me.data.entities;
using deech.me.logic.abstractions;

namespace deech.me.api.controllers
{
    [Route("[controller]")]
    public class TitleInfoController : ControllerBase
    {
        private readonly IReadDataService<TitleInfo> _readDataService;

        public TitleInfoController(IReadDataService<TitleInfo> readDataService)
        {
            this._readDataService = readDataService;
        }

        [HttpGet("byTitle")]
        public ActionResult GetByTitle(string title)
        {
            var result = this._readDataService.GetMultiple(t => t.Title.ToLower().Contains(title.ToLower().Trim()));

            return new JsonResult(result);
        }

        [HttpGet("byId")]
        public ActionResult GetById(int id)
        {
            this._readDataService.SetIncludeFunc(i => i.Include(ti => ti.Authors)
                                                       .ThenInclude(tia => tia.Author)
                                                       .Include(ti => ti.Cover)
                                                       .Include(ti => ti.Genres)
                                                       .Include(ti => ti.Annotation)
                                                       .Include(ti => ti.Translators)
                                                       .ThenInclude(tit => tit.Translator)
                                                       .Include(ti => ti.SourceLanguage)
                                                       .Include(ti => ti.Language)
                                                       .Include(ti => ti.Keywords));

            var result = this._readDataService.GetSingle(t => t.Id == id);

            return new JsonResult(result);
        }

        [HttpGet("byGenre")]
        public ActionResult GetByGenre(string genre)
        {
            this._readDataService.SetIncludeFunc(i => i.Include(ti => ti.Genres));

            var result = this._readDataService.GetMultiple(t => t.Genres.Any(g => g.GenreCode == genre));

            return new JsonResult(result);
        }
    }
}