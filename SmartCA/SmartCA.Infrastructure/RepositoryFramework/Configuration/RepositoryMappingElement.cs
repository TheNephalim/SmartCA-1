using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartCA.Infrastructure.RepositoryFramework.Configuration
{
    public class RepositoryMappingElement : ConfigurationElement
    {
        [ConfigurationProperty(RepositoryMappingConstants.InterfaceShortTypeNameAttributeName, IsRequired = true)]
        public string InterfaceShortTypeName {
            get { return (string) this[RepositoryMappingConstants.InterfaceShortTypeNameAttributeName]; }
            set { this[RepositoryMappingConstants.InterfaceShortTypeNameAttributeName] = value; }
        }

        [ConfigurationProperty(RepositoryMappingConstants.RepositoryFullTypeNameAttributeName, IsRequired = true)]
        public string RepositoryFullTypeName
        {
            get { return (string) this[RepositoryMappingConstants.RepositoryFullTypeNameAttributeName]; }
            set { this[RepositoryMappingConstants.RepositoryFullTypeNameAttributeName] = value; }
        }
    }
}
