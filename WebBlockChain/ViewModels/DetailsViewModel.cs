using Domain.Enteties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBlockChain.ViewModels
{
    public class DetailsViewModel
    {
        public List<BlockChain> BlockChains { get; set; }
        public List<Transaction> Transactions { get; set; }
    }
}