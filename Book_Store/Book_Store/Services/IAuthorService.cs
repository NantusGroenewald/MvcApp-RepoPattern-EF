using Book_Store.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Store.Services
{
    public interface IAuthorService
    {
        IEnumerable<Author> GetAllAuthors();
        Author GetAuthorById(int id);
        void AddAuthor(Author author);
    }
}
