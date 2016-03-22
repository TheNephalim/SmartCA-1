using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SmartCA.Infrastructure.DomainBase;

namespace SmartCA.Infrastructure.RepositoryFramework
{
    public interface IUnitOfWorkRepository
    {
        void PersistNewItem(EntityBase item);
        void PersistUpdateItem(EntityBase item);
        void PersistDeletedItem(EntityBase item);
    }
}
