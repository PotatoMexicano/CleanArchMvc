using CleanArch.Application.Products.Commands;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;
using MediatR;

namespace CleanArch.Application.Products.Handlers
{
    public class ProductRemoveCommandHandler : IRequestHandler<ProductRemoveCommand, Product>
    {
        private readonly IProductRepository _repository;

        public ProductRemoveCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<Product> Handle(ProductRemoveCommand request, CancellationToken cancellationToken)
        {
            Product? product = await _repository.GetByIdAsync(request.Id);

            if (product == null)
            {
                return null;
            }

            Product result = await _repository.DeleteAsync(product);
            return result;
        }
    }
}
