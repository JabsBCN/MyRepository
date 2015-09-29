using DataAccess.NHibernate.Domain.ChartsOfAccounts;

using FluentNHibernate.Mapping;

namespace DataAccess.NHibernate.ChartsOfAccounts.Maps
{
    public class AccountMap : ClassMap<Account>
    {

        public AccountMap()
        {

            Table("Accounts");

            Id(r => r.AccountId).Column("AccountId");
            Map(r => r.ChartOfAccountsId).Column("ChartOfAccountsId");
            Map(r => r.AccountNumber).Column("AccountNumber");
            Map(r => r.Description).Column("Description");
        }

    }
}
