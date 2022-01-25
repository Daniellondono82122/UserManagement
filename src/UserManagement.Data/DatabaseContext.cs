namespace UserManagement.Data
{
    using Domain.Interfaces.Data;
    using Domain.Model;
    using Microsoft.EntityFrameworkCore;
    using Data.Extensions;

    public class DatabaseContext : DbContext, IDatabaseContext
    {
        private bool _disposed;
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Country> Countries { get; set; } = null!;
        public DbSet<State> States { get; set; } = null!;
        public DbSet<City> Cities { get; set; } = null!;
        private readonly string _connection;

        public DatabaseContext(DbContextOptions options) : base(options)
        {
            _connection = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Code\\Coink\\UserManagement\\src\\UserManagement.Data\\UserManagementDatabase.mdf;Integrated Security=True";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connection);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyAllConfigurations<DatabaseContext>();
            modelBuilder.Entity<User>().HasKey(user => user.UserId);

            modelBuilder.Entity<City>().HasKey(city => city.CityId);
            modelBuilder.Entity<City>().HasOne(city => city.State);

            modelBuilder.Entity<State>().HasKey(state => state.StateId);
            modelBuilder.Entity<State>().HasOne(state => state.Country);
            modelBuilder.Entity<State>().HasMany(state => state.Cities)
                .WithOne(city => city.State)
                .HasForeignKey(fk => fk.StateId);

            modelBuilder.Entity<Country>().HasKey(country => country.CountryId);
            modelBuilder.Entity<Country>().HasMany(country => country.States)
                .WithOne(state => state.Country)
                .HasForeignKey(fk => fk.CountryId);
        }

        public override void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                base.Dispose();
                _disposed = true;
            }
        }
        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return await base.SaveChangesAsync(cancellationToken);
        }

    }
}
