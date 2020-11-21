using ProductService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductService
{
    public interface IProductRepository
    {
        List<Product> GetAllProducts();
        List<Product> AddProuct(Product product);
    }
}
