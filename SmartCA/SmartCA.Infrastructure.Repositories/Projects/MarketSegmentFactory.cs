using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartCA.Infrastructure.EntityFactoryFramework;
using SmartCA.Model.Projects;

namespace SmartCA.Model.Repositories
{
    internal class MarketSegmentFactory : IEntityFactory<MarketSegment>
    {
        internal static class FieldNames
        {
            public const string MarketSegmentId = "MarketSegmentID";
            public const string MarketSectorId = "MarketSectorID";
            public const string Code = "Code";
            public const string MarketSegmentName = "MarketSegmentName";
            public const string MarketSectorName = "MarketSectorName";
        }

        public MarketSegment BuildEntity(IDataReader reader)
        {
            return new MarketSegment(reader[FieldNames.MarketSegmentId]
                , new MarketSector(reader[FieldNames.MarketSectorId], reader[FieldNames.MarketSectorName].ToString())
                , reader[FieldNames.MarketSegmentName].ToString()
                , reader[FieldNames.Code].ToString());
        }
    }
}
