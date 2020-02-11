using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualStore.Database;
using VirtualStore.Models;
using VirtualStore.Repositories.Contracts;

namespace VirtualStore.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private VirtualStoreContext _context;
        public ClientRepository(VirtualStoreContext context)
        {
            _context = context;
        }
        public void AddClient(Client client)
        {
            _context.Clients.Add(client);
            _context.SaveChanges(); ;
        }

        public void DeleteClient(int Id)
        {
            Client client = GetClient(Id);
            _context.Remove(client);
            _context.SaveChanges();
        }


        public IEnumerable<Client> GetAllClient()
        {
            return _context.Clients.ToList();
        }

        public Client GetClient(int Id)
        {
            return _context.Clients.Find(Id);
        }

        public Client Login(string Email, string Password)
        {
            Client client = _context.Clients.Where(c => c.Email == Email && c.Password == Password).FirstOrDefault();
            return client;
        }

        public void UpdateClient(Client client)
        {
            _context.Update(client);
            _context.SaveChanges();
        }
    }
}
