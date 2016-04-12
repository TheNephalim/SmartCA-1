using SmartCA.Infrastructure.DomainBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCA.Model.Projects
{
    public class MarketSegment : EntityBase
    {
        private string name;
        private string code;
        private MarketSector parentSector;
        
        public MarketSegment(MarketSector parentSector, string name, string code):this(null, parentSector, name, code)
        {
        }

        public MarketSegment(object key, MarketSector parentSector, string name, string code) : base(key)
        {
            this.parentSector = parentSector;
            this.name = name;
            this.code = code;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Code
        {
            get { return code; }
            set { code = value; }
        }

        public MarketSector ParentSector
        {
            get { return parentSector; }
        }
    }
}
