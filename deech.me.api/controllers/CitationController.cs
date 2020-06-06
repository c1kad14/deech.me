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
    public class CitationController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IWriteDataService<Citation> _citationDataService;

        public CitationController(IWriteDataService<Citation> citationDataService, IMapper mapper)
        {
            this._citationDataService = citationDataService;
            this._mapper = mapper;
        }

        [HttpPost]
        public IActionResult Add([FromBody] CitationModel citation)
        {
            var entity = _mapper.Map<Citation>(citation);
            entity = _citationDataService.Add(entity);
            var result = _mapper.Map<CitationModel>(entity);

            return Ok(result);
        }

        [HttpPut]
        public IActionResult Update([FromBody] CitationModel citation)
        {
            var entity = _mapper.Map<Citation>(citation);
            entity = _citationDataService.Update(entity);
            var result = _mapper.Map<CitationModel>(entity);

            return Ok(result);
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] CitationModel citation)
        {
            var entity = _mapper.Map<Citation>(citation);
            _citationDataService.Delete(entity);

            return Ok(citation);
        }

        [HttpGet]
        public IActionResult Get(int bookId)
        {
            var userId = GetUserId();
            var citations = _citationDataService.GetMultiple(b => b.UserBook.BookId == bookId && b.UserBook.UserId == userId, 0, 10000);
            var result = _mapper.Map<CitationModel>(citations);

            return Ok(result);
        }

        private string GetUserId() => HttpContext.User.Claims.ToList().Single(c => c.Type == "id").Value;
    }
}