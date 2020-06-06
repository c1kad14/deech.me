using System.Linq;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using AutoMapper;

using deech.me.data.entities;
using deech.me.logic.abstractions;
using deech.me.logic.models;

namespace deech.me.api.controllers
{
    [Authorize]
    [Route("[controller]")]
    public class BookmarkController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IWriteDataService<Bookmark> _bookmarkDataService;

        public BookmarkController(IWriteDataService<Bookmark> bookmarkDataService, IMapper mapper)
        {
            this._bookmarkDataService = bookmarkDataService;
            this._mapper = mapper;
        }

        [HttpPost]
        public IActionResult Add([FromBody] BookmarkModel bookmark)
        {
            var entity = _mapper.Map<Bookmark>(bookmark);
            entity = _bookmarkDataService.Add(entity);
            var result = _mapper.Map<BookmarkModel>(entity);

            return Ok(result);
        }

        [HttpPut]
        public IActionResult Update([FromBody] BookmarkModel bookmark)
        {
            var entity = _mapper.Map<Bookmark>(bookmark);
            entity = _bookmarkDataService.Update(entity);
            var result = _mapper.Map<BookmarkModel>(entity);

            return Ok(result);
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] BookmarkModel bookmark)
        {
            var entity = _mapper.Map<Bookmark>(bookmark);
            _bookmarkDataService.Delete(entity);

            return Ok(bookmark);
        }

        [HttpGet]
        public IActionResult Get(int bookId)
        {
            var userId = GetUserId();
            var bookmarks = _bookmarkDataService.GetMultiple(b => b.UserBook.BookId == bookId && b.UserBook.UserId == userId, 0, 10000);
            var result = _mapper.Map<BookmarkModel>(bookmarks);

            return Ok(result);
        }

        private string GetUserId() => HttpContext.User.Claims.ToList().Single(c => c.Type == "id").Value;
    }
}