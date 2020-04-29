using System;
using System.IO;
using System.Linq;
using System.Text;
using deech.me.data.entities;
using deech.me.logic.abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace deech.me.api.Controllers
{
    [Route("[controller]")]
    public class TitleInfoController : ControllerBase
    {
        private readonly ILogger<TitleInfoController> _logger;
        private readonly IReadDataService<TitleInfo> _readDataService;

        public TitleInfoController(ILogger<TitleInfoController> logger, IReadDataService<TitleInfo> readDataService)
        {
            this._readDataService = readDataService;
            this._logger = logger;
        }

        [HttpGet("byTitle")]
        public ActionResult GetByTitle(string title)
        {
            this._logger.LogInformation($"Searching title by title: {title}");

            var result = this._readDataService.GetMultiple(t => string.IsNullOrEmpty(t.Title) && t.Title.ToLower().Contains(title.ToLower()));

            this._logger.LogInformation($"Searching by title result: {title}");

            return new JsonResult(result);
        }

        [HttpGet]
        public ActionResult GetById(int id)
        {
            this._logger.LogInformation($"Searching title by id: {id}");

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

            this._logger.LogInformation($"Searching by id result: {result?.Title}");

            return new JsonResult(result);
        }

        [HttpGet("byGenre")]
        public ActionResult GetByGenre(string genre)
        {
            this._logger.LogInformation($"Searching title by genre: {genre}");

            this._readDataService.SetIncludeFunc(i => i.Include(ti => ti.Genres));

            var result = this._readDataService.GetMultiple(t => t.Genres.Any(g => g.GenreCode == genre));

            this._logger.LogInformation($"Searching by id result: {result.Count}");

            return new JsonResult(result);
        }
    }
}