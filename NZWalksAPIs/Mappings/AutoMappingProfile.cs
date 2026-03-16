using AutoMapper;
using NZWalksAPIs.Model.Domain;
using NZWalksAPIs.Model.DTO;
using System.Runtime;

namespace NZWalksAPIs.Mappings
{
    public class AutoMappingProfile : Profile
    {
        public AutoMappingProfile()
        {
            CreateMap<Regions,Regiondto>().ReverseMap();
            CreateMap<AddRegionRequestDto, Regions>().ReverseMap();
            CreateMap<Updateegiondto, Regions>().ReverseMap();
            CreateMap<Walks, AddWalkRequestdto>().ReverseMap();
            CreateMap<Walks,Walkdtos>().ReverseMap();
            CreateMap<Difficulty, Difficultydto>().ReverseMap();
            CreateMap<UpdateWalkRequestdto, Walks>().ReverseMap();
        }
    }
}
