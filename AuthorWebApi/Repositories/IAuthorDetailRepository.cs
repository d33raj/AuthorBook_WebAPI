using AuthorWebApi.Models;

namespace AuthorWebApi.Repositories
{
    public interface IAuthorDetailRepository
    {
        public List<AuthorDetail> GetAll();
        public AuthorDetail GetById(int id);
        public int Add(AuthorDetail authorDetail);
        public AuthorDetail Update(AuthorDetail authorDetail);
        public void Delete(AuthorDetail authorDetail);
    }
}
