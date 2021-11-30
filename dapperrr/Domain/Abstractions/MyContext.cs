
using dapperrr.Mapping;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dapperrr.Domain.Abstractions
{
    public class MyContext : DbContext
    {
        public MyContext() : base("StoreDb")
        {
            //if your db in other location
            //this.Database.Connection.ConnectionString = ConfigurationManager.ConnectionStrings["MyConnString"].ConnectionString;
        }
   
        public DbSet<Book> Books { get; set; }

      
    }
}
