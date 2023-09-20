using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp4_net6.Models.WorkModels;

namespace WpfApp4_net6.Repository
{
    public interface IProductModel
    {
        public List<ProductWorkModel> GetList();

        public ProductWorkModel GetFirst();
    }
}
