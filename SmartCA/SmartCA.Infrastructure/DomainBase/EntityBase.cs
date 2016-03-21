using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartCA.Infrastructure.DomainBase
{
    public abstract class EntityBase
    {
        protected EntityBase():this(null)
        {
        }

        protected EntityBase(object key)
        {
            this.key = key;
        }

        private object key;
        public object Key {
            get { return key; }
        }

        public override bool Equals(object entity)
        {
            if (entity == null || !(entity is EntityBase)) return false;
            return this == (EntityBase)entity;
        }

        public static bool operator ==(EntityBase base1, EntityBase base2)
        {
            if ((object)base1 == null && (object)base2 == null)
                return true;

            if ((object)base1 == null || (object)base2 == null)
                return false;

            if (base1.key != base2.key) return false;

            return true;
        }

        public static bool operator !=(EntityBase base1, EntityBase base2)
        {
            return !(base1 == base2);
        }

        public override int GetHashCode()
        {
            return this.key.GetHashCode();
        }
    }

}
