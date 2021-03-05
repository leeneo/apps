using Microsoft.EntityFrameworkCore;

namespace CCAS.Model
{
    public class AppDbContext : DbContext
    {

        //EF Core 2.0
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // 连接 SQLServer 实例
            //optionsBuilder.UseSqlServer(@"Server=.;Database=TestDb;uid=neo;pwd=123;Trusted_Connection=True;ConnectRetryCount=0");
            //optionsBuilder.UseSqlServer(@"Data Source=.;Initial Catalog=TestDb;User Id=neo;Password=123;");

            // 连接 MySql 实例，不支持“.”
            //optionsBuilder.UseMySql(@"Data Source=localhost;Port=3306;Initial Catalog=TestDb;User Id=root;Password=123;sslMode=None;Allow User Variables=True;");
            optionsBuilder.UseMySql(@"Server=localhost;Port=3306;Database=testdb;Uid=root;Pwd=123;charset=utf8;sslMode=None;Allow User Variables=True;");

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //创建实例
            builder.Entity<Users>().HasKey(b => b.Id);

            base.OnModelCreating(builder);
        }

        public virtual DbSet<Users> Users { get; set; }
    }
}