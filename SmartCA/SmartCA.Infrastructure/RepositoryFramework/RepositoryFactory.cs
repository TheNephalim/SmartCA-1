using System.Reflection;
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

        public static TRepository GetRepository<TRepository, TEntity>(IUnitOfWork unitOfWork) 
            where TRepository : class, IRepository<TEntity>
            where TEntity : EntityBase
        {
            TRepository repository = default(TRepository);
            string interfaceShortName = typeof (TRepository).Name;

            if (!RepositoryFactory.repositories.ContainsKey(interfaceShortName))
            {
                //not where
                RepositorySettings settings = (RepositorySettings) ConfigurationManager.GetSection(RepositoryMappingConstants.RepositoryMappingsConfigurationSectionName);

                Type repositoryType = null;

                if (settings.RepositoryMappings.ConstaintsKey(interfaceShortName))
                {
                    repositoryType = Type.GetType(settings.RepositoryMappings[interfaceShortName].RepositoryFullTypeName);
                }
                else
                {
                    string entityTypeName = typeof (TEntity).Name;
                    foreach (RepositoryMappingElement element in settings.RepositoryMappings)
                    {
                        if (element.InterfaceShortTypeName.Contains(entityTypeName))
                        {
                            repositoryType =
                                Type.GetType(
                                    settings.RepositoryMappings[element.InterfaceShortTypeName].RepositoryFullTypeName);
                            break;
                        }
                    }
                }

                if (repositoryType == null)
                {
                    throw new ArgumentNullException("Repository not found in app.config");
                }

                object[] constructionArgs = null;
                if (unitOfWork != null && repositoryType.IsSubclassOf(typeof(RepositoryBase<TEntity>)))
                {
                    constructionArgs = new object[] {unitOfWork};
                }

                repository = Activator.CreateInstance(repositoryType, constructionArgs) as TRepository;
                repositories.Add(interfaceShortName, repository);
            }
            else
            {
                repository = (TRepository)RepositoryFactory.repositories[interfaceShortName];
                if (unitOfWork != null && repository.GetType().IsSubclassOf(typeof (RepositoryBase<TEntity>)))
                {
                    repository.SetUnitOfWork(unitOfWork);
                }
            }
            return repository;
        }
    }
}
