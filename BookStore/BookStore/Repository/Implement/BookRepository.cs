using AutoMapper;
using BookStore.Context;
using BookStore.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Repository.Implement
{
    public class BookRepository : IBookRepository
    {
        private IMapper mapper;
        private BookStoreContext context;
        public BookRepository(IMapper mapper, BookStoreContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }

        public async Task<int> AddBookAsync(Book book)
        {
            context.Books.Add(book);
            await context.SaveChangesAsync(CancellationToken.None);
            return book.Id;
        }

        public async Task DeleteBookAsync(int id)
        {
            Book book = context.Books.SingleOrDefault(x => x.Id == id);
            if (book != null)
            {
                book.IsActive = false;
                await context.SaveChangesAsync(CancellationToken.None);
            }
        }

        public async Task<Book> GetBookByIdAsync(int id)
        {
            return await context.Books.FindAsync(id);
        }

        public async Task<List<Book>> GetBooksAsync()
        {
            return await context.Books.Where(b => b.IsActive).ToListAsync();
        }

        public async Task UpdateBookAsync(Book book)
        {
            context.Entry<Book>(book).State =
                Microsoft.EntityFrameworkCore.EntityState.Modified;
            await context.SaveChangesAsync(CancellationToken.None);
        }
    }
}
