using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace asp_net_homework_1.ViewModels
{
    public class ClientAccountVM
    {
        [Display(Name = "Account Number")]
        public int accountNum { get; set; }
        [Display(Name = "Balace")]
        [DataType(DataType.Currency, ErrorMessage = "Balance must be a valid number")]
        public decimal balance { get; set; }
        [Display(Name = "Account Type")]
        public string accountType { get; set; }
        [Display(Name = "Client ID")]
        public int clientID { get; set; }
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "Must enter a first Name")]
        public string firstName { get; set; }
        [Display(Name = "Last Name")]       
        [Required(ErrorMessage = "Must enter a Last Name")]
        public string lastName { get; set; }
    }
}