using SmartCA.Infrastructure.DomainBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SmartCA.Infrastructure.RepositoryFramework.Configuration;
using System.Configuration;

namespace SmartCA.Infrastructure.RepositoryFramework
{
    public static class RepositoryFactory
    {
        private static Dictionary<string, object> repositories = new Dictionary<string, object>();

        public static TRepository GetRepository<TRepository, TEntity>() 
            where TRepository : class, IRepository<TEntity>
            where TEntity : EntityBase
        {
            TRepository repository = default(TRepository);
            string interfaceShortName = typeof (TRepository).Name;

            if (!RepositoryFactory.repositories.ContainsKey(interfaceShortName))
            {
                //not there
                RepositorySettings settings =
                    (RepositorySettings) ConfigurationManager.GetSection(RepositoryMappingConstants.RepositoryMappingsConfigurationSectionName);

                repository =
                    Activator.CreateInstance(Type.GetType(settings.RepositoryMappings[interfaceShortName].RepositoryFullTypeName)) as TRepository;

                repositories.Add(interfaceShortName, repository);
            }
            else
            {
                repository = (TRepository)RepositoryFactory.repositories[interfaceShortName];
            }
            return repository;
        }
    }
}
