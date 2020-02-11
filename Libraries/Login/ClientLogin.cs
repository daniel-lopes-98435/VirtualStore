using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualStore.Libraries.Session;
using VirtualStore.Models;


namespace VirtualStore.Libraries.Login
{
    public class ClientLogin
    {
        private string Key = "Cliente.Login";
        private ManageSession _manageSession;
        public ClientLogin(ManageSession manageSession)
        {
            _manageSession = manageSession;
        }
        public void Login(Client client)
        {
            string clientJSON = JsonConvert.SerializeObject(client);
            _manageSession.AddSession(Key, clientJSON);
        }

        public Client GetClient()
        {
            if (_manageSession.HasSession(Key))
            {
                string clientJSON = _manageSession.GetSession(Key);
                return JsonConvert.DeserializeObject<Client>(clientJSON);
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
