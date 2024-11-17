using AuthorWebApi.DTO;
using AuthorWebApi.Models;
using AuthorWebApi.Repositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AuthorWebApi.Services
{
    public class BookService : IBookService
    {
        private readonly IRepository<Book> _bookRepository;
        private readonly IMapper _mapper;

        public BookService(IRepository<Book> bookRepository,IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public int AddBook(BookDto bookDto)
        {
            var book = _mapper.Map<Book>(bookDto);
            _bookRepository.Add(book);
            return book.Id;
        }

        public bool DeleteBook(int id)
        {
            var existingBook = _bookRepository.GetById(id);
            if (existingBook != null)
            {
                _bookRepository.Delete(existingBook);
                return true;
            }
            return false;
        }
        public List<BookDto> GetAllBooks()
        {
            var book = _bookRepository.GetAll().Include(a => a.Author).ToList();
            List<BookDto> booksList = _mapper.Map<List<BookDto>>(book);
            return booksList;
        }

        public List<BookDto> GetAuthorBooks(int id)
        {
            var authorBooks=_bookRepository.GetAll().Where(b=>b.AId == id).ToList();
            List<BookDto> booksList = _mapper.Map<List<BookDto>>(authorBooks);
            return booksList;
        }

        public BookDto GetBook(int id)
        {
            var book=_bookRepository.GetById(id);
            var bookDto = _mapper.Map<BookDto>(book);
            return bookDto;
        }

        public bool UpdateBook(BookDto bookDto)
        {
            var existingBook = _bookRepository.GetAll().AsNoTracking().FirstOrDefault(b => b.Id == bookDto.Id);
            if (existingBook != null)
            {
                var book = _mapper.Map<Book>(bookDto);
                _bookRepository.Update(book);
                return true;
            }
            return false;
        }
    }
}
