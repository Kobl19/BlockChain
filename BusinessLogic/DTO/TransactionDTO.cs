using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DTO
{
    public class TransactionDTO
    {
        public int TransactionId { get; set; }
        public int? BuyerId { get; set; }
        public int? SellerId { get; set; }
        public UserDTO Users { get; set; }
        public int? CurrencyId { get; set; }
        public CurrencyDTO Currency { get; set; }
        public DateTime Time { get; set; }
    }
}
