using LoggerService.Logger;
using LoggerService.LoggerFactory;
using ProductService.Context;
using ProductService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductService
{
    public class ProductRepository : IProductRepository
    {
        IProductRepositoryContext _context;
        ILoggerFactory _loggerFactory;
        ILogger _logger;

        //After DI
        //public ProductRepository(IProductRepositoryContext context)
        //{
        //    _context = context;
        //}

        public ProductRepository()
        {
            _context = new ProductRepositoryContext();
            _loggerFactory = new SeriLogFactory();
            _logger = _loggerFactory.CreateLogger("ProductRepository");


        }
        public List<Product> GetAllProducts()
        {
            _logger.Debug("GetAllProducts method called");
            return _context.Products.ToList();
        }

        public List<Product> AddProuct(Product product)
        {
            _logger.Debug("AddProduct method called",new object[] { product});
            return _context.Add(product).ToList();
        }
    }
}
