using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp4_net6.Models;
using WpfApp4_net6.Models.WorkModels;

namespace WpfApp4_net6.Repository
{
    public interface ITestRepository
    {
        List<TestTable> GetList();
        int AddNewProduct();

        int RemoveProduct(int Id);
    }
    public class TestRepository : BaseRepository, ITestRepository
    {
        public TestRepository()
        {

        }


        public List<TestTable> GetList()
        {
          List<TestTable> restult = _context.Tests.ToList();

            return restult;
        }

        public int AddNewProduct()
        {
          
            _context.Tests.Add(new TestTable() 
            {
                Name = "Test_11",
                Des = "Des_22"
            });
            _context.SaveChanges();

            return 200;
        }


        public int RemoveProduct(int Id)
        {
            var EntityRemove = _context.Tests.FirstOrDefault(x => x.Id == Id);
            _context.Tests.Remove(EntityRemove);
            _context.SaveChanges();

            return 200;
        }
    }
}
