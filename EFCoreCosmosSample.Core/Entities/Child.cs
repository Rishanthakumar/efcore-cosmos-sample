
using System.Collections.Generic;

namespace EFCoreCosmosSample.Core.Entities
{
    public record Child
    {
        public string FamilyName { get; set; }
        public string FirstName { get; set; }
        public string Gender { get; set; }
        public IList<Pet> Pets { get; set; }
    }
}
