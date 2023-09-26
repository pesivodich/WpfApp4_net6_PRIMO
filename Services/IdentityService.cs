using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp4_net6.Services
{
    public interface IIdentityService
    {
        string GetString();
    }

    public class IdentityService : IIdentityService 
    {
        public IdentityService() { }

        public string GetString()
        {
            return "Get String From IdentityService";
        }
    }

}
