using DataAccess.NHibernate.Domain.ChartsOfAccounts;
using NHibernate;
using NHibernate.Cfg;

namespace DataAccess.NHibernate.ChartsOfAccounts
{
    public class ChartsOfAccountsSessionFactory
    {

        public ISessionFactory GetSessionFactory()
        {

            var configuration = new Configuration();

            configuration.Configure();
            configuration.AddAssembly(typeof (ChartOfAccounts).Assembly);
            // configuration.AddAssembly(typeof(Account).Assembly);

            // configuration.Configure(AppDomain.CurrentDomain.BaseDirectory + @"hibernate.cfg.xml");
            // configuration.AddFile(AppDomain.CurrentDomain.BaseDirectory + @"ChartsOfAccounts\ChartOfAccounts.hbm.xml");
            // configuration.AddFile(AppDomain.CurrentDomain.BaseDirectory + @"ChartsOfAccounts\Account.hbm.xml");

            return configuration.BuildSessionFactory();

        }

    }
}
