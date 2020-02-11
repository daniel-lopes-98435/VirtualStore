using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualStore.Models;

namespace VirtualStore.Repositories.Contracts
{
    public interface INewsletterRepository
    {
        void AddNewsletter(NewsletterEmail newsletter);
        IEnumerable<NewsletterEmail> GetAllNewsletter();
    }
}
