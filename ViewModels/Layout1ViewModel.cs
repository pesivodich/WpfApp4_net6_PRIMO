using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp4_net6.Models;
using WpfApp4_net6.Repository;
using WpfApp4_net6.Views;

namespace WpfApp4_net6.ViewModels
{
    public class Layout1ViewModel
    {
       
        public string Title { get; set; }

        public ObservableCollection<People> Peoples { get; set; }

        public Layout1ViewModel ()
        {
            Peoples = new ObservableCollection<People>()
            {
                new People()
                {
                    Name = "Son",
                    Age = 1,
                    Address = "83 Mai An Tiem"
                },
                new People()
                {
                    Name = "Pepsi",
                    Age = 4,
                    Address = "83 Mai An Tiem"
                },
                new People()
                {
                    Name = "Hoang MInh",
                    Age = 4,
                    Address = "83 Mai An Tiem"
                },
                new People()
                {
                    Name = "Hoang Ni",
                    Age = 1,
                    Address = "83 Mai An Tiem"
                },
            };
        }



    }
}
