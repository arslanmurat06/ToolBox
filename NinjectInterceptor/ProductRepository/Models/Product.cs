using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.Models
{
    public class Product
    {
        public Guid ID { get;} = Guid.NewGuid();
        public string ProductName { get; set; }
    }
}
