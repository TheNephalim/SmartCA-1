using SmartCA.Infrastructure.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCA.Infrastructure.RepositoryFramework
{
    public abstract class ClientTransactionRepository : IClientTransactionRepository
    {
        #region IClientTransactionRepository
        public abstract DateTime? GetLastSynchronization();
        public abstract void SetLastSynchronization(DateTime? lastSynchronization);

        public void Add(ClientTransaction transaction)
        {
            object contract = Converter.ToContract(transaction.Entity);
            byte[] serializedContractData = Serializer.Serialize(contract);
            this.PersistNewTransaction(transaction.Type, serializedContractData, transaction.Key);
        }

        public abstract IList<ClientTransaction> FindPending();
        #endregion

        protected abstract void PersistNewTransaction(TransactionType type, byte[] serializeContractData, object transactionKey);
    }
}
