
namespace UserManagement.Services.Validators.Shared
{
    using System;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using Domain.Interfaces.Data;
    using Domain.Interfaces.Services;
    using Microsoft.EntityFrameworkCore;

    public class CommonValidators : ICommonValidators
    {
        private readonly IDatabaseContext _context;

        public CommonValidators(IDatabaseContext context)
        {
            _context = context;
        }

        public async Task<bool> IsExistingEntityRowAsync<TEntity>(Expression<Func<TEntity, bool>> filter) where TEntity : class
        {
            var query = _context.Set<TEntity>();
            return await query.AnyAsync(filter);
        }

        public async Task<TEntity> GetFirstOrDefaultEntityRowAsync<TEntity>(Expression<Func<TEntity, bool>> filter) where TEntity : class
        {
            var query = _context.Set<TEntity>();
            return await query.FirstOrDefaultAsync(filter);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            _context.Dispose();
        }
    }
}
