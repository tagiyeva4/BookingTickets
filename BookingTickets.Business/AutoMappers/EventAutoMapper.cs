using AutoMapper;
using BookingTickets.Business.Dtos.EventDtos;
using BookingTickets.Core.Entities;

namespace BookingTickets.Business.AutoMappers;

public class EventAutoMapper:Profile
{
    public EventAutoMapper()
    {

        CreateMap<Event,EventCreateDto>()
            .ForMember(x=>x.EventLanguageIds,x=>x.MapFrom(x=>x.EventLanguages.Select(x=>x.LanguageId)))
            .ReverseMap();

        //CreateMap<Event,EventUpdateDto>()
        //    .ForMember(x => x.EventLanguageIds, x => x.MapFrom(x => x.EventLanguages.Select(x => x.LanguageId)))
        //    .ReverseMap();
        CreateMap<Event, EventUpdateDto>()
          .ForMember(dest => dest.EventLanguageIds, opt => opt.MapFrom(src => src.EventLanguages.Select(el => el.LanguageId)))
          .ForMember(dest => dest.EventImages, opt => opt.MapFrom(src => src.EventImages.Select(img => img.ImagePath)))
          .ReverseMap() // EventUpdateDto -> Event mapping
          .ForMember(dest => dest.EventLanguages, opt => opt.Ignore()) // Manuel doldurulacaq
          .ForMember(dest => dest.EventImages, opt => opt.MapFrom(src => src.EventImages != null
              ? src.EventImages.Select(img => new EventImage { ImagePath = img }).ToList()
              : new List<EventImage>()))
          .ForMember(dest => dest.Venue, opt => opt.Ignore()); // Venue-lar ayrıca map ediləcək


        CreateMap<Event, EventReturnDto>()
            .ForMember(x=>x.EventLanguages,x=>x.MapFrom(x=>x.EventLanguages.Select(x=>x.Language)));
       

        // CreateMap<Venue, VenueDtoInEvent>().ReverseMap();

        CreateMap<Language, LanguageDtoInEvent>().ReverseMap();
    }
}
