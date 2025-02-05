using Library.Core.Services;
using Library.Core.Modals;
using Library.Core.Modals.ModalsDTO;
using Microsoft.AspNetCore.Mvc;
using Library.Core.Interfaces;
//using Library.Servicrs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Library.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {


        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        //שליפת כל רשימת הספרים
        [HttpGet]
        public async Task<ActionResult<Book>> GetAllBooksAsync()
        {
            var list = await _bookService.GetAllBooksAsync();
            if(list is null)
                return NotFound("empty list");
            return Ok(list);
        }


        //שליפת קוד ספר ע"פ שם ספר (מחליף את סריקת הברקוד
        [HttpGet("BookName/{BookName}")]
        public async Task<ActionResult> GetBookCodeByNameAsync(string BookName)
        {
            var bookTmp = await _bookService.GetBookCodeByNameAsync(BookName);
            if(bookTmp==-1)
               return NotFound(-1);
           return Ok(bookTmp);
        }


        //שליפת פרטי ספר ע"פ קוד
        [HttpGet("{bookCode}")]
        public async Task<ActionResult> GetBookByIdAsync(int bookCode)
        {
            var bookTmp = await _bookService.GetBookByIdAsync(bookCode);
            if (bookTmp is null)
                return NotFound("No such a book");
            return Ok(bookTmp);
        }


        //סינון רשימת ספרים לפי: קטגוריה/ לפי האם מושאל
        [HttpGet("filter")]
        public async Task<ActionResult<Book>> GetFilterListAsync([FromQuery] Ecategory? category = null, [FromQuery] bool? IsBorrowed = null)
        {
            var b = await _bookService.GetFilterListAsync(category, IsBorrowed);
            if (b != null)
                return Ok(b);
            return NotFound("Empty list");
        }


        // הוספת ספר חדש לרשימת הספרים
        [HttpPost]
        public async Task<ActionResult<bool>> PostAsync([FromBody] BookPost b)
        {

            if(await _bookService.AddBookAsync(b))
                return Ok(true);
            return Ok(false);
        }



        // עדכון ספר ע"פ קוד לפי ספר אחר שמתקבל
        [HttpPut()]
        public async Task<ActionResult<bool>> PutAsync(int id, [FromBody] BookPost b)
        {
            if(await _bookService.UpdateBookAsync(id, b))
                return Ok(true);
            return NotFound(false);
           
        }


        // מחיקת ספר ע"פ קוד
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteAsync(int id)
        {
            if(await _bookService.DeleteBookAsync(id))
                return Ok(true);
            return NotFound(false);
        }
    }
}
