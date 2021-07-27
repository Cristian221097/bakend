using AutoMapper;
using miPropiedad.data;
using miPropiedad.Dtos;
using miPropiedad.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace miPropiedad.Mappings
{
    public class AutoMappersProfile : Profile
    {
        public AutoMappersProfile()
        {
            CreateMap<Propiedad, PropiedadDtos>().ReverseMap();
            CreateMap<Foto, FotoDtos>();
        }
    }
}
