using System.Collections.Concurrent;
using AutoMapper;
using DoctorWho.Web.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoctorWho.Db;

namespace DoctorWho.Web.Profiles
{
    public class EpisodesProfile : Profile
    {
        public EpisodesProfile()
        {
            CreateMap<Episode, Models.EpisodeDto>();
            CreateMap<Models.EpisodeForCreationDto, Episode>();
        }
    }
}
