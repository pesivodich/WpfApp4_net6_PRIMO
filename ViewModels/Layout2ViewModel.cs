using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp4_net6.Repository;

namespace WpfApp4_net6.ViewModels
{
    public class Layout2ViewModel
    {
        private readonly IUnitOfWork _unitOfWork;
        
        public TableShowDataViewModel TableShowDataViewModel { get; }

        public string Description_2 { get; set; }
        public Layout2ViewModel(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
            TableShowDataViewModel = new TableShowDataViewModel(_unitOfWork);
            Description_2 = _unitOfWork.Products.GetFirst().Name + "Layout 2";

        }
    }
}
