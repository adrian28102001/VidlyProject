using AutoMapper;
using VidlyModel.Dto;
using VidlyModel.Models;

namespace VidlyModel.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Customer, CustomerDto>();
        CreateMap<Movie, MovieDto>();
        CreateMap<MembershipType, MembershipTypeDto>();


        // Dto to Domain
        CreateMap<CustomerDto, Customer>()
            .ForMember(c => c.Id, opt => opt.Ignore());

        CreateMap<MovieDto, Movie>()
            .ForMember(c => c.Id, opt => opt.Ignore());
    }
}