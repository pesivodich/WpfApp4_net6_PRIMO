using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp4_net6.Repository
{
    public interface IDataAccess
    {
         string GetTitle();
    }
    public class DataAccess : IDataAccess
    {
        

       public DataAccess() : base()
        {

        }

        
        public string GetTitle()
        {
            return "";
        }

    }
}
