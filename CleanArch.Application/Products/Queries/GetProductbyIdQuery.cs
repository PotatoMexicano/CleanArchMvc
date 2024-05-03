using CleanArch.Domain.Entities;
using MediatR;

namespace CleanArch.Application.Products.Queries
{
    public class GetProductbyIdQuery : IRequest<Product>
    {
        public int Id { get; set; }

        public GetProductbyIdQuery(int id)
        {
            Id = id;
        }
    }
}
