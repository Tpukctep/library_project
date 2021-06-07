using Dapper;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace library_back.Models
{
    public interface IFormRepository
    {
        void Create(Rootobject rootobject);
    }

    public class FormRepository : IFormRepository
    {
        string connectionString = null;
        public FormRepository(string conn)
        {
            connectionString = conn;
        }

        public void Create(Rootobject rootobject)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "EXEC dbo.ADD_NEW_BOOK N'" + rootobject.autor_name.lastname + 
                                "', N'" + rootobject.autor_name.firstname + 
                                "', N'" + rootobject.book.book_name + 
                                "', N'" + rootobject.book.publication + 
                                "', '" + rootobject.book.year_publication.ToString() + 
                                "', N'" + rootobject.autor_name.middlename + "';";

                db.Execute(sqlQuery, rootobject);

                foreach (var a in rootobject.autors)
                {
                    sqlQuery = "EXEC dbo.ADD_NEW_BOOK N'" + a.lastname_i +
                                "', N'" + a.firstname_i +
                                "', N'" + rootobject.book.book_name +
                                "', N'" + rootobject.book.publication +
                                "', '" + rootobject.book.year_publication.ToString() +
                                "', N'" + a.middlename_i + "', 1;";

                    db.Execute(sqlQuery, rootobject);
                }
            }
        }
    }
}
