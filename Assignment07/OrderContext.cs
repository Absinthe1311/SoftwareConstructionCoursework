using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity; // 引入Entity Framework命名空间
using MySql.Data.EntityFramework;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Runtime.Remoting.Contexts;
namespace Assignment7
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class OrderContext : DbContext
    {
        //数据库中的Order表
        public DbSet<Order> Orders { get; set; }
        //数据库中的Customer表
        public DbSet<Customer> Customers { get; set; }
        //数据库中的OrderDetails表
        public DbSet<OrderDetail> OrderDetails { get; set; }
        //数据库中的Product表
        public DbSet<Goods> Goods { get; set; }

        public OrderContext() : base("OrderDataBase")//连接字符串名称为OrderDataBase
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<OrderContext>()); // 如果模型发生变化，则删除数据库并重新创建
        }
    }
}
