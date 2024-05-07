using AutoMapper;
using CleanArch.Application.DTOs;
using CleanArch.Application.Interfaces;
using CleanArch.Application.Products.Commands;
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
            ProductCreateCommand productQuery = _mapper.Map<ProductCreateCommand>(request);
            await _mediator.Send(productQuery);
        }

        public async Task<ProductDTO> GetById(int id)
        {
            GetProductbyIdQuery productQuery = new GetProductbyIdQuery(id);
            Product result = await _mediator.Send(productQuery);
            return _mapper.Map<ProductDTO>(result);
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
            ProductRemoveCommand productQuery = new ProductRemoveCommand(id);
            Product result = await _mediator.Send(productQuery);
        }

        public async Task Update(ProductDTO request)
        {
            ProductUpdateCommand productQuery = _mapper.Map<ProductUpdateCommand>(request);
            Product result = await _mediator.Send(productQuery);
        }
    }
}
