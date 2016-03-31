using ProductPricing.Core.Data.Repositories;
using ProductPricing.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductPricing.Data.Repositories
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly IDbContext _context;
        private readonly IDbSet<TEntity> _dbEntitySet;
        private bool _disposed;

        public BaseRepository(IDbContext context)
        {
            _context = context;
            _dbEntitySet = _context.Set<TEntity>();
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _dbEntitySet.Where(x => !x.IsDeleted).ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(long id)
        {
            return await _dbEntitySet.FirstOrDefaultAsync(t => t.Id == id && !t.IsDeleted);
        }

        public void Add(TEntity entity)
        {
            _context.SetAsAdded(entity);
        }

        public void Update(TEntity entity)
        {
            _context.SetAsModified(entity);
        }

        public void Delete(TEntity entity)
        {
            _context.SetAsDeleted(entity);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                _context.Dispose();
            }
            _disposed = true;
        }
    }
}