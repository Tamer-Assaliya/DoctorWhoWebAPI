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
    public class DoctorsProfile : Profile
    {
        public DoctorsProfile()
        {
            CreateMap<Doctor, Models.DoctorDto>()
                .ForMember(
                    dest => dest.Age,
                    opt => opt.MapFrom(src => src.BirthDate.GetCurrentAge()));
            //datetimeoffset???
            ;
        }
    }
}
