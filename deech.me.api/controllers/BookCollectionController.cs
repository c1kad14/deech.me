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
    public class BookCollectionController : ControllerBase
    {
        private readonly IWriteDataService<BookCollection> _bookCollectionDataService;
        private readonly IMapper _mapper;

        public BookCollectionController(IWriteDataService<BookCollection> bookCollectionDataService, IMapper mapper)
        {
            this._bookCollectionDataService = bookCollectionDataService;
            this._mapper = mapper;
        }

        public BookCollectionController()
        {

        }

        [HttpPost]
        public IActionResult Add([FromBody] BookCollectionModel bookCollection)
        {
            bookCollection.UserId = GetUserId();
            var entity = _mapper.Map<BookCollection>(bookCollection);
            entity = _bookCollectionDataService.Add(entity);
            var result = _mapper.Map<BookCollectionModel>(entity);

            return Ok(result);
        }

        [HttpPut]
        public IActionResult Update([FromBody] BookCollectionModel bookCollection)
        {
            if (bookCollection.UserId == GetUserId())
            {
                return BadRequest();
            }

            var entity = _mapper.Map<BookCollection>(bookCollection);
            entity = _bookCollectionDataService.Update(entity);
            var result = _mapper.Map<BookCollectionModel>(entity);

            return Ok(result);
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] BookCollectionModel bookCollection)
        {
            if (bookCollection.UserId != GetUserId())
            {
                return BadRequest();
            }

            var entity = _mapper.Map<BookCollection>(bookCollection);
            _bookCollectionDataService.Delete(entity);

            return Ok();
        }

        private string GetUserId() => HttpContext.User.Claims.ToList().Single(c => c.Type == "id").Value;
    }
}