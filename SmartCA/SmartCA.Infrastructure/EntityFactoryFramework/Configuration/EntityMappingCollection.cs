using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCA.Infrastructure.EntityFactoryFramework.Configuration
{
    internal class EntityMappingCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new EntityMappingElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((EntityMappingElement) element).EntityShortTypeName;
        }

        public override ConfigurationElementCollectionType CollectionType
        {
            get
            {
                return ConfigurationElementCollectionType.BasicMap;
            }
        }

        protected override string ElementName
        {
            get { return EntityMappingConstants.ConfigurationElementName; }
        }

        public EntityMappingElement this[int index]
        {
            get { return (EntityMappingElement) this.BaseGet(index); }
            set
            {
                if (this.BaseGet(index) != null)
                {
                    this.BaseRemoveAt(index);
                }
                this.BaseAdd(value);
            }
        }

        public EntityMappingElement this[string entityShortTypeName]
        {
            get { return (EntityMappingElement) this.BaseGet(entityShortTypeName); }
        }

        public bool ContaintsKey(string key)
        {
            return this.BaseGetAllKeys().FirstOrDefault(_ => (string) _ == key) != null;
        }
    }
}
