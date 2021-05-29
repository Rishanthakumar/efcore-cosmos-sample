
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace EFCoreCosmosSample.Core.Entities
{
    public record Family
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
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
