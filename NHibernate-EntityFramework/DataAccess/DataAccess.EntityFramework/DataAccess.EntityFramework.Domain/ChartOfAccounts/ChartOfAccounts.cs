using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.EntityFramework.Domain.ChartOfAccounts
{
    public class ChartOfAccounts
    {

        public Guid ChartOfAccountsId { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }

        public void AddAccount(Account account)
        {
            throw new NotImplementedException();
        }

        public void UpdateAccount(Account account)
        {
            throw new NotImplementedException();
        }

        public void DeleteAccount(Guid accountId)
        {

            var account = Accounts.FirstOrDefault(r => r.AccountId == accountId);

            if (account != null)
            {
                Accounts.Remove(account);
            }

        }

    }
}
