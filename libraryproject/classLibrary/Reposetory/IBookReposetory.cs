using Library.Core.Modals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Reposetory
{
    public interface IBookReposetory
    {
        Task<List<Book>> GetAllBooksAsync();

        Task<Book> GetBookCodeByNameAsync(string book);

        Task<Book> GetBookByIdAsync(int id);
        Task<bool> AddBookAsync(Book b);
        Task<bool> UpdateBookAsync(int id, Book b);
        Task<bool> DeleteBookAsync(int id);
    }
}
