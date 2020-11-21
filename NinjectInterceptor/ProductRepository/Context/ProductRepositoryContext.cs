using ProductService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.Context
{
    public class ProductRepositoryContext: IProductRepositoryContext, IDisposable
    {

        Dictionary<Guid, Product> _productInMemoryContext;

        public ProductRepositoryContext()
        {
            _productInMemoryContext = new Dictionary<Guid, Product>();
        }

        public IEnumerable<Product> Add(Product product)
        {
            _productInMemoryContext.Add(product.ID,product);
            return _productInMemoryContext.Values;
        }


        public bool Remove(Product product)
        {
            _productInMemoryContext.TryGetValue(product.ID, out Product removedProduct);

            if(removedProduct != null)
            {
                _productInMemoryContext.Remove(removedProduct.ID);
                return true;
            }
            return false;
        }

        public bool Update(Product product)
        {
            _productInMemoryContext.TryGetValue(product.ID, out Product updatedProduct);
            if (updatedProduct != null)
            {
                _productInMemoryContext.Remove(product.ID);
                _productInMemoryContext.Add(product.ID, product);
                return true;
            }
            return false;
        }

        IEnumerable<Product> IProductRepositoryContext.Products => _productInMemoryContext.Values;

        public void Dispose()
        {
            _productInMemoryContext.Clear();
            _productInMemoryContext = null;
        }
    
    }
}
