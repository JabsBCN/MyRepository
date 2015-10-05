using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.BackEnd
{
    public class QueryInfo
    {
        public string Key;
        public string Value;
        public string QueryOperator;

        public QueryInfo(string key, string value, string queryOperator)
        {
            this.Key = key;
            this.Value = value;
            this.QueryOperator = queryOperator;
        }
    }
}
