using AutoMapper;
using deech.me.data.entities;
using deech.me.logic.abstractions;
using deech.me.logic.models;
using Microsoft.AspNetCore.Mvc;

namespace deech.me.api.controllers
{
    [Route("[controller]")]
    public class CitationController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IWriteDataService<Citation> _citationDataService;
        public CitationController(IWriteDataService<Citation> citationDataService, IMapper mapper)
        {
            _citationDataService = citationDataService;
            _mapper = mapper;
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
            return Ok();
        }

        [HttpGet]
        public IActionResult Get(int bookId)
        {
            var citations = _citationDataService.GetMultiple(b => b.Paragraph.BookId == bookId, 0, 10000);
            var result = _mapper.Map<CitationModel>(citations);
            return Ok(result);
        }
    }
}