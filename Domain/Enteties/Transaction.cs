using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enteties
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public int? BuyerId { get; set; }
        public virtual User Buyer { get; set; }
        public int? SellerId { get; set; }
        public virtual User Seller { get; set; }
        public string Currensy { get; set; }
        public DateTime Time { get; set; }
        public double Count { get; set; }
        public bool InTheBlock { get; set; }
    }
}
