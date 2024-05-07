using CleanArch.Application.Products.Commands;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;
using MediatR;

namespace CleanArch.Application.Products.Handlers
{
    public class ProductUpdateCommandHandler : IRequestHandler<ProductUpdateCommand, Product>
    {
        private readonly IProductRepository _repository;

        public ProductUpdateCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<Product> Handle(ProductUpdateCommand request, CancellationToken cancellationToken)
        {
            Product? product = await _repository.GetByIdAsync(request.Id);

            if (product == null)
            {
                return null;
            }

            product.Update(request.Name, request.Description, request.Price, request.Stock, request.Image, request.CategoryId);


            return await _repository.UpdateAsync(product);
        }
    }
}
