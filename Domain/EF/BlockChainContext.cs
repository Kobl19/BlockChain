namespace Domain.EF
{
    using Domain.Enteties;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    public class BlockChainContext : DbContext
    {
        static BlockChainContext()
        {
            Database.SetInitializer<BlockChainContext>(new StoreDbInitializer());
        }
        public BlockChainContext(string connectionString)
            : base(connectionString)
        {
        }
        public virtual DbSet<BlockChain> BlockChains { get; set; }
        public virtual DbSet<Currency> Currencies { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }
    }
    public class StoreDbInitializer : DropCreateDatabaseIfModelChanges<BlockChainContext>
    {
        protected override void Seed(BlockChainContext db)
        {
            Currency c1 = new Currency { Name = "USD", Count = 100, Date = DateTime.Now };
            Currency c2 = new Currency { Name = "USD", Count = 500, Date = DateTime.Now };
            db.Currencies.AddRange(new List<Currency> { c1,c2});
            db.SaveChanges();
            db.Users.Add(new User { FirstName = "Denis", LastName = "Kobl", Currency=new List<Currency> { c1 } });
            db.Users.Add(new User { FirstName="Sergey", LastName="Popov", Currency=new List<Currency> { c2} });
            db.SaveChanges();
            BlockChain block = new BlockChain { Date = DateTime.Now, Nonce=0, PreviosHash="0", Transaction=null, Hash= "00cfeaa4e6429c90e9cdf23ea2d031d14b861366"};
            db.BlockChains.Add(block);
            db.SaveChanges();
        }
    }
}