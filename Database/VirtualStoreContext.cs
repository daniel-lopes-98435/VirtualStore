using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualStore.Models;

namespace VirtualStore.Database
{
    public class VirtualStoreContext : DbContext
    {
        public VirtualStoreContext(DbContextOptions<VirtualStoreContext> options) : base(options)
        {

        }

        public DbSet<Client> clients { get; set; }

    }
}
