using EFCoreCosmosSample.Core.Entities;
using EFCoreCosmosSample.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EFCoreCosmosSample.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FamilyController : ControllerBase
    {
        private readonly IFamliyService _familyService;

        public FamilyController(IFamliyService famliyService) => _familyService = famliyService;

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var families = await this._familyService.ListAllFamilies();
            return Ok(families);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Family family)
        {
            var savedFamily = await this._familyService.AddFamily(family);

            return Ok(savedFamily);
        }
    }
}
