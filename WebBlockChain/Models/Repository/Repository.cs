using Domain.EF;
using Domain.Enteties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace WebBlockChain.Models.Repository
{
    public class Repository:IRepository
    {
        private BlockChainContext db;
        public Repository()
        {
            this.db = new BlockChainContext("DefaultConnection");
        }

        public void AddUser(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
        }

        public IEnumerable<BlockChain> AllBlocks()
        {
            return db.BlockChains;
        }

        public User FindUser(int UserId)
        {
            return db.Users.FirstOrDefault(x => x.UserId == UserId);
        }
        public IEnumerable<Currency> AllCurrency()
        {
            return db.Currencies;
        }

        public IEnumerable<Transaction> AllTransaction()
        {
            return db.Transactions;
        }

        public IEnumerable<User> AllUsers()
        {
            return db.Users;
        }

        public bool AddTransaction(Transaction transaction)
        {
            using (var trans = db.Database.BeginTransaction())
            {
                try
                {
                    Currency buyerCurr= db.Currencies.Where(x => x.UserId == transaction.BuyerId && x.Name == transaction.Currensy).FirstOrDefault();
                    Currency sellerCurr = db.Currencies.Where(x => x.UserId == transaction.SellerId && x.Name == transaction.Currensy).FirstOrDefault();
                    transaction.Buyer = db.Users.FirstOrDefault(x=>x.UserId==transaction.BuyerId); 
                    transaction.Seller = db.Users.FirstOrDefault(x => x.UserId == transaction.SellerId);
                    buyerCurr.Count += transaction.Count;
                    if (sellerCurr.Count>=transaction.Count)
                    {
                        sellerCurr.Count -= transaction.Count;
                    }
                    else
                    {
                        throw new Exception();
                    }
                    db.Entry(buyerCurr).State = System.Data.Entity.EntityState.Modified;
                    db.Entry(sellerCurr).State = System.Data.Entity.EntityState.Modified;
                    db.Transactions.Add(transaction);
                    db.SaveChanges();
                    trans.Commit();
                }
                catch (Exception)
                {
                    trans.Rollback();
                    return false;
                }
                return true;
            }
        }
        public bool MakeBlock(int UserId)
        {
            using (var trans = db.Database.BeginTransaction())
            {
                try
                {
                    List<Transaction> transactions = AllTransaction().Where(x => x.InTheBlock == false).ToList();
                    if (transactions.Count==0)
                    {
                        throw new Exception();
                    }
                    foreach (var item in transactions)
                    {
                        item.InTheBlock = true;
                    }
                    BlockChain block = new BlockChain
                    {
                        Date = DateTime.Now,
                        PreviosHash = AllBlocks().LastOrDefault().Hash,
                        Nonce = 0,
                        Transaction = transactions
                    };
                    bool checker = true;

                    do
                    {
                        block.Nonce++;
                        string input = block.PreviosHash + block.Nonce + block.Transaction.GetHashCode() + block.Date.ToLongTimeString();
                        byte[] hashArray;
                        using (var sha1 = new System.Security.Cryptography.SHA1CryptoServiceProvider())
                            hashArray = sha1.ComputeHash(Encoding.Unicode.GetBytes(input));
                        var sb = new StringBuilder();
                        foreach (byte b in hashArray) sb.AppendFormat("{0:x2}", b);
                        Regex regex = new Regex(@"^00\S*");
                        var gg = regex.Match(sb.ToString());
                        if (regex.Match(sb.ToString()).Success == true)
                        {
                            block.Hash = sb.ToString();
                            checker = false;
                        }
                    } while (checker);
                    db.BlockChains.Add(block);
                    db.SaveChanges();
                    GetUSD(UserId);
                    trans.Commit();
                }
                catch
                {
                    trans.Rollback();
                    return false;
                }
                return true;
            }
        }
        private void GetUSD(int UserID)
        {
            User user=db.Users.FirstOrDefault(x => x.UserId == UserID);
            if (user.Currency.FirstOrDefault(x => x.Name == "USD")==null)
            {
                Currency currency = new Currency { Name = "USD", Count = 50, Date = DateTime.Now };
                db.Currencies.Add(currency);
                db.SaveChanges();
                user.Currency.Add(currency);
                db.SaveChanges();
            }
            else
            {
                Currency curr= user.Currency.FirstOrDefault(x => x.Name == "USD");
                curr.Count += 50;
                db.SaveChanges();
            }
        }
        public void Dispose()
        {
            db.Dispose();
        }
    }
}