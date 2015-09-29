using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataAccess.EntityFramework.ChartsOfAccounts;

namespace DataAccess.EntityFramework.Client.WPF.DataHelpers
{
    public class DataHelper
    {

        private static ChartsOfAccountsContext _chartOfAccountsContext;

        public static ChartsOfAccountsContext ChartsOfAccountsContext
        {
            get
            {

                if (_chartOfAccountsContext == null)
                {
                    _chartOfAccountsContext = new ChartsOfAccountsContext();
                }

                return _chartOfAccountsContext;

            }
        }

        public static void Deactivate()
        {
            _chartOfAccountsContext = null;
        }

    }
}
