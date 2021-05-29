
using System.Text.Json.Serialization;

namespace EFCoreCosmosSample.Core.Entities
{
    public record BaseEntity
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
    }
}
