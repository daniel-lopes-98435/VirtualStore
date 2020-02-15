using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualStore.Database;
using VirtualStore.Models;
using VirtualStore.Repositories.Contracts;

namespace VirtualStore.Repositories
{
    public class CollaboratorRepository : ICollaboratorRepository
    {
        private VirtualStoreContext _context;
        public CollaboratorRepository(VirtualStoreContext context)
        {
            _context = context;
        }
        public void AddCollaborator(Collaborator collaborator)
        {
            _context.Collaborators.Add(collaborator);
            _context.SaveChanges();
        }

        public void DeleteCollaborator(int Id)
        {
            Collaborator collaborator = GetCollaborator(Id);
            _context.Collaborators.Remove(collaborator);
            _context.SaveChanges();
        }

        public IEnumerable<Collaborator> GetAllClient()
        {
            return _context.Collaborators.ToList();
        }

        public Collaborator GetCollaborator(int Id)
        {
            return _context.Collaborators.Find(Id);
        }

        public Collaborator Login(string Email, string Password)
        {
            Collaborator collaborator = _context.Collaborators.Where(c => c.Email == Email && c.Password == Password).FirstOrDefault();
            return collaborator;
        }

        public void UpdateCollaborator(Collaborator collaborator)
        {
            _context.Update(collaborator);
            _context.SaveChanges();
        }
    }
}
