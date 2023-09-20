using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using WpfApp4_net6.DataModel;

namespace WpfApp4_net6.Repository
{
    public class BaseRepository
    {
        protected readonly AppDbContext _context;
        string connectionString = "server=localhost;port=3306;database=netcore_3;user=root;password=;";

        public BaseRepository()
        {
            var dbContextOptions = new DbContextOptionsBuilder<AppDbContext>()
                .UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
                .Options;


            _context = new AppDbContext(dbContextOptions);
        }
    }
}