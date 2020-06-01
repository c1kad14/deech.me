using AutoMapper;
using deech.me.data.entities;
using deech.me.logic.abstractions;
using deech.me.logic.models;
using Microsoft.AspNetCore.Mvc;

namespace deech.me.api.controllers
{
    [Route("[controller]")]
    public class BookmarkController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IWriteDataService<Bookmark> _bookmarkDataService;
        public BookmarkController(IWriteDataService<Bookmark> bookmarkDataService, IMapper mapper)
        {
            _bookmarkDataService = bookmarkDataService;
            _mapper = mapper;
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
            return Ok();
        }

        [HttpGet]
        public IActionResult Get(int bookId)
        {
            var bookmarks = _bookmarkDataService.GetMultiple(b => b.Paragraph.BookId == bookId, 0, 10000);
            var result = _mapper.Map<BookmarkModel>(bookmarks);
            return Ok(result);
        }
    }
}