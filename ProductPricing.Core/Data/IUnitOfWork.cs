using ProductPricing.Core.Data.Repositories;
using ProductPricing.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductPricing.Core.Data
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity;

        void BeginTransaction();

        long Commit();

        Task<long> CommitAsync();

        void Rollback();

        void Dispose(bool disposing);
    }
}