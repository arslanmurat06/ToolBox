using ProductService;
using ProductService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinjectInterceptor
{
    class Program
    {
        static IProductRepository _repository;
        static void Main(string[] args)
        {
            _repository = new ProductRepository();

            var mockProduct = new Product {ProductName="Shoe" };
            var mockProduct1 = new Product {ProductName="SweatShirt" };
            var mockProduct2 = new Product {ProductName="Jeans" };

            _repository.AddProuct(mockProduct2);
            _repository.AddProuct(mockProduct);
            _repository.AddProuct(mockProduct1);

            var allProducts = _repository.GetAllProducts();

            allProducts.ForEach((item) => Console.WriteLine($"ID:{item.ID} Name:{item.ProductName}"));

            Console.ReadLine();

        }
    }
}
