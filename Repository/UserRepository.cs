using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp4_net6.DataModel;

namespace WpfApp4_net6.Repository
{
    public interface IUserRepository
    {
        string GetUser();
    }
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository()
        {
          
        }

        public string GetUser()
        {
            return _context.Products.FirstOrDefault().Des;
        }

    }
}
