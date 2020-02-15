using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualStore.Libraries.Session;
using VirtualStore.Models;

namespace VirtualStore.Libraries.Login
{
    public class CollaboratorLogin
    {
        private string Key = "Collaborator.Login";
        private ManageSession _manageSession;
        public CollaboratorLogin(ManageSession manageSession)
        {
            _manageSession = manageSession;
        }
        public void Login(Collaborator collaborator)
        {
            string collaboratorJSON = JsonConvert.SerializeObject(collaborator);
            _manageSession.AddSession(Key, collaboratorJSON);
        }

        public Collaborator GetCollaborator()
        {
            if (_manageSession.HasSession(Key))
            {
                string collaboratorJSON = _manageSession.GetSession(Key);
                return JsonConvert.DeserializeObject<Collaborator>(collaboratorJSON);
            }
            else
            {
                return null;
            }
        }
        public void Logout()
        {
            _manageSession.RemoveAll();
        }
    }
}
