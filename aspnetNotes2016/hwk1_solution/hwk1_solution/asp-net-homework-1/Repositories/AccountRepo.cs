using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace asp_net_homework_1.Repositories
{
    public class AccountRepo
    {
        BankEntities db = new BankEntities();
        public BankAccount Get(int accountNum)
        {
            BankAccount account = db.BankAccounts
                            .Where(a => a.accountNum == accountNum)
                            .FirstOrDefault();
            return account;
        }
        public bool Edit(int accountNum, decimal balance)
        {
            BankAccount account = Get(accountNum);
            account.balance = balance;
            db.SaveChanges();
            return true;
        }
    }
}