using AutoMapper;
using deech.me.data.entities;
using deech.me.logic.abstractions;
using deech.me.logic.models;
using Microsoft.AspNetCore.Mvc;

namespace deech.me.api.controllers
{
    [Route("[controller]")]
    public class NoteController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IWriteDataService<Note> _noteDataService;
        public NoteController(IWriteDataService<Note> noteDataService, IMapper mapper)
        {
            _noteDataService = noteDataService;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Add([FromBody] NoteModel Note)
        {
            var entity = _mapper.Map<Note>(Note);
            entity = _noteDataService.Add(entity);
            var result = _mapper.Map<NoteModel>(entity);

            return Ok(result);
        }

        [HttpPut]
        public IActionResult Update([FromBody] NoteModel Note)
        {
            var entity = _mapper.Map<Note>(Note);
            entity = _noteDataService.Update(entity);
            var result = _mapper.Map<NoteModel>(entity);
            return Ok(result);
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] NoteModel Note)
        {
            var entity = _mapper.Map<Note>(Note);
            _noteDataService.Delete(entity);
            return Ok();
        }

        [HttpGet]
        public IActionResult Get(int bookId)
        {
            var Notes = _noteDataService.GetMultiple(b => b.Paragraph.BookId == bookId, 0, 10000);
            var result = _mapper.Map<NoteModel>(Notes);
            return Ok(result);
        }
    }
}