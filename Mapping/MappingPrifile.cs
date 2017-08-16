using AutoMapper;
using vega.Controllers.Resources;
using vega.Models;

namespace vega.Mapping
{
    public class MappingPrifile : Profile
    {
        public MappingPrifile()
        {
             CreateMap<Make,MakeResource>();
             CreateMap<Model,ModelResource>();
        }
    }
}