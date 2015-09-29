using DataAccess.NHibernate.ChartsOfAccounts.Maps;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Conventions.Helpers;
using NHibernate;

namespace DataAccess.NHibernate.ChartsOfAccounts
{
    public class FluentChartsOfAccountsSessionFactory
    {

        public ISessionFactory GetSessionFactory()
        {
            return Fluently.Configure()
                .Database(
                    MsSqlConfiguration
                        .MsSql2012
                        .ConnectionString(@"Data Source=CSPDataServer\sqlexpress;Initial Catalog=JournalEntriesEntityFramework;Integrated Security=True")
                )
                .Mappings(
                    r => r.FluentMappings.Add(typeof(ChartOfAccountsMap))
                )
                .Mappings(
                    r => r.FluentMappings.Add(typeof(AccountMap)).Conventions.Setup(c => c.Add(ForeignKey.EndsWith("Id")))
                )
                // .ExposeConfiguration(/* alter Configuration */) // optional                
                .BuildSessionFactory();
        }

    }
}
