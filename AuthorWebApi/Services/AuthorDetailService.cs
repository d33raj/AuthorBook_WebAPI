using AuthorWebApi.DTO;
using AuthorWebApi.Models;
using AuthorWebApi.Repositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AuthorWebApi.Services
{
    public class AuthorDetailService :IAuthorDetailService
    {
        private readonly IRepository<AuthorDetail> _authorDetailRepository;
        private readonly IMapper _mapper;
        public AuthorDetailService(IRepository<AuthorDetail> authorDetailRepository,IMapper mapper)
        {
            _authorDetailRepository = authorDetailRepository;
            _mapper = mapper;
        }

        public int AddAuthorDetails(AuthorDetailsDto authorDetailDto)
        {
            var author = _mapper.Map<AuthorDetail>(authorDetailDto);
            _authorDetailRepository.Add(author);
            return author.Id;
        }

        public bool DeleteAuthorDetails(int id)
        {
            var existingAuthor = _authorDetailRepository.GetById(id);
            if (existingAuthor != null)
            {
                _authorDetailRepository.Delete(existingAuthor);
                return true;
            }
            return false;
        }

        public List<AuthorDetailsDto> GetAllAuthorsDetails()
        {
            var author = _authorDetailRepository.GetAll().Include(a => a.Author).ToList();
            List<AuthorDetailsDto> authorDto = _mapper.Map<List<AuthorDetailsDto>>(author);
            return authorDto;
        }

        public AuthorDetailsDto GetAuthorDetails(int id)
        {
            var authorDetail= _authorDetailRepository.GetAll().Include(a => a.Author).Where(ad=>ad.Id==id).FirstOrDefault();
            var authorDetailsDto = _mapper.Map<AuthorDetailsDto>(authorDetail);
            return authorDetailsDto;
        }

        public bool UpdateAuthorDetails(AuthorDetailsDto authorDetailDto)
        {
            var existingAuthor = _authorDetailRepository.GetAll().AsNoTracking().FirstOrDefault(ad => ad.Id == authorDetailDto.Id);
            if (existingAuthor != null)
            {
                var author = _mapper.Map<AuthorDetail>(authorDetailDto);
                _authorDetailRepository.Update(author);
                return true;
            }
            return false;
        }
    }
}
