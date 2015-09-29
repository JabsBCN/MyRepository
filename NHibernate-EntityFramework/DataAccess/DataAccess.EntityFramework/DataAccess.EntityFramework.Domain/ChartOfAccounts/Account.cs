using System;

namespace DataAccess.EntityFramework.Domain.ChartOfAccounts
{
    public class Account
    {
        public Guid AccountId { get; set; }

        public Guid ChartOfAccountsId { get; set; }

        public string AccountNumber { get; set; }

        public string Description { get; set; }

        public virtual ChartOfAccounts ChartOfAccounts { get; set; }

    }
}
