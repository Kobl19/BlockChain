using BusinessLogic.DTO;
using BusinessLogic.Infastracture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IService:IDisposable
    {
        IEnumerable<UserDTO> AllUsers();
        IEnumerable<TransactionDTO> AllTransaction();
        IEnumerable<CurrencyDTO> AllCurrencyDTO();
        IEnumerable<BlockChainDTO> AllBlocks();
        OperationDatails AddUser(UserDTO user);
    }
}
