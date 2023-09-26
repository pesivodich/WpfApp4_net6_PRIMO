using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp4_net6.Repository;

namespace WpfApp4_net6.ViewModels
{
    public class TableShowDataViewModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public string TitleTableShow { get; set; } = "Button 1";
        public TableShowDataViewModel (IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            TitleTableShow = _unitOfWork.Products.GetFirst().Name;
        }
    }
}
