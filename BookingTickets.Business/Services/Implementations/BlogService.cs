using AutoMapper;
using BookingTickets.Business.Dtos.BlogDtos;
using BookingTickets.Business.Exceptions;
using BookingTickets.Business.Helpers;
using BookingTickets.Business.Services.Abstractions;
using BookingTickets.Core.Entities;
using BookingTickets.DataAccess.Repositories.Abstractions;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BookingTickets.Business.Services.Implementations;

public class BlogService :IBlogService
{
   private IBlogRepository _repository;
    private readonly IMapper _mapper;
    private readonly ICloudinaryService _cloudinaryService;
    public BlogService(IBlogRepository repository, IMapper mapper, ICloudinaryService cloudinaryService = null)
    {
        _repository = repository;
        _mapper = mapper;
        _cloudinaryService = cloudinaryService;
    }

    public async Task<bool> CreateAsync(BlogCreateDto dto, ModelStateDictionary ModelState)
    {
        if (!ModelState.IsValid)
        {
            return false;
        }

        foreach (var formFile in dto.Photos)
        {
            if (formFile.CheckSize(5 * 1024 * 1024))
            {
                ModelState.AddModelError("Photo", "The size of the image should not exceed 2 MB.");
                return false;
            }

            if (formFile.CheckType(["image/"]))
            {
                ModelState.AddModelError("Photo", "Enter only the image format.");
                return false;
            }
        }

        var blog = _mapper.Map<Blog>(dto);

        blog.BlogImages = [];

        foreach (var file in dto.Photos)
        {
            string imagePath = await _cloudinaryService.FileCreateAsync(file);
            BlogImage image = new() { ImagePath = imagePath };
            blog.BlogImages.Add(image);
        }

        await _repository.AddAsync(blog);

        return true;
    }

    public async Task DeleteAsync(int id)
    {
        var blog = await _repository.FindOneAsync(x => x.Id == id, "BlogImages");
        if (blog == null)
        {
            throw new CustomException(404, "Blog not found");
        }
        await _repository.DeleteAsync(blog);
    }

    public async Task<List<BlogReturnDto>> GetAllAsync()
    {
        var blogs = await _repository.GetAllAsync("BlogImages");
        
        var dtos = _mapper.Map<List<BlogReturnDto>>(blogs);

        return dtos;
    }

    public async Task<bool> UpdateAsync(BlogUpdateDto dto, ModelStateDictionary ModelState)
    {
        if (!ModelState.IsValid)
        {
            return false;
        }
        var existBlog=await _repository.FindOneAsync(x=> x.Id == dto.Id, "BlogImages");
        if (existBlog == null)
        {
            throw new CustomException(404, "Blog not found");
        }
        if (dto.Photos != null)
        {
            foreach (var formFile in dto.Photos)
            {
                if (formFile.CheckSize(5 * 1024 * 1024))
                {
                    ModelState.AddModelError("Photos", "The size of the image should not exceed 2 MB.");
                    return false;
                }

                if (formFile.CheckType(["image/"]))
                {
                    ModelState.AddModelError("Photos", "Enter only the image format.");
                    return false;
                }
            }
        }

        existBlog = _mapper.Map(dto,existBlog);
        
        var imagesToRemove = existBlog.BlogImages?.ToList() ?? new List<BlogImage>();

        foreach (var image in imagesToRemove)
        {
            existBlog.BlogImages.Remove(image);
            await _cloudinaryService.FileDeleteAsync(image.ImagePath);
        }
        
        if (dto.Photos != null && dto.Photos.Any())
        {
            foreach (var newImage in dto.Photos)
            {
                string newImagePath = await _cloudinaryService.FileCreateAsync(newImage);
                BlogImage blogImage = new() { ImagePath = newImagePath };
                existBlog.BlogImages.Add(blogImage);
            }
        }

        await _repository.UpdateAsync(existBlog);
        return true;
    }

    public async Task<BlogUpdateDto> GetUpdatedDtoAsync(int id)
    {
        var blog=await _repository.FindOneAsync(x=> x.Id == id, "BlogImages");
        if(blog == null)
        {
            throw new CustomException(404, "Blog not found");
        }
        var dto=_mapper.Map<BlogUpdateDto>(blog);
        return dto;
    }

    public async Task<BlogReturnDto> GetAsync(int id)
    {
        var blog = await _repository.FindOneAsync(x => x.Id == id, "BlogImages");
        if (blog == null)
        {
            throw new CustomException(404, "Blog not found");
        }
        var dto=_mapper.Map<BlogReturnDto>(blog);
        return dto;

    }
}
