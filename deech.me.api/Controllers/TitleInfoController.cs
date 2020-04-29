using System.Linq;
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
        private readonly IReadDataService<TitleInfo> readDataService;

        public TitleInfoController(ILogger<TitleInfoController> logger, IReadDataService<TitleInfo> readDataService)
        {
            this.readDataService = readDataService;
            this._logger = logger;
        }

        [HttpGet("byTitle")]
        public ActionResult GetByTitle(string title)
        {
            this._logger.LogInformation($"Searching by title: {title}");
            
            var result = this.readDataService.GetMultiple(t => string.IsNullOrEmpty(t.Title) && t.Title.ToLower().Contains(title.ToLower()));

            this._logger.LogInformation($"Searching by title result: {title}");

            return new JsonResult(result);
        }

        [HttpGet("byId")]
        public ActionResult GetById(int id)
        {
            this._logger.LogInformation($"Searching by id: {id}");

            var result = this.readDataService.GetSingle(t => t.Id == id);

            this._logger.LogInformation($"Searching by id result: {result?.Title}");

            return new JsonResult(result);
        }

        [HttpGet("byGenre")]
        public ActionResult GetByGenre(string genre)
        {
            this._logger.LogInformation($"Searching by genre: {genre}");

            this.readDataService.SetIncludeFunc(i => i.Include(ti => ti.Genres));

            var result = this.readDataService.GetMultiple(t => t.Genres.Any(g => g.GenreCode == genre));

            this._logger.LogInformation($"Searching by id result: {result.Count}");

            return new JsonResult(result);
        }
    }
}