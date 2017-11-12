using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace aspnethwk1.ViewModels
{
    public class ClientBankAccountVM
    {
        public int ClientID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public int AccountNum { get; set; }
        public string AccountType { get; set; }
        public decimal Balance { get; set; }
    }
}