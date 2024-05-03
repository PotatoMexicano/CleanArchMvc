using AutoMapper;
using CleanArch.Application.DTOs;
using CleanArch.Application.Interfaces;
using CleanArch.Application.Products.Queries;
using CleanArch.Domain.Entities;
using MediatR;

namespace CleanArch.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ProductService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task Add(ProductDTO request)
        {
            throw new NotImplementedException("");
        }

        public async Task<ProductDTO> GetById(int id)
        {
            throw new NotImplementedException("");
        }

        public async Task<ProductDTO> GetProductCategory(int id)
        {
            throw new NotImplementedException("");
        }

        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            GetProductsQuery productsQuery = new GetProductsQuery();

            if (productsQuery == null)
            {
                throw new Exception($"Entity could not be loaded.");
            }

            IEnumerable<Product> result = await _mediator.Send(productsQuery);

            return _mapper.Map<IEnumerable<ProductDTO>>(result);
        }

        public async Task Remove(int id)
        {
            throw new NotImplementedException("");
        }

        public async Task Update(ProductDTO request)
        {
            throw new NotImplementedException("");
        }
    }
}
