using SmartCA.Infrastructure.DomainBase;
using SmartCA.Infrastructure.RepositoryFramework;
using Microsoft.E
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartCA.Infrastructure.Repositories
{
    public abstract class SqlCeRepositoryBase<T> :RepositoryBase<T> where T:EntityBase
    {
        public delegate void AppendChildData(T entityAggregate, object childEntityKeyValue);


    }
}
