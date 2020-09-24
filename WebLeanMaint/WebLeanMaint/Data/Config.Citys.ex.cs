using Dapper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;

namespace Data.Config
{
	public partial class Citys : EntitiesManagerBase
	{
		public static IEnumerable<City> GetItalianCitiesForDropDownList()
		{
			StringBuilder oSql = new StringBuilder();
			oSql.AppendLine("SELECT T.ID_City, Name = T.Name+' - '+R.Name ");
			oSql.AppendLine("FROM Config.Countries C ");
			oSql.AppendLine("INNER JOIN Config.Regions R ON C.ID_Country = R.ID_Country ");
			oSql.AppendLine("INNER JOIN Config.Cities T ON R.ID_Region = T.ID_Region ");
			oSql.AppendLine("WHERE C.ID_Country = 100");
			return (EntitiesManagerBase.SharedConnection.Query<City>(oSql.ToString()));
		}
	}
}
