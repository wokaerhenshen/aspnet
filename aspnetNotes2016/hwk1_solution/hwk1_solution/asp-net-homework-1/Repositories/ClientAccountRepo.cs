using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using asp_net_homework_1.ViewModels;

namespace asp_net_homework_1.Repositories
{
    public class ClientAccountRepo
    {
        BankEntities db = new BankEntities();
        public IEnumerable<ClientAccountVM> GetList(string accountType)
        {
            IEnumerable<ClientAccountVM> list = from c in db.Clients
                                                from a in c.BankAccounts
                                                select new ClientAccountVM
                                                {
                                                    clientID = c.clientID,
                                                    firstName = c.firstName,
                                                    lastName = c.lastName,
                                                    accountNum = a.accountNum,
                                                    balance = (a.balance == null) ?
                                                                0.00m : (decimal)a.balance,  
                                                    accountType = a.accountType                                    
                                                };
            List<ClientAccountVM> myList = list.ToList();

            // Filter
            if(accountType != "All") {
                list = list.Where(l=>l.accountType == accountType);
            }

            return list;
        }
        public ClientAccountVM Get(int clientId, int accountNum)
        {
            ClientRepo cRepo = new ClientRepo();
            Client client = cRepo.Get(clientId);
            AccountRepo aRepo = new AccountRepo();
            BankAccount account = aRepo.Get(accountNum);

            ClientAccountVM clientAccount = new ClientAccountVM
            {
                clientID = client.clientID,
                firstName = client.firstName,
                lastName = client.lastName,
                accountNum = account.accountNum,
                balance = (account.balance == null) ?
                            0.00m : (decimal)account.balance,
                accountType = account.accountType

            };
            return clientAccount;
        }
        public bool Edit(ClientAccountVM ca)
        {
            ClientRepo cRepo = new ClientRepo();
            cRepo.Edit(ca.clientID, ca.firstName, ca.lastName);
            AccountRepo aRepo = new AccountRepo();
            aRepo.Edit(ca.accountNum, ca.balance);

            return true;
        }
    }
}