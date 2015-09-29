using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.NHibernate.Domain.ChartsOfAccounts
{
    public class ChartOfAccounts
    {
        private IList<Account> accounts = new List<Account>();

        public virtual Guid ChartOfAccountsId { get; set; }

        public virtual string Description { get; set; }

        public virtual IList<Account> Accounts { get; set; }

        public virtual void AddAccount(Account account)
        {
            throw new NotImplementedException();
        }

        public virtual void UpdateAccount(Account account)
        {
            throw new NotImplementedException();
        }

        public virtual void DeleteAccount(Guid accountId)
        {
            var currentAccount = this.Accounts.First(r => r.AccountId == accountId);
            Accounts.Remove(currentAccount);
        }

    }
}
