using AutoMapper;
using BookingTickets.Business.Dtos.BlogDtos;
using BookingTickets.Core.Entities;

namespace BookingTickets.Business.AutoMappers;

internal class BlogAutoMapper : Profile
{
    public BlogAutoMapper()
    {
        CreateMap<Blog, BlogCreateDto>().ReverseMap();
        CreateMap<Blog, BlogUpdateDto>().ReverseMap().ForMember(x => x.BlogImages, x => x.Ignore());
        CreateMap<Blog, BlogReturnDto>();
    }
}
