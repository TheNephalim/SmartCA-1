using SmartCA.Infrastructure.DomainBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartCA.Infrastructure.RepositoryFramework
{
    public abstract class RepositoryBase<T> : IRepository<T>, IUnitOfWorkRepository where T: EntityBase
    {
        private IUnitOfWork unitOfWork;

        protected RepositoryBase():this(null)
        {

        }

        protected RepositoryBase(IUnitOfWork unitOfWork)
        {
            SetUnitOfWork(unitOfWork);
        }

        #region IRepository Implementation

        protected IUnitOfWork UnitOfWork {
            get { return unitOfWork; }
        }

        public void SetUnitOfWork(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public abstract T FindBy(object key);
        public abstract IList<T> FindAll();

        public void Add(T item)
        {
            if (unitOfWork != null)
            {
                unitOfWork.RegisterAdded(item, this);
            }
        }

        public T this[object key]
        {
            get
            {
                return FindBy(key);
            }
            set
            {
                if (FindBy(key) == null)
                {
                    Add(value);
                }
                else
                {
                    unitOfWork.RegisterChanged(value, this);
                }
            }
        }

        public void Remove(T item)
        {
            if (unitOfWork != null)
            {
                unitOfWork.RegisterRemoved(item, this);
            }
        }

        #endregion

        #region IUnitOfWorkRepository Implementation

        public virtual void PersistNewItem(IEntity item)
        {
            this.PersistNewItem((T)item);
        }

        public virtual void PersistUpdateItem(IEntity item)
        {
            this.PersistUpdateItem((T)item);
        }

        public virtual void PersistDeletedItem(IEntity item)
        {
            this.PersistDeletedItem((T)item);
        }

        

        protected abstract void PersistNewItem(T item);
        protected abstract void PersistUpdateItem(T item);
        protected abstract void PersistDeletedItem(T item);

        #endregion
    }
}
