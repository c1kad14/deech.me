using System.Collections.Generic;
using System.Linq;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using deech.me.data.entities;
using deech.me.logic.abstractions;
using deech.me.logic.models;

using AutoMapper;

namespace deech.me.api.controllers
{
    [Route("[controller]")]
    public class TitleInfoController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IReadDataService<TitleInfo> _readDataService;

        public TitleInfoController(IReadDataService<TitleInfo> readDataService, IMapper mapper)
        {
            this._readDataService = readDataService;
            this._mapper = mapper;
        }

        [HttpGet("byTitle")]
        public ActionResult GetByTitle(string title)
        {
            this._readDataService.SetIncludeFunc(i => i.Include(ti => ti.Authors)
                                                       .ThenInclude(tia => tia.Author)
                                                       .Include(ti => ti.Genres)
                                                       .Include(ti => ti.Annotation)
                                                       .Include(ti => ti.Translators)
                                                       .ThenInclude(tit => tit.Translator)
                                                       .Include(ti => ti.SourceLanguage)
                                                       .Include(ti => ti.Language)
                                                       .Include(ti => ti.Keywords));
            var result = this._readDataService.GetMultiple(t => t.Title.ToLower().Contains(title.ToLower().Trim()));
            var mapped = this._mapper.Map<List<TitleInfo>, List<TitleInfoModel>>(result);

            return Ok(mapped);
        }

        [HttpGet("byId")]
        public ActionResult GetById(int id)
        {
            this._readDataService.SetIncludeFunc(i => i.Include(ti => ti.Authors)
                                                       .ThenInclude(tia => tia.Author)
                                                       .Include(ti => ti.Genres)
                                                       .Include(ti => ti.Annotation)
                                                       .Include(ti => ti.Translators)
                                                       .ThenInclude(tit => tit.Translator)
                                                       .Include(ti => ti.SourceLanguage)
                                                       .Include(ti => ti.Language)
                                                       .Include(ti => ti.Keywords));

            var result = this._readDataService.GetSingle(t => t.Id == id);

            return Ok(result);
        }

        [HttpGet("byGenre")]
        public ActionResult GetByGenre(string genre)
        {
            this._readDataService.SetIncludeFunc(i => i.Include(ti => ti.Genres));

            var result = this._readDataService.GetMultiple(t => t.Genres.Any(g => g.GenreCode == genre));

            return Ok(result);
        }
    }
}