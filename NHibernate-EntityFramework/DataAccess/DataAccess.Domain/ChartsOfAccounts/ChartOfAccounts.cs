using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Domain.ChartsOfAccounts
{

    public class ChartOfAccounts
    {

        public virtual Guid ChartOfAccountsId { get; set; }

        public virtual string Description { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }

        public void AddAccount(Account account)
        {
            throw new NotImplementedException();
        }

        public void UpdateAccount(Account account)
        {
            throw new NotImplementedException();
        }

        public void DeleteAccount(Account account)
        {
            Accounts.Remove(account);
        }

    }

}
