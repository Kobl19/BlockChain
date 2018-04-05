using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DTO
{
    public class UserDTO
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<CurrencyDTO> Currency { get; set; }
        public UserDTO()
        {
            Currency = new List<CurrencyDTO>();
        }
    }
}
