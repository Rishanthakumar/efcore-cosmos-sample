
using System;
using System.Text.Json.Serialization;

namespace EFCoreCosmosSample.Core.Entities
{
    public record BaseEntity
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }
    }
}
