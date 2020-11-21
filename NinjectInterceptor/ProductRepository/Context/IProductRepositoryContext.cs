using ProductService.Models;
using System.Collections.Generic;

namespace ProductService.Context
{
    public interface IProductRepositoryContext
    {
        IEnumerable<Product> Products { get; }
        IEnumerable<Product> Add(Product product);
        bool Remove(Product product);
        bool Update(Product product);
    }
}