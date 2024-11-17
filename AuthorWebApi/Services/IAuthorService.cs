using AuthorWebApi.DTO;
using AuthorWebApi.Models;

namespace AuthorWebApi.Services
{
    public interface IAuthorService
    {
        public List<AuthorDto> GetAuthors();
        public AuthorDto GetAuthor(int id);
        public AuthorDto GetByName(string name);
        public AuthorDto GetAuthorByBook(int id);
        public int AddAuthor(AuthorDto authorDto);
        public bool UpdateAuthor(AuthorDto authorDto);
        public bool DeleteAuthor(int id);
    }
}
