using System;
using AutoMapper;
using ProjectBackendDevelopment.Models;

namespace ProjectBackendDevelopment.DTO
{
    public class AutoMapping : Profile
    {
        public AutoMapping() {
            CreateMap<OutlawDTO, Outlaw>();
        }
    }
}
