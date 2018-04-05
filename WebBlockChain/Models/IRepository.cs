using Domain.Enteties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebBlockChain.Models
{
    public interface IRepository:IDisposable
    {
        IEnumerable<User> AllUsers();
        IEnumerable<Transaction> AllTransaction();
        IEnumerable<Currency> AllCurrency();
        IEnumerable<BlockChain> AllBlocks();
        User FindUser(int UserId);
        void AddUser(User user);
        bool AddTransaction(Transaction transaction);
        bool MakeBlock(int UserId);
    }
}
