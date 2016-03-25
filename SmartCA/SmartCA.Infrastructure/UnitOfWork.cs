using SmartCA.Infrastructure.DomainBase;
using SmartCA.Infrastructure.RepositoryFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;

namespace SmartCA.Infrastructure
{
    public class UnitOfWork :IUnitOfWork
    {
        private Dictionary<EntityBase, IUnitOfWorkRepository> addedEntities;
        private Dictionary<EntityBase, IUnitOfWorkRepository> changedEntities;
        private Dictionary<EntityBase, IUnitOfWorkRepository> deletedEntities;

        public UnitOfWork()
        {
            addedEntities = new Dictionary<EntityBase, IUnitOfWorkRepository>();
            changedEntities = new Dictionary<EntityBase, IUnitOfWorkRepository>();
            deletedEntities = new Dictionary<EntityBase, IUnitOfWorkRepository>();
        }

        void IUnitOfWork.RegisterAdded(DomainBase.EntityBase entity, RepositoryFramework.IUnitOfWorkRepository repository)
        {
            addedEntities.Add(entity, repository);
        }

        void IUnitOfWork.RegisterChanged(DomainBase.EntityBase entity, RepositoryFramework.IUnitOfWorkRepository repository)
        {
            changedEntities.Add(entity, repository);
        }

        void IUnitOfWork.RegisterRemoved(DomainBase.EntityBase entity, RepositoryFramework.IUnitOfWorkRepository repository)
        {
            deletedEntities.Add(entity, repository);
        }

        void IUnitOfWork.Commit()
        {
            using (TransactionScope scope = new TransactionScope())
            {
                foreach (EntityBase entity in deletedEntities.Keys)
                {
                    this.deletedEntities[entity].PersistDeletedItem(entity);
                }

                foreach (EntityBase entity in addedEntities.Keys)
                {
                    addedEntities[entity].PersistNewItem(entity);
                }

                foreach (EntityBase entity in changedEntities.Keys)
                {
                    changedEntities[entity].PersistUpdateItem(entity);
                }

                scope.Complete();
            }

            this.deletedEntities.Clear();
            addedEntities.Clear();
            changedEntities.Clear();
        }
    }
}
