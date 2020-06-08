using System;
using System.Linq;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using AutoMapper;

using deech.me.data.entities;
using deech.me.logic.abstractions;
using deech.me.logic.models;
using Microsoft.AspNetCore.Authorization;

namespace deech.me.web.controllers
{
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IReadDataService<Book> _bookDataService;
        private readonly IWriteDataService<UserBook> _userBookDataService;

        public BookController(IReadDataService<Book> bookDataService, IWriteDataService<UserBook> userBookDataService, IMapper mapper)
        {
            this._userBookDataService = userBookDataService;
            this._bookDataService = bookDataService;
            this._mapper = mapper;
        }

        [HttpGet]
        public ActionResult Get(int id)
        {
            var userId = GetUserId();

            if (string.IsNullOrEmpty(userId))
            {
                this._bookDataService.SetIncludeFunc(i => i.Include(b => b.Paragraphs)
                                                           .ThenInclude(p => p.Comments)
                                                           .Include(b => b.TitleInfo));
                var result = this._bookDataService.GetSingle(b => b.TitleInfo.Id == id);
                var mapped = this._mapper.Map<BookModel>(result);

                return Ok(mapped);
            }
            else
            {
                this._userBookDataService.SetIncludeFunc(x => x.Include(u => u.Book)
                                                        .ThenInclude(b => b.Paragraphs)
                                                        .ThenInclude(p => p.Comments)
                                                        .Include(b => b.Book)
                                                        .ThenInclude(b => b.TitleInfo)
                                                        .Include(u => u.Bookmarks)
                                                        .Include(u => u.Citations)
                                                        .Include(u => u.Notes));
                var result = this._userBookDataService.GetSingle(b => b.UserId == userId && b.BookId == id);

                if (result == null)
                {
                    this._userBookDataService.Add(
                        new UserBook
                        {
                            UserId = userId,
                            BookId = id,
                            Created = DateTime.Now.ToString("yyyy-MM-dd HH:mm")
                        });

                    result = this._userBookDataService.GetSingle(b => b.UserId == userId && b.BookId == id);
                }

                var mapped = this._mapper.Map<UserBookModel>(result);

                return Ok(mapped);
            }
        }

        [HttpGet("byAuthorId")]
        public ActionResult GetBookByAuthorId(int authorId)
        {
            this._bookDataService.SetIncludeFunc(i => i.Include(b => b.TitleInfo)
                                                       .ThenInclude(bti => bti.Authors));

            var result = this._bookDataService.GetSingle(b => b.TitleInfo.Authors.Any(a => a.AuthorId == authorId));

            return Ok(result);
        }

        [Authorize]
        [HttpGet("progress")]
        public ActionResult SetReadingProgress(int book, int value)
        {
            var userId = GetUserId();
            var userBook = this._userBookDataService.GetSingle(b => b.UserId == userId && b.Id == book);

            if (userBook != null)
            {
                userBook.Progress = value;
                this._userBookDataService.Update(userBook);
            }

            return Ok();
        }

        private string GetUserId() => HttpContext.User?.Claims?.ToList().SingleOrDefault(c => c.Type == "id")?.Value;
    }
}