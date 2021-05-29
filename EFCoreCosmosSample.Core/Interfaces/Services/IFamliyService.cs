using EFCoreCosmosSample.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EFCoreCosmosSample.Core.Interfaces.Services
{
    public interface IFamliyService
    {
        Task<Family> AddFamily(Family family);
        Task<IReadOnlyList<Family>> ListAllFamilies();
    }
}
