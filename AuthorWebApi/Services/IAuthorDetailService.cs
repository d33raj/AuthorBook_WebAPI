using AuthorWebApi.DTO;
using AuthorWebApi.Models;

namespace AuthorWebApi.Services
{
    public interface IAuthorDetailService
    {
        public List<AuthorDetailsDto> GetAllAuthorsDetails();
        public AuthorDetailsDto GetAuthorDetails(int id);
        public int AddAuthorDetails(AuthorDetailsDto authorDetailDto);
        public bool UpdateAuthorDetails(AuthorDetailsDto authorDetailDto);
        public bool DeleteAuthorDetails(int id);
    }
}
