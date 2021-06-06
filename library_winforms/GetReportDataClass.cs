using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library_winform
{
    public static class GetReportDataClass
    {
        public static IList<ReportHistoryClass> GetResult(string startDate, string endDate)
        {
            using (IDbConnection db = new SqlConnection(SqlConnectionClass.ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                var queryParametrs = new DynamicParameters();
                queryParametrs.Add("@START_DATE", startDate, DbType.Date);
                queryParametrs.Add("@END_DATE", endDate, DbType.Date);

                return db.Query<ReportHistoryClass>("Report_history_book", queryParametrs, commandType: CommandType.StoredProcedure).ToList();
            }
        }
    }
}
