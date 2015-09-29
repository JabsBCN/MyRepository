using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

using DataAccess.EntityFramework.Domain.ChartOfAccounts;

namespace DataAccess.EntityFramework.ChartsOfAccounts.Maps
{
    class AccountMaps : EntityTypeConfiguration<Account>
    {

        public AccountMaps()
        {

            ToTable("Accounts");

            // HasKey(r => new {r.AccountId, r.ChartOfAccountsId} );
            HasKey(r => r.AccountId);

            Property(r => r.AccountId).HasColumnName("AccountId").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(r => r.ChartOfAccountsId).HasColumnName("ChartOfAccountsId").IsRequired();
            Property(r => r.AccountNumber).HasColumnName("AccountNumber");
            Property(r => r.Description).HasColumnName("Description");

        }

    }
}
