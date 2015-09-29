using DataAccess.NHibernate.Domain.ChartsOfAccounts;

using FluentNHibernate.Mapping;

namespace DataAccess.NHibernate.ChartsOfAccounts.Maps
{
    public class ChartOfAccountsMap : ClassMap<ChartOfAccounts>
    {
        public ChartOfAccountsMap()
        {

            Table("ChartOfAccounts");

            Id(x => x.ChartOfAccountsId).Column("ChartOfAccountsId");
            Map(r => r.Description).Column("Description");

            HasMany(x => x.Accounts).LazyLoad().Cascade.AllDeleteOrphan().Inverse();

        }
    }
}
