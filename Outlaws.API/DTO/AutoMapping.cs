using System;
using AutoMapper;
using Outlaws.API.Models;

namespace Outlaws.API.DTO
{
    public class AutoMapping : Profile
    {
        public AutoMapping() {
            CreateMap<OutlawDTO, Outlaw>();
        }
    }
}
