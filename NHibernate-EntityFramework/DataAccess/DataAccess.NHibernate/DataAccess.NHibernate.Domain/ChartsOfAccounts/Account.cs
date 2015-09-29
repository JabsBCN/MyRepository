using System;

namespace DataAccess.NHibernate.Domain.ChartsOfAccounts
{
    public class Account
    {
        public virtual Guid AccountId { get; set; }

        public virtual Guid ChartOfAccountsId { get; set; }

        public virtual string AccountNumber { get; set; }

        public virtual string Description { get; set; }

        public virtual ChartOfAccounts ChartOfAccounts { get; set; }
    }
}
