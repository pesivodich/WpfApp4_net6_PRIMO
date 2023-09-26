using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp4_net6.Services
{

    public interface IHelper
    {

    }
    public class Helper : IHelper
    {
        private readonly IIdentityService _identityService;
        public Helper(IIdentityService identityService) 
        {
            _identityService = identityService;
        }
    }
}
