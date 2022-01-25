namespace UserManagement.Domain.Interfaces.Data
{
    using Domain.Model;
    using Microsoft.EntityFrameworkCore;

    public interface IDatabaseContext : IDisposable
    {
        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        public DbSet<User> Users { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }
    }
}
