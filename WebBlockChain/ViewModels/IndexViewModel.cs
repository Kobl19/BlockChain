using Domain.Enteties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBlockChain.ViewModels
{
    public class IndexViewModel
    {
        public User User { get; set; }
        public List<User> Users { get; set; }
        public List<Currency> Currensies { get; set; }
        public List<Transaction> Transactions { get; set; }
    }
}