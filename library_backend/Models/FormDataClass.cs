using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace library_back.Models
{

    public class Rootobject
    {
        public Autor_Name autor_name { get; set; }
        public Autor[] autors { get; set; }
        public Book book { get; set; }
    }

    public class Autor_Name
    {
        public string lastname { get; set; }
        public string firstname { get; set; }
        public string middlename { get; set; }
    }

    public class Book
    {
        public string book_name { get; set; }
        public string publication { get; set; }
        public int year_publication { get; set; }
    }

    public class Autor
    {
        public string lastname_i { get; set; }
        public string firstname_i { get; set; }
        public string middlename_i { get; set; }
    }

}
