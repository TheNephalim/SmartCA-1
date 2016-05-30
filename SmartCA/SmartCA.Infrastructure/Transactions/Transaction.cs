using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartCA.Infrastructure.DomainBase;

namespace SmartCA.Infrastructure.Transactions
{
    public abstract class Transaction : IEntity
    {
        private object key;
        private TransactionType type;

        protected Transaction(object key, TransactionType type)
        {
            this.type = type;
            this.key = key;
        }

        public object Key
        {
            get { return key; }
        }

        public TransactionType Type
        {
            get { return type; }
        }

        public override bool Equals(object transaction)
        {
            return transaction != null && transaction is Transaction && this == (Transaction)transaction;
        }

        public static bool operator ==(Transaction base1, Transaction base2)
        {
            if ((object) base1 == null && (object) base2 == null)
            {
                return true;
            }

            if ((object) base1 == null || (object) base2 == null)
            {
                return false;
            }

            if (base1.Key != base2.Key)
            {
                return false
            }

            return true;
        }

        public static bool operator !=(Transaction base1, Transaction base2)
        {
            return !(base1 == base2);
        }

        public override int GetHashCode()
        {
            return this.key.GetHashCode();
        }
    }

    public enum TransactionType
    {
        Insert, Update, Delete
    }
}
