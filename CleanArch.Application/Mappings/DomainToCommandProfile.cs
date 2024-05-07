using AutoMapper;
using CleanArch.Application.DTOs;
using CleanArch.Application.Products.Commands;

namespace CleanArch.Application.Mappings
{
    public class DomainToCommandProfile : Profile
    {
        public DomainToCommandProfile()
        {
            CreateMap<ProductDTO, ProductCreateCommand>();
            CreateMap<ProductDTO, ProductUpdateCommand>();
        }
    }
}
