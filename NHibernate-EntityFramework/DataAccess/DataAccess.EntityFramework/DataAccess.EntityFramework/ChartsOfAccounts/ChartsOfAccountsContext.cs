using System.Data.Entity;

using DataAccess.EntityFramework.ChartsOfAccounts.Maps;
using DataAccess.EntityFramework.Domain.ChartOfAccounts;

namespace DataAccess.EntityFramework.ChartsOfAccounts
{
    public class ChartsOfAccountsContext : DbContext
    {

        public DbSet<ChartOfAccounts> ChartsOfAccounts { get; set; }

        public DbSet<Account> Accounts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Configurations.Add(new ChartOfAccountsMaps());
            modelBuilder.Configurations.Add(new AccountMaps());

        }
    }
}
