using Microsoft.AspNetCore.Mvc;
using SWWalks.API.Data;
using SWWalks.API.Models.Domain;
using SWWalks.API.Models.DTOs;

namespace SWWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly SWWalksDbcontext dbcontext;

        public RegionsController(SWWalksDbcontext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var regionDomain = dbcontext.Regions.ToList();
            var regionsDTO = new List<RegionsDTO>();
            foreach (var region in regionDomain)
            {
                regionsDTO.Add(new RegionsDTO
                {
                    Id = region.Id,
                    Code = region.Code,
                    Name = region.Name,
                    RegionImageUrl = region.RegionImageUrl
                });
            }

            return Ok(regionsDTO);
        }
        [HttpGet]
        [Route("{id:guid}") ]
        public IActionResult GetById([FromRoute]Guid id)
        {
            var regiondomain = dbcontext.Regions.FirstOrDefault(x => x.Id == id);

            if(regiondomain == null)
            {
                return NotFound();
            }
            var regionsDTO = new RegionsDTO {
                Id = regiondomain.Id,
                Code = regiondomain.Code,
                Name = regiondomain.Name,
                RegionImageUrl = regiondomain.RegionImageUrl
            };

            return Ok(regionsDTO);
        }
        [HttpPost]
        public IActionResult Create([FromBody] AddRegionRequestDTO addRegion) {

            var regiondomain = new Region { 
                Name = addRegion.Name,
                Code = addRegion.Code,
                RegionImageUrl = addRegion.RegionImageUrl
            };
            dbcontext.Regions.Add(regiondomain);
            dbcontext.SaveChanges();


            var regionsDTO = new RegionsDTO
            {
                Id=regiondomain.Id,
                Code = regiondomain.Code,
                Name = regiondomain.Name,
                RegionImageUrl = regiondomain.RegionImageUrl
            };

            return CreatedAtAction(nameof(GetById), new {id = regionsDTO.Id}, regionsDTO);
        }

    }
}