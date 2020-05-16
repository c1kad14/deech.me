using System;
using System.Collections.Generic;
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

        [HttpGet("byParagraphId")]
        public ActionResult GetComments(int paragraphId)
        {
            var comments = this._writeDataService.GetAll(c => c.ParagraphId == paragraphId);
            var result = this._mapper.Map<List<CommentModel>>(comments);
            return Ok(result);
        }

        [HttpPost]
        public ActionResult AddComment([FromBody]CommentModel comment)
        {
            var newComment = this._mapper.Map<Comment>(comment);
            newComment = this._writeDataService.Add(newComment);
            var result = this._mapper.Map<CommentModel>(newComment);
            return Ok(result);
        }
    }
}