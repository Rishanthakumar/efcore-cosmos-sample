using EFCoreCosmosSample.Core.Entities;
using EFCoreCosmosSample.Core.Interfaces.Repositories;
using EFCoreCosmosSample.Core.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EFCoreCosmosSample.Core.Services
{
    public class FamilyService : IFamliyService
    {
        private readonly IFamilyRepository _familyRepository;
        public FamilyService(IFamilyRepository familyRepository) => _familyRepository = familyRepository;

        public async Task<Family> AddFamily(Family family)
        {
            return await this._familyRepository.AddAsync(family);
        }

        public async Task<IReadOnlyList<Family>> ListAllFamilies()
        {
            return await this._familyRepository.ListAllAsync();
        }

        public async Task<Family> GetFamily(string familyId)
        {
            return await this._familyRepository.GetByIdAsync(familyId);
        }

        public async Task UpdateFamily(Family family)
        {
            await this._familyRepository.UpdateAsync(family);
        }

        public async Task DeleteFamily(string familyId)
        {
            var family = await this._familyRepository.GetByIdAsync(familyId);
            await this._familyRepository.DeleteAsync(family);
        }
    }
}
