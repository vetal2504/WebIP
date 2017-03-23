using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WebIP.Models
{
    public class IPContext : DbContext
    {
        public IPContext() : base("DBContext")
        {

        }

        public DbSet<IP_address> AllAddress { get; set; }
        public DbSet<Networking> Networkings { get; set; }
    }
}