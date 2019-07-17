using Microsoft.EntityFrameworkCore;

namespace CCAS.Models
{
    public class Db : DbContext
    {
        //EF Core 2.0
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // 在SQLLocalDb 上创建实例
            //optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database =BestStoreDB;Trusted_Connection=True;ConnectRetryCount=0");

            // 在SQLServer 上创建实例
            //optionsBuilder.UseSqlServer(@"Data Source=.;Initial Catalog=BestStoreDB;User Id=leeneo;Password=leeneo;");
            optionsBuilder.UseSqlServer(@"Data Source=.;Initial Catalog=Test;User Id=leeneo;Password=for.net;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //创建实例
            builder.Entity<User>().HasKey(b => b.Userid);

            base.OnModelCreating(builder);
        }

        public DbSet<User> User { get; set; }
    }
}