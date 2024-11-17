using AuthorWebApi.Data;
using AuthorWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthorWebApi.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly AuthorContext _context;

        public AuthorRepository(AuthorContext context)
        {
            _context = context;
        }
        public int Add(Author author)
        {
            _context.Authors.Add(author);
            _context.SaveChanges();
            return author.AuthorId;
        }

        public void Delete(Author author)
        {
            _context.Authors.Remove(author);
            _context.SaveChanges();
        }

        public List<Author> GetAll()
        {
            return _context.Authors.ToList();
        }

        public Author GetById(int id)
        {
            return _context.Authors.AsNoTracking().FirstOrDefault(a=>a.AuthorId==id);
        }

        public Author Update(Author author)
        {
            _context.Authors.Update(author);
            _context.SaveChanges();
            return author;
        }
    }
}
