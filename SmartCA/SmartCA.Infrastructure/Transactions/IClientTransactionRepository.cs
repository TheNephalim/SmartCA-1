using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCA.Infrastructure.Transactions
{
    public interface IClientTransactionRepository
    {
        DateTime? GetLastSynchronization();
        void SetLastSynchronization(DateTime? lastSynchronization);
        void Add(ClientTransaction transaction);
        IList<ClientTransaction> FindPending();
    }
}
