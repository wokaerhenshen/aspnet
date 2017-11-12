using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace aspnethwk1.Repositories
{
    public class Account
    {
        public BankAccount Get(int accountID)
        {
            BankEntities db = new BankEntities();
            return db.BankAccounts.Where(b => b.accountNum == accountID).FirstOrDefault();
        }

        public bool Update(int accountID, decimal balance)
        {
            BankEntities db = new BankEntities();
            BankAccount bankaccount = db.BankAccounts
                .Where(b => b.accountNum == accountID).FirstOrDefault();
            bankaccount.balance = balance;
            db.SaveChanges();
            return true;
        }
    }
}