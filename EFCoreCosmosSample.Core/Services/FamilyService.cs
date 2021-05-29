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

        public  async Task<IReadOnlyList<Family>> ListAllFamilies()
        {
            return await this._familyRepository.ListAllAsync();
        }
    }
}
