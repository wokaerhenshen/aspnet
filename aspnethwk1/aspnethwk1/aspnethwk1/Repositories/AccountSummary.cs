using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using aspnethwk1.ViewModels;

namespace aspnethwk1.Repositories
{
    public class AccountSummary
    {

        BankEntities db = new BankEntities();
        public IEnumerable<ClientBankAccountVM> GetSummary(string accountType)
        {
           
            IEnumerable<ClientBankAccountVM> query = from c in db.Clients
                        from b in c.BankAccounts
                        select new ClientBankAccountVM
                        {
                            AccountNum = b.accountNum,
                            Balance = (b.balance == null)? 0.00m: (decimal)b.balance,
                            ClientID = c.clientID,
                            LastName = c.lastName,
                            FirstName = c.firstName,
                            AccountType = b.accountType
                        };

            if (accountType != "All")
            {
                return query.Where(subq => subq.AccountType == accountType);
            }

            return query;

        }

        public ClientBankAccountVM GetDetail(int accountNum, int clientId)
        {
            Account account = new Account();
            BankAccount bankaccount = account.Get(accountNum);

            Clients clients = new Clients();
            Client client = clients.Get(clientId);

            ClientBankAccountVM result = new ClientBankAccountVM();
            //{
            result.ClientID = client.clientID;
            result.LastName = client.lastName;
            result.FirstName = client.firstName;
            result.AccountNum = bankaccount.accountNum;
            result.AccountType = bankaccount.accountType;
            result.Balance = (bankaccount.balance == null) ? 0.00m : (decimal)bankaccount.balance;

            //};

            return result;
        }

        public bool Update(ClientBankAccountVM cba)
        {
            Account bankaccount = new Account();
            bankaccount.Update(cba.AccountNum, cba.Balance);

            Clients clients = new Clients();
            clients.Update(cba.ClientID, cba.FirstName, cba.LastName);

            return true;

        }
    }
}