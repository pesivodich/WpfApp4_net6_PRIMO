using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp4_net6.Models.WorkModels;
using tblProduct = WpfApp4_net6.Models.Product;

namespace WpfApp4_net6.Repository
{
    public interface IProductRepository
    {
        public List<ProductWorkModel> GetList();

        public ProductWorkModel GetFirst();

        public int AddNewProduct(ProductWorkModel product);
        public string GetFirstNameRandom();
    }
    public class ProductRepository : BaseRepository, IProductRepository
    {

        public ProductRepository()
        {

        }
        public List<ProductWorkModel> GetList()
        {
            List<ProductWorkModel> restult = _context.Products.Select( x=> new ProductWorkModel() 
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Des,
                Price = x.Price,
                Username = x.Username
            }
            ).ToList();

            return restult;
        }

        public ProductWorkModel GetFirst()
        {
            ProductWorkModel restult = _context.Products.Select(x => new ProductWorkModel()
            {
                Name = x.Name,
                Price = x.Price,
                Username = x.Username
            }
           ).First();

            return restult;
        }


        public string GetFirstNameRandom()
        {
            string restult = _context.Products.First().Name + "Get From Product";

            return restult;
        }


        public int AddNewProduct (ProductWorkModel product)
        {
            if (product == null) {
                return 500;   
            }

            tblProduct newProduct = new tblProduct()
            {
                Name = product.Name,    
                Price = product.Price,
                Des = product.Description,
                Username = product.Username
            };

            _context.Products.Add(newProduct);
            _context.SaveChanges();

            return 200;
        }

    }

  
}
