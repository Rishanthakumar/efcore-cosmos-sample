
using System.Collections.Generic;
using System.Text.Json;

namespace EFCoreCosmosSample.Core.Entities
{
    public record Family : BaseEntity
    {
        public string LastName { get; set; }
        public IList<Parent> Parents { get; set; }
        public IList<Child> Children { get; set; }
        public Address Address { get; set; }
        public bool IsRegistered { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }

}
