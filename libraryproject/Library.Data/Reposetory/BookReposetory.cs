using Library.Core.Modals;
using Library.Core.Reposetory;
using Microsoft.EntityFrameworkCore;


namespace Library.Data.Reposetory
{
    public class BookReposetory : IBookReposetory
    {
        private readonly DataContext _Contex;


        public BookReposetory(DataContext data)
        {
            _Contex = data;
        }
        public async Task<List<Book>> GetAllBooksAsync()
        {
            return await _Contex.books.ToListAsync();
        }

        public async Task<Book> GetBookCodeByNameAsync(string book)
        {
           return await _Contex.books.FirstOrDefaultAsync(b => b.Name == book);
            
        }

        public async Task<Book> GetBookByIdAsync(int id)
        {
            return await _Contex.books.FirstOrDefaultAsync(book => book.Code == id);
           

        }
       
        public async Task<bool> AddBookAsync(Book b)
        {
            _Contex.books.Add(b);
            await _Contex.SaveChangesAsync();
            return true;
        }
        public async Task<bool> UpdateBookAsync(int id, Book b)
        {
            var bookToUpdate = _Contex.books.FirstOrDefault(book => book.Code == id);

            if (bookToUpdate != null)
            {
                bookToUpdate.Author = b.Author;
                bookToUpdate.Name = b.Name;
                bookToUpdate.IsBorrowing = b.IsBorrowing;
                bookToUpdate.DateOfBuying = b.DateOfBuying;
                bookToUpdate.NumOfPages = b.NumOfPages;
                bookToUpdate.Category = b.Category;
                await _Contex.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteBookAsync(int id)
        {
            var b = await _Contex.books.FirstOrDefaultAsync(b => b.Code == id);
            if (b != null)
            {
                _Contex.books.Remove(b);
                await _Contex.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
