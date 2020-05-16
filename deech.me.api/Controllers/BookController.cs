using System.Linq;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using deech.me.data.entities;
using deech.me.logic.abstractions;
using AutoMapper;
using deech.me.logic.models;
using System;

namespace deech.me.api.controllers
{
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IReadDataService<Book> _readDataService;

        public BookController(IReadDataService<Book> readDataService, IMapper mapper)
        {
            this._readDataService = readDataService;
            this._mapper = mapper;
        }

        [HttpGet("byTitleId")]
        public ActionResult GetBookByTitleId(int titleId)
        {
            this._readDataService.SetIncludeFunc(i => i.Include(b => b.Paragraphs)
                                                       .ThenInclude(p => p.Comments)
                                                       .Include(b => b.TitleInfo));

            var result = this._readDataService.GetSingle(b => b.TitleInfo.Id == titleId);
            var mapped = this._mapper.Map<BookModel>(result);

            return Ok(mapped);
        }

        [HttpGet("byAuthorId")]
        public ActionResult GetBookByAuthorId(int authorId)
        {
            this._readDataService.SetIncludeFunc(i => i.Include(b => b.TitleInfo)
                                                       .ThenInclude(bti => bti.Authors));

            var result = this._readDataService.GetSingle(b => b.TitleInfo.Authors.Any(a => a.AuthorId == authorId));

            return Ok(result);
        }
    }
}