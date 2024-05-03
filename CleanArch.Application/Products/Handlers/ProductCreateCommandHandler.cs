using CleanArch.Application.Products.Commands;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;
using MediatR;

namespace CleanArch.Application.Products.Handlers
{
    public class ProductCreateCommandHandler : IRequestHandler<ProductCreateCommand, Product>
    {
        private readonly IProductRepository _repository;

        public ProductCreateCommandHandler(IProductRepository productRepository)
        {
            _repository = productRepository;
        }

        public async Task<Product> Handle(ProductCreateCommand request, CancellationToken cancellationToken)
        {
            Product product = new Product(request.Name, request.Description, request.Price, request.Stock, request.Image);

            product.CategoryId = request.CategoryID;
            return await _repository.InsertAsync(product);

        }
    }
}
