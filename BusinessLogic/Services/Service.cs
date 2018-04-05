using BusinessLogic.DTO;
using BusinessLogic.Infastracture;
using BusinessLogic.Interfaces;
using Domain.Enteties;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class Service : IService
    {
        IRepository Database { get; set; }
        public Service(IRepository repository)
        {
            Database = repository;
        }        

        public IEnumerable<UserDTO> AllUsers()
        {
            IEnumerable<User> user = Database.AllUsers();
            IEnumerable<UserDTO> userDTO;
            foreach (var item in user)
            {
                UserDTO DTO=new UserDTO {Currency=item.Currency, FirstName }
            }
        }

        public IEnumerable<TransactionDTO> AllTransaction()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CurrencyDTO> AllCurrencyDTO()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BlockChainDTO> AllBlocks()
        {
            throw new NotImplementedException();
        }

        public OperationDatails AddUser(UserDTO userDTO)
        {
            User user = new User
            {
                FirstName = userDTO.FirstName,
                LastName = userDTO.LastName
            };

            Database.AddUser(user);
            return new OperationDatails(true, "User добавлен успено", "");
        }
        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
