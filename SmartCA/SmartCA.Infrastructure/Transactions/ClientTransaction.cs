using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartCA.Infrastructure.DomainBase;
using SmartCA.Infrastructure.Transactions;

namespace SmartCA.Infrastructure.Transactions
{
    public class ClientTransaction : Transaction
    {
        private IEntity entity;

        public ClientTransaction(object key, TransactionType type, IEntity entity) : base(key, type)
        {
            this.entity = entity;
        }

        public IEntity Entity
        {
            get { return entity; }
        }
    }
}
