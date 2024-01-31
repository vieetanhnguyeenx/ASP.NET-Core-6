using AutoMapper;
using BookStore.DTO;
using BookStore.Models;
using BookStore.Repository;

namespace BookStore.Services.Implement
{
    public class BookService : IBookService
    {
        private IBookRepository repository;
        private IMapper mapper;

        public BookService(IMapper mapper, IBookRepository repository)
        {
            this.mapper = mapper;
            this.repository = repository;
        }

        public async Task<BookDTOResponse> AddBook(BookDTORequest book)
        {
            Book book1 = mapper.Map<BookDTORequest, Book>(book);
            await repository.AddBookAsync(book1);
            return mapper.Map<Book, BookDTOResponse>(book1);
        }

        public async Task DeleteBookAsync(int id)
        {
            await repository.DeleteBookAsync(id);
        }

        public async Task<BookDTOResponse> GetBookByIdAsync(int id)
        {
            return mapper.Map<Book, BookDTOResponse>(await repository.GetBookByIdAsync(id));
        }

        public async Task<List<BookDTOResponse>> GetBooksAsync()
        {
            return mapper.Map<List<Book>, List<BookDTOResponse>>(await repository.GetBooksAsync());
        }

        public async Task UpdateBookAsync(int id, BookDTORequest book)
        {
            Book book1 = mapper.Map<BookDTORequest, Book>(book);
            book1.Id = id;
            await repository.UpdateBookAsync(book1);
        }
    }
}
