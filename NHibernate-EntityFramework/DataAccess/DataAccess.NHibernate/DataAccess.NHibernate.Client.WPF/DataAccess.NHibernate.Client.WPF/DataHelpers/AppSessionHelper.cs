using DataAccess.NHibernate.ChartsOfAccounts;

using NHibernate;

namespace DataAccess.NHibernate.Client.WPF.DataHelpers
{
    public class AppSessionHelper
    {

        static ISessionFactory _sessionFactory;
        static ISession _session;

        public static ISession Session
        {
            get
            {

                if (_sessionFactory == null)
                {
                    _sessionFactory = new FluentChartsOfAccountsSessionFactory().GetSessionFactory();
                    _session = _sessionFactory.OpenSession();
                }

                return _session;

            }
        }

        public static void Deactivate()
        {
            _session = null;
            _sessionFactory = null;
        }

    }
}
