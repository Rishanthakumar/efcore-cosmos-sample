
using EFCoreCosmosSample.Core.Entities;
using EFCoreCosmosSample.Core.Interfaces.Repositories;
using EFCoreCosmosSample.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace EFCoreCosmosSample.Infrastructure.Repositories
{
    public class FamilyRepository : IFamilyRepository
    {
        private readonly FamilyContext _context;

        public FamilyRepository(FamilyContext familyContext) => _context = familyContext;

        public async Task<Family> GetByIdAsync(string id, CancellationToken cancellationToken = default)
        {
            var keyValues = new object[] { id };
            var family =  await this._context.Set<Family>().FindAsync(keyValues, cancellationToken);
            return family;
        }
        public async Task<Family> AddAsync(Family entity, CancellationToken cancellationToken = default)
        {
            await this._context.AddAsync(entity);
            await this._context.SaveChangesAsync(cancellationToken);
            return entity;
        }

        public async Task DeleteAsync(Family entity, CancellationToken cancellationToken = default)
        {
            this._context.Remove(entity);
            await this._context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(Family entity, CancellationToken cancellationToken = default)
        {
            this._context.Update(entity);
            await this._context.SaveChangesAsync(cancellationToken);
        }

        public async Task<IReadOnlyList<Family>> ListAllAsync(CancellationToken cancellationToken = default)
        {
            Stopwatch stopwatch = new();
            stopwatch.Start();

            var families = await this._context.Families.ToListAsync();

            stopwatch.Stop();

            TimeSpan ts = stopwatch.Elapsed;

            return families;
        }
    }
}
