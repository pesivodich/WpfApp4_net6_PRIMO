using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using tblProduct = WpfApp4_net6.Repository.Product;

namespace WpfApp4_net6.Models
{

    public interface IProductModel
    {
        List<tblProduct> GetList();
        int AddNewProduct(tblProduct product);
    }

    public class ProductModel : BaseModel, IProductModel
    {

        public ProductModel()
        {

        }
        public List<tblProduct> GetList()
        {
            List<tblProduct> restult = _context.Products.ToList();

            return restult;
        }

        public int AddNewProduct (tblProduct product) 
        {
            _context.Add(product);  

           _context.SaveChanges();


            return 200;
        }

    }

  
}
