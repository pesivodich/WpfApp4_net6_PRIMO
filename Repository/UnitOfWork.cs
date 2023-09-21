using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp4_net6.DataModel;

namespace WpfApp4_net6.Repository
{
    public interface IUnitOfWork
    {
        IProductRepository Products { get; }
        IUserRepository Users { get; }
        void SaveChanges();
    }

    public class UnitOfWork : BaseRepository, IUnitOfWork
    {

        public UnitOfWork()
        {
            Products = new ProductRepository();
            Users = new UserRepository();
        }

        public IProductRepository Products { get; private set; }
        public IUserRepository Users { get; private set; }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }

}
