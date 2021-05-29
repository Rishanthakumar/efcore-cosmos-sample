﻿
namespace EFCoreCosmosSample.Core.Entities
{
    public record Address
    {
        public string Street { get; set; }

        public string City { get; set; }

        public string Province { get; set; }

        public string Country { get; set; }

        public string ZipCode { get; set; }
    }
}
