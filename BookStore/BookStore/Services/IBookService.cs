using BookStore.DTO;

namespace BookStore.Services
{
    public interface IBookService
    {
        Task<List<BookDTOResponse>> GetBooksAsync();
        Task<BookDTOResponse> GetBookByIdAsync(int id);
        Task<BookDTOResponse> AddBook(BookDTORequest book);
        Task UpdateBookAsync(int id, BookDTORequest book);
        Task DeleteBookAsync(int id);
    }
}
