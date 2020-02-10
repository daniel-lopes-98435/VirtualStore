using VirtualStore.Models;
using System.Collections.Generic;


namespace VirtualStore.Repositories
{
    interface IClientRepository
    {
        Client Login(string Email, string Password);

        //CRUD
        void AddClient(Client client);
        void UpdateClient(Client client);
        void DeleteClient(Client client);
        Client GetClient(int Id);
        List<Client> GetAllClient();

    }
}
