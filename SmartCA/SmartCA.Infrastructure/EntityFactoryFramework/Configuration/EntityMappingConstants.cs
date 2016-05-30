using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCA.Infrastructure.EntityFactoryFramework.Configuration
{
    internal static class EntityMappingConstants
    {
        public const string ConfigurationSectionName = "entityMappingsConfiguration";
        public const string ConfigurationPropertyName = "entityMappings";
        public const string ConfigurationElementName = "entityMapping";

        public const string EntityShortTypeNameAttributeName = "entityShortTypeName";
        public const string EntityFactoryFullTypeNameAttributeName = "entityFactoryFullTypeName";
    }
}
