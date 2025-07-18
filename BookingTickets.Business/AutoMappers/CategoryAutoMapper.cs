﻿using AutoMapper;
using BookingTickets.Business.Dtos.CategoryDtos;
using BookingTickets.Core.Entities;

namespace BookingTickets.Business.AutoMappers;

internal class CategoryAutoMapper : Profile
{
    public  CategoryAutoMapper()
    {
        CreateMap<Category, CategoryCreateDto>().ReverseMap();
        CreateMap<Category, CategoryUpdateDto>().ReverseMap();
        CreateMap<Category, CategoryReturnDto>();
    }
}
