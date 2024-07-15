using Book_Store.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Store.Services
{
    public interface IBookService
    {
        IEnumerable<Book> GetAllBooks(); 
        Book GetBookById(int id);
        void AddBook(Book book);
        IEnumerable<Genre> GetAllGenres();
        IEnumerable<Author> GetAllAuthors();
        IEnumerable<Publisher> GetAllPublishers();
        void UpdateBook(Book book);
        void DeleteBook(int id);
    }
}
