using System.Linq;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using deech.me.data.entities;
using deech.me.logic.abstractions;

namespace deech.me.api.controllers
{
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IReadDataService<Book> _readDataService;

        public BookController(IReadDataService<Book> readDataService)
        {
            this._readDataService = readDataService;
        }

        [HttpGet("byTitleId")]
        public ActionResult GetBookByTitleId(int titleId)
        {
            this._readDataService.SetIncludeFunc(i => i.Include(b => b.Images)
                                                       .Include(b => b.Contents)
                                                       .Include(b => b.TitleInfo));

            var result = this._readDataService.GetSingle(b => b.TitleInfo.Id == titleId);

            return new JsonResult(result);
        }

        [HttpGet("byAuthorId")]
        public ActionResult GetBookByAuthorId(int authorId)
        {
            this._readDataService.SetIncludeFunc(i => i.Include(b => b.Images)
                                                       .Include(b => b.Contents)
                                                       .Include(b => b.TitleInfo)
                                                       .ThenInclude(bti => bti.Authors));

            var result = this._readDataService.GetSingle(b => b.TitleInfo.Authors.Any(a => a.AuthorId == authorId));

            return new JsonResult(result);
        }
    }
}