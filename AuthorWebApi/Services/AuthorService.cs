using AuthorWebApi.DTO;
using AuthorWebApi.Exceptions;
using AuthorWebApi.Models;
using AuthorWebApi.Repositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace AuthorWebApi.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IRepository<Author> _authorRepository;
        private readonly IMapper _mapper;

        public AuthorService(IRepository<Author> authorRepository,IMapper mapper)
        {
            _authorRepository = authorRepository;  
            _mapper = mapper;
        }
        public int AddAuthor(AuthorDto authorDto)
        {
            var author=_mapper.Map<Author>(authorDto);
            _authorRepository.Add(author);
            return author.AuthorId;
        }

        public bool DeleteAuthor(int id)
        {
            var existingAuthor = _authorRepository.GetById(id);
            if (existingAuthor != null)
            {
                _authorRepository.Delete(existingAuthor);
                return true;
            }
            throw new AuthorNotFoundException("No such Author Found");
        }

        public AuthorDto GetAuthor(int id)
        {
            var authors= _authorRepository.GetAll().Include(b => b.Book).Where(a=>a.AuthorId==id).FirstOrDefault();
            if (authors != null)
            {
                var authorDto = _mapper.Map<AuthorDto>(authors);
                return authorDto;
            }
            throw new AuthorNotFoundException("No such Author Found");
        }

        public AuthorDto GetByName(string name)
        {
            var author = _authorRepository.GetAll().Include(b => b.Book).FirstOrDefault(a => a.AuthorName==name);
            if (author != null)
            {
                var authorDto = _mapper.Map<AuthorDto>(author);
                return authorDto;
            }
            throw new AuthorNotFoundException("No such Author Found");
        }

        public List<AuthorDto> GetAuthors()
        {
            var author=_authorRepository.GetAll().Include(b => b.Book).Include(a => a.AuthorDetail).ToList();
            List<AuthorDto> authorDto = _mapper.Map <List<AuthorDto>> (author);
            return authorDto;
        }
       
        public bool UpdateAuthor(AuthorDto authorDto)
        {
            var existingAuthor = _authorRepository.GetAll().AsNoTracking().FirstOrDefault(a=>a.AuthorId==authorDto.AuthorId);
            if(existingAuthor != null)
            {
                var author = _mapper.Map<Author>(authorDto);
                _authorRepository.Update(author);
                return true;
            }
            throw new AuthorNotFoundException("No such Author Found");
        }

        public AuthorDto GetAuthorByBook(int id)
        {
            var author= _authorRepository.GetAll().Include(book=>book.Book).FirstOrDefault(a=>a.Book.Any(b=>b.Id==id));
            if (author != null)
            {
                var authorDto = _mapper.Map<AuthorDto>(author);
                return authorDto;
            }
            throw new AuthorNotFoundException("No such Author Found");
        }
    }
}
