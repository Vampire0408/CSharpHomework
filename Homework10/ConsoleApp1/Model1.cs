using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()  : base("Model1")
        {
        }

        public DbSet<order> order { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }
    }
}
