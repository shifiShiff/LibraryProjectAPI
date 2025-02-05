using Library.Core.Modals;
using Library.Core.Modals.ModalsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Services
{
    public interface IBookService
    {
         Task<List<Book>> GetAllBooksAsync();

        Task<int> GetBookCodeByNameAsync(string book);
        Task<Book> GetBookByIdAsync(int id);
        Task<IEnumerable<Book>> GetFilterListAsync(Ecategory? category = null, bool? IsBorrowed = null);
        Task<bool> AddBookAsync(BookPost b);
        Task<bool> UpdateBookAsync(int id, BookPost b);
        Task<bool> DeleteBookAsync(int id);
    }
}
