using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enteties
{
    public class BlockChain
    {
        [Key]
        public int BlockId { get; set; }
        public DateTime Date { get; set; }
        public string Hash { get; set; }
        public string PreviosHash { get; set; }
        public virtual List<Transaction> Transaction { get; set; }
        public int Nonce { get; set; }
    }
}
