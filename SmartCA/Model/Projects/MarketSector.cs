using SmartCA.Infrastructure.DomainBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCA.Model.Projects
{
    public class MarketSector: EntityBase
    {
        private string name;
        private List<MarketSegment> segments;

        public MarketSector(string name) :this(null, name)
        {
        }

        public MarketSector(object key, string name):base(key)
        {
            this.name = name;
            this.segments = new List<MarketSegment>();
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public IList<MarketSegment> Segments
        {
            get { return this.segments; }
        }

    }
}
