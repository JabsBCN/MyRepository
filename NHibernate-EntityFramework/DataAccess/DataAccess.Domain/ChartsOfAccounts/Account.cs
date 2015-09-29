using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Domain.ChartsOfAccounts
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
