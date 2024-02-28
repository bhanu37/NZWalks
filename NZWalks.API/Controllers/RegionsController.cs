using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.CustomActionFilters;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repositories;
using System.Text.Json;

namespace NZWalks.API.Controllers
{
    // https://localhost:portnumber/api/regions
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly NZWalksDbContext _dbContext;
        private readonly IRegionRepository _regionRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<RegionsController> logger;

        public RegionsController(NZWalksDbContext dbContext, 
            IRegionRepository regionRepository, 
            IMapper mapper,
            ILogger<RegionsController> logger)
        {
            _dbContext = dbContext;
            _regionRepository = regionRepository;
            _mapper = mapper;
            this.logger = logger;
        }

        // GET All Regions
        // GET: https://localhost:portnumber/api/regions
        [HttpGet]
        //[Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetAll()
        {
            logger.LogInformation("Get all Regions method is invoked");
            // Get data from database - domain models
            var regionsDomain = await _regionRepository.GetAllAsync();

            // Map domain models to DTOs
            var regionsDtos = _mapper.Map<List<Region>>(regionsDomain);

            // Return DTOs
            logger.LogInformation($"Finished get all Regions method with data: {JsonSerializer.Serialize(regionsDomain)}");
            return Ok(regionsDtos);
        }

        // GET Single Regions ( By id)
        // GET: https://localhost:portnumber/api/regions/{id}
        [HttpGet]
        [Route("{id:Guid}")]
        //[Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            // Get data from database - domain models
            var region = await _regionRepository.GetByIdAsync(id);

            if (region == null)
            {
                return NotFound();
            }

            // Map domain models to DTO
            var regionDto = _mapper.Map<Region>(region);

            // Return DTO
            return Ok(regionDto);
        }

        // Post to create new region
        // POST: https://localhost:portnumber/api/regions
        [HttpPost]
        [ValidateModel]
        //[Authorize(Roles = "Writer")]
        public async Task<IActionResult> Create([FromBody] AddRegionRequestDTO addRegionRequestDTO)
        {
            // Map or convert DTO to domain model
            var regionDomainModel = _mapper.Map<Region>(addRegionRequestDTO);

            // Use Domain model to create region
            regionDomainModel = await _regionRepository.CreateAsync(regionDomainModel);

            // Map domain model back to DTO
            var regionDTO = _mapper.Map<RegionDTO>(regionDomainModel);

            return CreatedAtAction(nameof(GetAll), new { Id = regionDomainModel.Id }, regionDTO);
        }

        // Update region
        // PUT: https://localhost:portnumber/api/regions/{id}
        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        //[Authorize(Roles = "Writer")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDTO updateRegionRequestDTO)
        {
            var regionsDomainModel = _mapper.Map<Region>(updateRegionRequestDTO);

            regionsDomainModel = await _regionRepository.UpdateAsync(id, regionsDomainModel);

            // Check if region exists
            if (regionsDomainModel == null)
            {
                return NotFound();
            }

            // Convert domain model to DTO
            var regionsDTO = _mapper.Map<RegionDTO>(regionsDomainModel);

            return Ok(regionsDTO);
        }

        // DELETE region
        // DELETE: https://localhost:portnumber/api/regions/{id}
        [HttpDelete]
        [Route("{id:Guid}")]
        //[Authorize(Roles = "Writer")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var regionDomainModel = await _regionRepository.DeleteAsync(id);

            if (regionDomainModel == null)
            {
                return NotFound();
            }

            // map domain model to DTO
            var regionDTO = _mapper.Map<RegionDTO>(regionDomainModel);

            // Return deleted region back
            return Ok(regionDTO);
        }
    }
}
