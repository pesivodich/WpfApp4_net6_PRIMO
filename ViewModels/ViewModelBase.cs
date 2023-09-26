using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp4_net6.Repository;

namespace WpfApp4_net6.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        protected readonly IUnitOfWork _unitOfWork;

        public ViewModelBase()
        {
           
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
