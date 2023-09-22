using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp4_net6.Models;
using WpfApp4_net6.Repository;

namespace WpfApp4_net6.ViewModels
{
    public class Layout1ViewModel
    {
       
        public string Title { get; set; }

        private ObservableCollection<Product> products { get; set; }

        public Layout1ViewModel ()
        {
           
        }



    }
}
