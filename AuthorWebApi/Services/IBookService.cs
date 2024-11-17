using AuthorWebApi.DTO;
using AuthorWebApi.Models;

namespace AuthorWebApi.Services
{
    public interface IBookService
    {
        public List<BookDto> GetAllBooks();
        public BookDto GetBook(int id);
        public List<BookDto> GetAuthorBooks(int id);
        public int AddBook(BookDto bookDto);
        public bool UpdateBook(BookDto bookDto);
        public bool DeleteBook(int id);
    }
}
