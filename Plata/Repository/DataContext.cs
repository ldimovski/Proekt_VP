using Plata.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plata.Repository
{
    class DataContext : DbContext
    {
       public DataContext() : base("name=Model11")
        {

        }
       public virtual DbSet<Firma> firmi { get; set; }
       public virtual DbSet<Vraboten> vraboteni { get; set; }
    }
}
