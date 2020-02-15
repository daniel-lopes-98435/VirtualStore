using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualStore.Models;

namespace VirtualStore.Repositories.Contracts
{
    public interface ICollaboratorRepository
    {
        Collaborator Login(string email, string password);
        //CRUD
        void AddCollaborator(Collaborator collaborator);
        void UpdateCollaborator(Collaborator collaborator);
        void DeleteCollaborator(int Id);
        Collaborator GetCollaborator(int Id);
        IEnumerable<Collaborator> GetAllClient();
    }
}
