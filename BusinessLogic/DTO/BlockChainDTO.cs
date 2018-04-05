using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DTO
{
    public class BlockChainDTO
    {
        public int BlockId { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public string Hash { get; set; }
        public string PreviosHash { get; set; }
        public ICollection<TransactionDTO> Transaction { get; set; }
        public BlockChainDTO()
        {
            Transaction = new List<TransactionDTO>();
        }
    }
}
