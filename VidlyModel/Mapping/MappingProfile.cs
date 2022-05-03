using AutoMapper;
using VidlyModel.Dto;
using VidlyModel.Models;

namespace VidlyModel.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Customer, CustomerDto>();
        CreateMap<CustomerDto, Customer>();
        CreateMap<Movie, MovieDto>();
        CreateMap<MovieDto, Movie>();
    }
}