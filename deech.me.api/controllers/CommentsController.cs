using AutoMapper;
using deech.me.data.entities;
using deech.me.logic.abstractions;
using deech.me.logic.models;
using Microsoft.AspNetCore.Mvc;

namespace deech.me.api.controllers
{
    [Route("[controller]")]
    public class CommentsController : ControllerBase
    {
        private readonly IWriteDataService<Comment> _writeDataService;
        public IMapper _mapper;
        public CommentsController(IWriteDataService<Comment> writeDataService, IMapper mapper)
        {
            this._mapper = mapper;
            this._writeDataService = writeDataService;
        }

        [HttpPost]
        public ActionResult AddComment(CommentModel comment)
        {
            var newComment = this._mapper.Map<Comment>(comment);
            newComment = this._writeDataService.Add(newComment);
            var result = this._mapper.Map<CommentModel>(newComment);
            return Ok(result);
        }
    }
}