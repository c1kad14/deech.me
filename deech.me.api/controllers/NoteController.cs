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
    public class NoteController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IWriteDataService<Note> _noteDataService;

        public NoteController(IWriteDataService<Note> noteDataService, IMapper mapper)
        {
            this._noteDataService = noteDataService;
            this._mapper = mapper;
        }

        [HttpPost]
        public IActionResult Add([FromBody] NoteModel note)
        {
            note.UserId = GetUserId();
            var entity = _mapper.Map<Note>(note);
            entity = _noteDataService.Add(entity);
            var result = _mapper.Map<NoteModel>(entity);

            return Ok(result);
        }

        [HttpPut]
        public IActionResult Update([FromBody] NoteModel note)
        {
            if (note.UserId != GetUserId())
            {
                return BadRequest();
            }

            var entity = _mapper.Map<Note>(note);
            entity = _noteDataService.Update(entity);
            var result = _mapper.Map<NoteModel>(entity);

            return Ok(result);
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] NoteModel note)
        {
            if (note.UserId != GetUserId())
            {
                return BadRequest();
            }

            var entity = _mapper.Map<Note>(note);
            _noteDataService.Delete(entity);

            return Ok();
        }

        [HttpGet]
        public IActionResult Get(int bookId)
        {
            var userId = GetUserId();
            var entities = _noteDataService.GetMultiple(b => b.UserBook.BookId == bookId && b.UserBook.UserId == userId, 0, 10000);
            var result = _mapper.Map<NoteModel>(entities);

            return Ok(result);
        }

        private string GetUserId() => HttpContext.User.Claims.ToList().Single(c => c.Type == "id").Value;
    }
}