using BookStore.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Context
{
    public class BookStoreContext : DbContext
    {
        public BookStoreContext(DbContextOptions<BookStoreContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .Property(b => b.IsActive)
                .HasDefaultValue(true);
        }

        public override int SaveChanges()
        {
            var now = DateTime.UtcNow;
            foreach (var changedEntity in ChangeTracker.Entries())
            {
                if (changedEntity.Entity is IEntity entity)
                {
                    switch (changedEntity.State)
                    {
                        case EntityState.Added:
                            entity.CreatedDate = now;
                            entity.UpdatedDate = now;
                            break;

                        case EntityState.Modified:
                            Entry(entity).Property(x => x.CreatedDate).IsModified = false;
                            entity.UpdatedDate = now;
                            break;
                    }
                }
            }
            return base.SaveChanges();
        }
        /*
        public sealed override Task<int> SaveChangesAsync()
        {
            var now = DateTime.UtcNow;
            foreach (var changedEntity in ChangeTracker.Entries())
            {
                if (changedEntity.Entity is IEntity entity)
                {
                    switch (changedEntity.State)
                    {
                        case EntityState.Added:
                            entity.CreatedDate = now;
                            entity.UpdatedDate = now;
                            break;

                        case EntityState.Modified:
                            entity.UpdatedDate = now;
                            break;
                    }
                }
            }
            return this.SaveChangesAsync(cancellationToken);
        }
        */

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            var now = DateTime.UtcNow;
            foreach (var changedEntity in ChangeTracker.Entries())
            {
                if (changedEntity.Entity is IEntity entity)
                {
                    switch (changedEntity.State)
                    {
                        case EntityState.Added:
                            entity.CreatedDate = now;
                            entity.UpdatedDate = now;
                            break;

                        case EntityState.Modified:
                            Entry(entity).Property(x => x.CreatedDate).IsModified = false;
                            entity.UpdatedDate = now;
                            break;
                    }
                }
            }
            return await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
