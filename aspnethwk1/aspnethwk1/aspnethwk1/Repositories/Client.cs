using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace aspnethwk1.Repositories
{
    public class Clients
    {
        public Client Get(int id)
        {
            BankEntities db = new BankEntities();
            return db.Clients.Where(c => c.clientID == id).FirstOrDefault();
        }

        public bool Update(int id, string firstName ,string lastName)
        {
            BankEntities db = new BankEntities();
            Client client = db.Clients.Where(c => c.clientID == id).FirstOrDefault();
            client.firstName = firstName;
            client.lastName = lastName;
            db.SaveChanges();
            return true;

        }
    }
}