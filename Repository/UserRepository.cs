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
        //private readonly AppDbContext _context;
        string connectionString = "server=localhost;port=3306;database=netcore_2;user=root;password=;";

        public UserRepository()
        {
            //var dbContextOptions = new DbContextOptionsBuilder<AppDbContext>()
            //   .UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
            //   .Options;


            //_context = new AppDbContext(dbContextOptions);
        }

        public string GetUser()
        {
            return _context.Products.FirstOrDefault().Des + "Tu Lop Users";
        }

    }
}
