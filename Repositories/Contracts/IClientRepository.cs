using VirtualStore.Models;
using System.Collections.Generic;


namespace VirtualStore.Repositories.Contracts
{
    public interface IClientRepository
    {
        Client Login(string Email, string Password);

        //CRUD
        void AddClient(Client client);
        void UpdateClient(Client client);
        void DeleteClient(int Id);
        Client GetClient(int Id);
        IEnumerable<Client> GetAllClient();

    }
}
