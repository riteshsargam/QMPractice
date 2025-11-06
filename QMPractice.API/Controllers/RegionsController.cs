using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QMPractice.API.Data;
using QMPractice.API.Modesls.DTO;

namespace QMPractice.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly NZWalksDbContext dbContext;

        public RegionsController(NZWalksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            // Get Data from Database - Domain Models
            var regionsDomain = dbContext.Regions.ToList();

            //Map Domain Models to DTOs
            var regionDtos = new List<RegionDto>(); 
            foreach (var regionDomain in regionsDomain)
            {
                var regionDto = new RegionDto
                {
                    Id = regionDomain.Id,
                    Code = regionDomain.Code,
                    Name = regionDomain.Name,
                    RegionImageUrl = regionDomain.RegionImageUrl
                };
                regionDtos.Add(regionDto);
            }

            //Return DTOs to Client
            return Ok(regionsDomain);

        }

        //Get Region by Id
        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var regionDomain = dbContext.Regions.FirstOrDefault(x => x.Id == id);
            if (regionDomain == null)
            {
                return NotFound();
            }

            // Map/Convert Domain Model to DTO
            var regionDto = new RegionDto
            {
                Id = regionDomain.Id,
                Code = regionDomain.Code,
                Name = regionDomain.Name,
                RegionImageUrl = regionDomain.RegionImageUrl
            };

            return Ok(regionDomain);
        }
    }
}