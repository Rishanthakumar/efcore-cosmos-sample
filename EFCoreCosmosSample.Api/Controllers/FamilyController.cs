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
        public async Task<IActionResult> List()
        {
            var families = await this._familyService.ListAllFamilies();
            return Ok(families);
        }

        [HttpGet, Route("{familyId}")]
        public async Task<IActionResult> Get([FromRoute] string familyId)
        {
            var family = await this._familyService.GetFamily(familyId);
            return Ok(family);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Family family)
        {
            var savedFamily = await this._familyService.AddFamily(family);

            return Ok(savedFamily);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Family family)
        {
            await this._familyService.UpdateFamily(family);

            return Ok();
        }

        [HttpDelete, Route("{familyId}")]
        public async Task<IActionResult> Delete([FromRoute] string familyId)
        {
            await this._familyService.DeleteFamily(familyId);

            return Ok();
        }
    }
}
