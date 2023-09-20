using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp4_net6.Repository;

namespace WpfApp4_net6.ViewModels
{
    public class Layout1ViewModel
    {
        private readonly IProductModel _productModel;

        public string Title { get; set; }   

        public Layout1ViewModel (IProductModel productModel)
        {
            _productModel = productModel;

            Title = _productModel.GetFirst().Name;
        }



    }
}
