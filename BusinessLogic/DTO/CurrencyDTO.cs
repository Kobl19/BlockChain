using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DTO
{
    public class CurrencyDTO
    {
        public int CurrencyId { get; set; }
        public string Name { get; set; }
        public double Count { get; set; }
        public DateTime Date { get; set; }
        public int? UserId { get; set; }
        public UserDTO Users { get; set; }
    }
}
