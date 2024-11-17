using AuthorWebApi.Data;
using AuthorWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthorWebApi.Repositories
{
    public class AuthorDetailRepository : IAuthorDetailRepository
    {
        private readonly AuthorContext _context;
        public AuthorDetailRepository(AuthorContext context)
        {
            _context = context;
        }
        public int Add(AuthorDetail authorDetail)
        {
            _context.AuthorDetails.Add(authorDetail);
            _context.SaveChanges();
            return authorDetail.Id;
        }

        public void Delete(AuthorDetail authorDetail)
        {
            _context.AuthorDetails.Remove(authorDetail);
            _context.SaveChanges();
        }

        public List<AuthorDetail> GetAll()
        {
            return _context.AuthorDetails.ToList();
        }

        public AuthorDetail GetById(int id)
        {
            return _context.AuthorDetails.AsNoTracking().FirstOrDefault(a => a.Id == id);
        }

        public AuthorDetail Update(AuthorDetail authorDetail)
        {
            _context.AuthorDetails.Update(authorDetail);
            _context.SaveChanges();
            return authorDetail;
        }
    }
}
