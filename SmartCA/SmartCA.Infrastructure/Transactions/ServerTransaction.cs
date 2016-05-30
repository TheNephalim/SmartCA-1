using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataContracts;

namespace SmartCA.Infrastructure.Transactions
{
    public class ServerTransaction : Transaction
    {
        private ContractBase contract;

        public ServerTransaction(object key, TransactionType type, ContractBase contract) : base(key, type)
        {
            this.contract = contract;
        }

        public ContractBase Contract
        {
            get { return contract; }
        }
    }
}
