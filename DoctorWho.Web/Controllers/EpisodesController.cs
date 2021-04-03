using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoctorWho.Db;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AutoMapper;
using DoctorWho.Web.Models;
using DoctorWho.Db.Contracts;

namespace DoctorWho.Web.Controllers
{
    [ApiController]
    [Route("api/episodes")]
    public class EpisodesController : ControllerBase
    {
        private readonly IEpisodeRepository _episodeRepository;
        private readonly IEpisodeEnemyRepository _episodeEnemyRepository;
        private readonly IEpisodeCompanionRepository _episodeCompanionRepository;
        private readonly IMapper _mapper;
        public EpisodesController(IEpisodeRepository episodeRepository,
        IEpisodeEnemyRepository episodeEnemyRepository,
        IEpisodeCompanionRepository episodeCompanionRepository,
        IMapper mapper)
        {
            _episodeRepository = episodeRepository ??
              throw new ArgumentNullException(nameof(EpisodeRepository));
            _episodeEnemyRepository = episodeEnemyRepository ??
              throw new ArgumentNullException(nameof(EpisodeEnemyRepository));
            _episodeCompanionRepository = episodeCompanionRepository ??
              throw new ArgumentNullException(nameof(EpisodeCompanionRepository));

            _mapper = mapper ??
              throw new ArgumentNullException(nameof(mapper));
        }

        [TypeFilter(typeof(Filters.AuthorizationFilter))]
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
        public ActionResult<EpisodeDto> CreateEpisode(EpisodeForCreationDto episode)
        {
            var episodeEntity = _mapper.Map<Episode>(episode);
            _episodeRepository.CreatEpisode(episodeEntity);
            var episodeDto = _mapper.Map<EpisodeDto>(episodeEntity);
            return CreatedAtRoute("GetEpisode",
            new { episodeId = episodeDto.EpisodeId },
            episodeDto);
        }

        [HttpPost("{episodeId}/enemies")]
        public ActionResult<EpisodeEnemyDto> AddEnemyToEpisode(int episodeId, EpisodeEnemyForCreationDto episodeEnemy)
        {
            if (_episodeRepository.GetEpisode(episodeId) == null)
                return NotFound();
            if (_episodeEnemyRepository.EpisodeEnemyExist(episodeEnemy.EnemyId, episodeId))
                return Conflict();
            var episodeEnemyEntity = _mapper.Map<EpisodeEnemy>(episodeEnemy);
            episodeEnemyEntity.EpisodeId = episodeId;
            _episodeEnemyRepository.AddEnemyToEpisode(episodeEnemyEntity.EnemyId, episodeEnemyEntity.EpisodeId);
            var episodeEnemyDto = _mapper.Map<EpisodeEnemyDto>(episodeEnemyEntity);
            return Ok(episodeEnemyDto);
        }

        [HttpPost("{episodeId}/companions")]
        public ActionResult<EpisodeCompanionDto> AddCompanionToEpisode(int episodeId, EpisodeCompanionForCreationDto episodeCompanion)
        {
            if (_episodeRepository.GetEpisode(episodeId) == null)
                return NotFound();
            if (_episodeCompanionRepository.EpisodeCompanionExist(episodeCompanion.CompanionId, episodeId))
                return Conflict();
            var episodeCompanionEntity = _mapper.Map<EpisodeCompanion>(episodeCompanion);
            episodeCompanionEntity.EpisodeId = episodeId;
            _episodeCompanionRepository.AddCompanionToEpisode(episodeCompanionEntity.CompanionId, episodeCompanionEntity.EpisodeId);
            var episodeCompanionDto = _mapper.Map<EpisodeCompanionDto>(episodeCompanionEntity);
            return Ok(episodeCompanionDto);
        }
    }
}
