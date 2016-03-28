﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCA.Infrastructure.EntityFactoryFramework.Configuration
{
    internal class EntityMappingElement : ConfigurationElement
    {
        [ConfigurationProperty(EntityMappingConstants.EntityShortTypeNameAttributeName, IsRequired = true)]
        public string EntityShortTypeName {
            get { return (string)this[EntityMappingConstants.EntityShortTypeNameAttributeName]; }
            set { this[EntityMappingConstants.EntityShortTypeNameAttributeName] = value; }
        }
        [ConfigurationProperty(EntityMappingConstants.EntityFactoryFullTypeNameAttributeName, IsRequired = true)]
        public string EntityFactoryFullTypeName {
            get { return (string) this[EntityMappingConstants.EntityFactoryFullTypeNameAttributeName]; }
            set { this[EntityMappingConstants.EntityFactoryFullTypeNameAttributeName] = value; }
        }
    }
}
