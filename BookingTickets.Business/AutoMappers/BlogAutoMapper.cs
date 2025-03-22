using AutoMapper;
using BookingTickets.Business.Dtos.BlogDtos;
using BookingTickets.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingTickets.Business.AutoMappers
{
    public class BlogAutoMapper : Profile
    {
        public BlogAutoMapper()
        {
            CreateMap<Blog, BlogCreateDto>().ReverseMap();
            CreateMap<Blog, BlogUpdateDto>().ReverseMap().ForMember(x => x.BlogImages, x => x.Ignore());
            CreateMap<Blog, BlogReturnDto>();
        }
    }
}
