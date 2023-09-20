using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp4_net6.Models.WorkModels;

namespace WpfApp4_net6.Repository
{
    public class ProductModel : BaseRepository, IProductModel
    {

        public ProductModel()
        {

        }
        public List<ProductWorkModel> GetList()
        {
            List<ProductWorkModel> restult = _context.Products.Select( x=> new ProductWorkModel() 
            {
                ProductId = x.ProductId,
                Name = x.Name,
                Price = x.Price,
                HoangMinh = x.HoangMinh
            }
            ).ToList();

            return restult;
        }

        public ProductWorkModel GetFirst()
        {
            ProductWorkModel restult = _context.Products.Select(x => new ProductWorkModel()
            {
                ProductId = x.ProductId,
                Name = x.Name,
                Price = x.Price,
                HoangMinh = x.HoangMinh
            }
           ).First();

            return restult;
        }

    }

  
}
