using AuthorWebApi.Data;
using AuthorWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthorWebApi.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly AuthorContext _context;
        public BookRepository(AuthorContext context)
        {
            _context = context;
        }
        public int Add(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
            return book.Id;
        }

        public void Delete(Book book)
        {
            _context.Books.Remove(book);
            _context.SaveChanges();
        }

        public List<Book> GetAll()
        {
            return _context.Books.ToList();
        }

        public Book GetById(int id)
        {
            return _context.Books.AsNoTracking().FirstOrDefault(a => a.Id == id);
        }

        public Book Update(Book book)
        {
            _context.Books.Update(book);
            _context.SaveChanges();
            return book;
        }
    }
}
