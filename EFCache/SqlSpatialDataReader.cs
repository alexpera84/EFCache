using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;

using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCache
{
    internal sealed class SqlSpatialDataReader : DbSpatialDataReader
    {
        private CachingReader reader;

        public SqlSpatialDataReader(CachingReader cr)
        {
            reader = cr;
        }

        //public SqlSpatialDataReader(SqlDataReader underlyingReader)
        //{
        //    this.reader = underlyingReader;
        //}

        public override DbGeography GetGeography(int ordinal)
        {
            //EnsureGeographyColumn(ordinal);
            object obj = reader.GetValue(ordinal);
           

            //var geographyBytes = this.reader.GetSqlBytes(ordinal);
            //dynamic geography = Activator.CreateInstance(System.Data.SqlTypes.SqlGeographyType);
            if (obj != null) {
                return DbGeography.FromText(obj.ToString());
            }
            return null;
            
        }

        public override DbGeometry GetGeometry(int ordinal)
        {
            object obj = reader.GetValue(ordinal);
            if (obj != null)
            {
                return DbGeometry.FromText(obj.ToString());
            }
            return null;
        }
#warning NEED TO CHECK IF DATA ORDINAL IS GEOMETRY OR GEOGRAPHY
        public override bool IsGeographyColumn(int ordinal)
        {
            //var data = reader.GetValue(ordinal);
            return true;
        }

        public override bool IsGeometryColumn(int ordinal)
        {
            return false;
        }

        

        
    }
}
