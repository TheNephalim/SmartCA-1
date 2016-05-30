using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SmartCA.Infrastructure.DomainBase;

namespace SmartCA.Infrastructure.RepositoryFramework
{
    public interface IUnitOfWorkRepository
    {
        void PersistNewItem(IEntity item);
        void PersistUpdateItem(IEntity item);
        void PersistDeletedItem(IEntity item);
    }
}
