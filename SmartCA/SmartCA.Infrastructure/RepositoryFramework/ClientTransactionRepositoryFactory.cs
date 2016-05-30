using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartCA.Infrastructure.RepositoryFramework.Configuration;
using SmartCA.Infrastructure.Transactions;

namespace SmartCA.Infrastructure.RepositoryFramework
{
    public static class ClientTransactionRepositoryFactory
    {
        private static IClientTransactionRepository transactionRepository;

        public static IClientTransactionRepository GetTransactionRepository()
        {
            if (ClientTransactionRepositoryFactory.transactionRepository == null)
            {
                RepositorySettings settings =
                    (RepositorySettings)ConfigurationManager.GetSection(RepositoryMappingConstants.RepositoryMappingsConfigurationSectionName);
                Type repositoryType = Type.GetType(settings.RepositoryMappings["IClientTransactionRepository"].RepositoryFullTypeName);
                ClientTransactionRepositoryFactory.transactionRepository = Activator.CreateInstance(repositoryType) as IClientTransactionRepository;
            }
            return transactionRepository;
        }
    }
}
