using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using WpfApp4_net6.Repository;

namespace WpfApp4_net6.Models
{
    public class BaseModel
    {
        protected readonly AppDbContext _context;
        string connectionString = "server=localhost;port=3306;database=netcore_2;user=root;password=;";

        public BaseModel()
        {
            var dbContextOptions = new DbContextOptionsBuilder<AppDbContext>()
                .UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
                .Options;


            _context = new AppDbContext(dbContextOptions);
        }
    }
}