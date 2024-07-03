using System;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Net.Configuration;
using System.Runtime.Remoting.Lifetime;
using System.Threading;
using System.Threading.Tasks;

[Table(Name = "Book")]
class Book
{
    [Column(IsPrimaryKey = true)]
    public int BookID { get; set; }

    [Column]
    public string BookName { get; set; }

    [Column]
    public int AuthorId { get; set; }

    [Column]
    public decimal Price { get; set; }

    [Column]
    public bool IsAvailable { get; set; }
}

[Table(Name = "Author")]
class Author
{
    [Column(IsPrimaryKey = true)]
    public int AuthorID { get; set; }

    [Column]
    public string AuthorName { get; set; }
}

class LibraryEntity : DataContext
{
    public Table<Book> Books;
    public Table<Author> Authors;
    public LibraryEntity(string connection) : base(connection) { }
}
class Program
{
    static string connection;

    static void AuthorsWihtPriceGreaterThan25()
    {
        using (var db = new LibraryEntity(connection))
        {
            var listOfAuthors = from b in db.Books
                                join
                                a in db.Authors
                                on b.AuthorId equals a.AuthorID
                                where b.Price > 25
                                group b by new
                                {
                                    a.AuthorID,
                                    a.AuthorName
                                } into g
                                select new
                                {
                                    AuthorName = g.Key.AuthorName,
                                    AuthorID = g.Key.AuthorID,
                                    BookList = g.ToList()
                                };
            foreach(var a in listOfAuthors)
            {
                Console.WriteLine(a.AuthorName + " " + a.AuthorID);
                foreach (var x in a.BookList)
                {
                    Console.WriteLine(x.BookID);
                }
            }
        }
    }

    static void BookInfo()
    {
        using (var db = new LibraryEntity(connection))
        {
            var listOfBooks = from b in db.Books
                              join
                              a in db.Authors
                              on b.AuthorId equals a.AuthorID
                              select new
                              {
                                  AuthorName = a.AuthorName,
                                  BookName = b.BookName,
                                  Price = b.Price,
                              };
            foreach (var x in listOfBooks)
            {
                Console.WriteLine(x.AuthorName + " " + x.BookName + " " + x.Price);
            }
        }
    }
    
    static void Main()
    {
        connection = "Data Source=EPINHYDW0FCC\\SQLEXPRESS;Initial Catalog=learming;Integrated Security=SSPI";
        
    }
}
