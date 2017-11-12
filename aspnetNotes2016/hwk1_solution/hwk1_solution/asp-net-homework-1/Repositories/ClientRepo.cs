using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace asp_net_homework_1.Repositories
{
    public class ClientRepo
    {
        BankEntities db = new BankEntities();
        public Client Get(int clientId)
        {
            Client client = db.Clients
                            .Where(c => c.clientID == clientId)
                            .FirstOrDefault();
            return client;
        }
        public bool Edit(int clientId, string fName, string lName)
        {
            Client client = Get(clientId);
            client.firstName = fName;
            client.lastName = lName;
            db.SaveChanges();
            return true;      
        }
    }
}