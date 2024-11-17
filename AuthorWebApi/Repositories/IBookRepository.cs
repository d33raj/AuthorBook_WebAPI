using AuthorWebApi.Models;

namespace AuthorWebApi.Repositories
{
    public interface IBookRepository
    {
        public List<Book> GetAll();
        public Book GetById(int id);
        public int Add(Book book);
        public Book Update(Book book);
        public void Delete(Book book);
    }
}
