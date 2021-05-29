
using EFCoreCosmosSample.Core.Entities;
using EFCoreCosmosSample.Core.Interfaces.Repositories;
using EFCoreCosmosSample.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EFCoreCosmosSample.Infrastructure.Repositories
{
    public class FamilyRepository : IFamilyRepository
    {
        private readonly FamilyContext _context;

        public FamilyRepository(FamilyContext familyContext) => _context = familyContext;

        public async Task<Family> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var keyValues = new object[] { id };
            return await this._context.Set<Family>().FindAsync(keyValues, cancellationToken);
        }
        public async Task<Family> AddAsync(Family entity, CancellationToken cancellationToken = default)
        {
            entity.Id = Guid.NewGuid().ToString();
            await this._context.AddAsync(entity);
            await this._context.SaveChangesAsync(cancellationToken);
            return entity;
        }

        public async Task DeleteAsync(Family entity, CancellationToken cancellationToken = default)
        {
            this._context.Set<Family>().Remove(entity);
            await this._context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(Family entity, CancellationToken cancellationToken = default)
        {
            this._context.Entry(entity).State = EntityState.Modified;
            await this._context.SaveChangesAsync(cancellationToken);
        }

        public async Task<IReadOnlyList<Family>> ListAllAsync(CancellationToken cancellationToken = default)
        {
            return await this._context.Families.ToListAsync();
        }
    }
}
