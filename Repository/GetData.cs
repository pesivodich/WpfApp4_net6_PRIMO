using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp4_net6.Repository
{
    public interface IDataAccess
    {
        public string GetTitle();
    }
    public class DataAccess : IDataAccess
    {
        //private readonly String _name;
        //private readonly string _lastname;

        //private readonly string _age;

        public DataAccess( )
        {
         
        }
        
        public string GetTitle()
        {
            return "Hoang Minh Hay Bi Me La";
        }

    }
}
