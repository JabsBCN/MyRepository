using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DataAccess.EntityFramework.ChartsOfAccounts.Maps
{
    class ChartOfAccountsMaps : EntityTypeConfiguration<Domain.ChartOfAccounts.ChartOfAccounts>
    {

        public ChartOfAccountsMaps()
        {

            ToTable("ChartOfAccounts");

            HasKey(r => r.ChartOfAccountsId);

            Property(r => r.ChartOfAccountsId)
                .HasColumnName("ChartOfAccountsId")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(r => r.Description).HasColumnName("Description");

            HasMany(r => r.Accounts)
                .WithRequired(r => r.ChartOfAccounts)
                .HasForeignKey(r => r.ChartOfAccountsId)
                .WillCascadeOnDelete(true);

        }

    }
}
