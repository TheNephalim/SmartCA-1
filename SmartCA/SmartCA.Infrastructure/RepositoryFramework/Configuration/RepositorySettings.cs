using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartCA.Infrastructure.RepositoryFramework.Configuration
{
    public class RepositorySettings : ConfigurationSection
    {
        [ConfigurationProperty(RepositoryMappingConstants.ConfigurationPropertyName, IsDefaultCollection = true)]
        public RepositoryMappingCollection RepositoryMappings
        {
            get
            {
                return
                    (RepositoryMappingCollection)
                    base[RepositoryMappingConstants.ConfigurationPropertyName];
            }
        }
    }
}
