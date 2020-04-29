using System.Text;
using deech.me.data.entities;
using deech.me.logic.abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace deech.me.api.Controllers
{
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly ILogger<BookController> _logger;
        private readonly IReadDataService<Book> _readDataService;

        public BookController(IReadDataService<Book> readDataService, ILogger<BookController> logger)
        {
            this._readDataService = readDataService;
            this._logger = logger;
        }

        [HttpGet("byTitleId")]
        public ActionResult GetBookBytitleId(int titleId)
        {
            this._logger.LogInformation($"Searching book by titleId: {titleId}");

            this._readDataService.SetIncludeFunc(i => i.Include(b => b.Images)
                                                       .Include(b => b.Contents)
                                                       .Include(b => b.TitleInfo));

            var result = this._readDataService.GetSingle(b => b.TitleInfo.Id == titleId);

            this._logger.LogInformation($"Searching by titleId result: {result?.TitleInfo?.Title}");

            return new JsonResult(result);
        }
    }
}