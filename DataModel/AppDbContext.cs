using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using WpfApp4_net6.Models;

namespace WpfApp4_net6.DataModel
{
    public class AppDbContext : DbContext
    {
        string connectionString = "server=localhost;port=3306;database=netcore_3;user=root;password=;";


        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        { }
        public DbSet<Product> Products { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<UserInfo> UserInfo { get; set; }

      

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
             .HasOne(e => e.Information)
             .WithOne(e => e.User)
             .HasForeignKey<User>(e => e.UserInfoId)
             .OnDelete(DeleteBehavior.NoAction);
        }

        /// <summary>
        /// Ghi đè phương thức lưu vào DB để lưu thêm các dữ liệu mặc định cần thiết
        /// <para>Created at: 20/09/2023</para>
        /// <para>Created by: SonNC</para>
        /// </summary>
        /// <returns>
        /// Số lượng record ảnh hưởng
        /// </returns>
        public override int SaveChanges()
        {
            try
            {
                OnBeforeSaving();
                return base.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Lưu thêm các thông tin cần thiết mặc định khi cập nhật dữ diệu vào Database.
        /// <para>Created at: 20/09/2023</para>
        /// <para>Created by: SonNC</para>
        /// </summary>
        private void OnBeforeSaving()
        {
            try
            {
                // Nếu có sự thay đổi dữ liệu
                if (ChangeTracker.HasChanges())
                {
                    // Láy các thông tin cơ bản từ hệ thống
                    DateTimeOffset now = DateTimeOffset.Now;
                    //int accountId = Convert.ToInt32(GetAccountId());
                    //string ip = GetRequestIp();
                    // Duyệt qua hết tất cả dối tượng có thay đổi
                    foreach (var entry in ChangeTracker.Entries())
                    {
                        try
                        {
                            if (entry.Entity is ITable root)
                            {
                                switch (entry.State)
                                {
                                    // Nếu là thêm mới thì cập nhật thông tin thêm mới
                                    case EntityState.Added:
                                        {

                                            root.CreatedAt = root.CreatedAt.ToString("yyyy") == "0001" ? now : root.CreatedAt;
                                            //root.CreatedBy = root.CreatedBy > 0 ? root.CreatedBy : accountId;
                                            //root.CreatedIp = ip;
                                            root.UpdatedAt = null;
                                            root.UpdatedBy = null;
                                            root.UpdatedIp = null;
                                            root.DelFlag = false;
                                            break;
                                        }
                                    // Nếu là update thì cập nhật các trường liên quan đến update
                                    case EntityState.Modified:
                                        {
                                            root.UpdatedAt = now;
                                            break;
                                        }
                                }
                            }
                        }
                        catch { }
                    }
                }
            }
            catch (DbUpdateException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    }
}
