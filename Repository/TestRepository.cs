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
        int AddNewProduct(TestWorkModel input);

        int RemoveProduct(int Id);

        int UpdateProduct(int Id, TestWorkModel input);

        TestTable GetFirst(int Id);
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

        public int AddNewProduct(TestWorkModel input)
        {
            if (input == null) { return 500; }

            _context.Tests.Add(new TestTable() 
            {
                Name = input.Name,
                Des = input.Des
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

        public int UpdateProduct (int Id, TestWorkModel input)
        {
            var EntityUpdate = _context.Tests.FirstOrDefault(x => x.Id == Id);
            EntityUpdate.Name = input.Name;
            EntityUpdate.Des = input.Des;
            _context.SaveChanges(); 

            return 200;
        }

        public TestTable GetFirst(int Id)
        {
            return _context.Tests.FirstOrDefault( x=> x.Id == Id );
        
        }
    }
}
