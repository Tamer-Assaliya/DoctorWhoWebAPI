using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoctorWho.Db;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AutoMapper;
using DoctorWho.Web.Models;

namespace DoctorWho.Web.Controllers
{
    [ApiController]
    [Route("api/episodes")]
    public class EpisodesController : ControllerBase
    {
        private readonly EpisodeRepository _episodeRepository;
        private readonly IMapper _mapper;
        public EpisodesController(EpisodeRepository episodeRepository, IMapper mapper)
        {
            _episodeRepository = episodeRepository ??
              throw new ArgumentNullException(nameof(EpisodeRepository));
            _mapper = mapper ??
              throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet(Name = "GetEpisodes")]
        [HttpHead]
        public ActionResult<IEnumerable<EpisodeDto>> GetAllEpisodes()
        {
            var episodeFromRepo = _episodeRepository.GetAllEpisodes();
            return Ok(_mapper.Map<IEnumerable<EpisodeDto>>(episodeFromRepo));
        }

        [HttpGet("{episodeId}", Name = "GetEpisode")]
        public ActionResult<EpisodeDto> GetEpisode(int episodeId)
        {
            var episodeFromRepo = _episodeRepository.GetEpisode(episodeId);
            if (episodeFromRepo == null)
                return NotFound();
            return Ok(_mapper.Map<EpisodeDto>(episodeFromRepo));
        }

        [HttpPost()]
        public ActionResult<EpisodeDto> CreateEpisode(int episodeId, EpisodeForCreationDto episode)
        {
            var episodeEntity = _mapper.Map<Episode>(episode);
            _episodeRepository.CreatEpisode(episodeEntity);
            var episodeDto = _mapper.Map<EpisodeDto>(episodeEntity);
            return CreatedAtRoute("GetEpisode",
            new { episodeId = episodeDto.EpisodeId },
            episodeDto);
        }
    }
}
