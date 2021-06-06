using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library_winform
{
    public static class SqlConnectionClass
    {
        public static string ConnectionString => ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
    }
}
