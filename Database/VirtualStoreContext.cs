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

        public DbSet<Client> Clients { get; set; }
        public DbSet<NewsletterEmail> newsletters { get; set; }
        public DbSet<Collaborator> Collaborators { get; set; }
    }
}
