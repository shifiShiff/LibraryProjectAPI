using AutoMapper;
using Library.Core.Modals;
using Library.Core.Modals.ModalsDTO;
using Library.Core.Reposetory;
using Library.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services
{
    public class BookService : IBookService
    {
        private readonly IBookReposetory _bookReposetory;
        private readonly IMapper _mappre;

        public BookService(IBookReposetory bookreposetory, IMapper mapper)
        {
            _bookReposetory = bookreposetory;
            _mappre = mapper;
        }

        public async Task<List<Book>> GetAllBooksAsync()
        {
            return await _bookReposetory.GetAllBooksAsync();
        }


        public async Task<int> GetBookCodeByNameAsync(string book)
        {
            var mybook = await _bookReposetory.GetBookCodeByNameAsync(book);
            if (mybook != null)
                return mybook.Code;
            return -1;
        }

        public async Task<Book> GetBookByIdAsync(int id)
        {

            var mybook = await _bookReposetory.GetBookByIdAsync(id);
            if (mybook != null)
                return mybook;
            return null;
        }

        public async Task<IEnumerable<Book>> GetFilterListAsync(Ecategory? category = null, bool? IsBorrowed = null)
        {
            var BooksList = await _bookReposetory.GetAllBooksAsync();
            if (category != null)
                BooksList = BooksList.Where(book => book.Category == category).ToList();

            if (IsBorrowed != null)
                BooksList = BooksList.Where(book => book.IsBorrowing == IsBorrowed).ToList();

            return BooksList;

        }

        public async Task<bool> AddBookAsync(BookPost b)
        {
            var tmp = _mappre.Map<Book>(b);
            return await _bookReposetory.AddBookAsync(tmp);
        }
        public async Task<bool> UpdateBookAsync(int id, BookPost b)
        {
            var tmp = _mappre.Map<Book>(b);
            return await _bookReposetory.UpdateBookAsync(id, tmp);
        }
        public async Task<bool> DeleteBookAsync(int id)
        {
            return await _bookReposetory.DeleteBookAsync(id);

        }

    }
}
