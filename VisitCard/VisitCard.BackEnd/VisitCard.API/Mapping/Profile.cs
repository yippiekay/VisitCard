using System.Text;
using AutoMapper;
using VisitCard.API.Models.Card;
using VisitCard.BLL.ModelsDto;
using VisitCard.DAL.Models;

namespace VisitCard.API.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Card, CardDto>().ReverseMap();
            CreateMap<CardDto, CardViewModel>()
                .ForMember(d => d.ImageByteCode, c => c.MapFrom(s => Encoding.ASCII.GetString(s.ImageByteCode)));
            CreateMap<UpdateCurrentModel, CardDto>()
                .ForMember(d => d.ImageByteCode, 
                    c => c.MapFrom(s => Encoding.ASCII.GetBytes(s.ImageByteCode)));
        }
    }
}