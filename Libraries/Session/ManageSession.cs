using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VirtualStore.Libraries.Session
{
    public class ManageSession
    {
        private IHttpContextAccessor _context;
        public ManageSession(IHttpContextAccessor context)
        {
            _context = context;
        }
        public void AddSession(string key, string value)
        {
            _context.HttpContext.Session.SetString(key, value);
        }
        public void UpdateSession(string key, string value)
        {
            if (HasSession(key))
            {
                _context.HttpContext.Session.Remove(key);
            }
            
            _context.HttpContext.Session.SetString(key, value);
        }
        public void RemoveSession(string key)
        {
            _context.HttpContext.Session.Remove(key);
        }
        public string GetSession(string key)
        {
            return _context.HttpContext.Session.GetString(key);
        }
        public bool HasSession(string key)
        {
            if(_context.HttpContext.Session.GetString(key) == null)
            {
                return false;
            }
            return true;

        }
        public void RemoveAll()
        {
            _context.HttpContext.Session.Clear();
        }

    }
}
