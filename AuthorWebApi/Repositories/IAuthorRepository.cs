using AuthorWebApi.Models;

namespace AuthorWebApi.Repositories
{
    public interface IAuthorRepository
    {
        public List<Author> GetAll();
        public Author GetById(int id);
        public int Add(Author author);
        public Author Update(Author author);
        public void Delete(Author author);
    }
}
