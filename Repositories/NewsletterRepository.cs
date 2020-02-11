using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualStore.Database;
using VirtualStore.Models;
using VirtualStore.Repositories.Contracts;

namespace VirtualStore.Repositories
{
    public class NewsletterRepository : INewsletterRepository
    {
        private VirtualStoreContext _context;
        public NewsletterRepository( VirtualStoreContext context)
        {
            _context = context;
        }
        public void AddNewsletter(NewsletterEmail newsletter)
        {
            _context.newsletters.Add(newsletter);
            _context.SaveChanges();

        }

        public IEnumerable<NewsletterEmail> GetAllNewsletter()
        {
            return _context.newsletters.ToList();
        }
    }
}
