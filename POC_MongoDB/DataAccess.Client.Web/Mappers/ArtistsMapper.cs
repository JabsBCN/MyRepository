using AutoMapper;
using DataAccess.BackEnd;
using DataAccess.Client.Web.Models;

namespace DataAccess.Client.Web.Mappers
{
    public class ArtistsMapper : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Artists, ArtistsViewModel>()
                .ForMember(a => a.Id, map => map.MapFrom(m => m._id))
                .ForMember(a => a.Name, map => map.MapFrom(m => m.name))
                .ForMember(a => a.Style, map => map.MapFrom(m => m.style))
                .ForMember(a => a.Year, map => map.MapFrom(m => m.year));
        }
    }
}