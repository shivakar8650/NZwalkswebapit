using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using NZWalksAPIs.CustomActionFilter;
using NZWalksAPIs.Data;
using NZWalksAPIs.Model.Domain;
using NZWalksAPIs.Model.DTO;
using NZWalksAPIs.Repositories;
using System.Globalization;

namespace NZWalksAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly NZWalkDBContext nZWalkDBContext;
        private readonly IRegionRepository _regionRepository;
        private readonly IMapper _mapper;

        public RegionsController(NZWalkDBContext nZWalkDB, IRegionRepository regionRepository,
            IMapper mapper)
        {
            nZWalkDBContext = nZWalkDB;
            _regionRepository = regionRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles= "Reader")]

        public async Task<IActionResult> GetAll()
        {
            var regionsdomain = await _regionRepository.GetAllAsync();

            var regiondto = _mapper.Map<List<Regiondto>>(regionsdomain);

            return Ok(regiondto);

        }

        [HttpGet]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Reader")]

        public async Task<IActionResult> GetById(Guid id)
        {
            var region = await _regionRepository.GetByIdAsyn(id);
            if (region == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<Regiondto>(region));
        }


        [HttpPost]
        [ValidateModel]
        [Authorize (Roles = "Writer")]

        public async Task<IActionResult> Create([FromBody] AddRegionRequestDto requestdto)
        {
            var regiondomainrequest = _mapper.Map<Regions>(requestdto);
            regiondomainrequest = await _regionRepository.CreateAsync(regiondomainrequest);
            var regiondto = _mapper.Map<Regiondto>(regiondomainrequest);
            return CreatedAtAction(nameof(GetById), new { id = regiondto.Id }, regiondto);
        }


        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        [Authorize(Roles = "Writer")]

        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] Updateegiondto requestdto)
        {
            var regiondomainModel = _mapper.Map<Regions>(requestdto);
            regiondomainModel = await _regionRepository.UpdateAsync(id, regiondomainModel);
            if (regiondomainModel == null)
            {
                return NotFound();
            }
            ;
            var regiondto = _mapper.Map<Regiondto>(regiondomainModel);
            return Ok(regiondto);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Writer,Reader")]

        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var regiondomainModel = await _regionRepository.DeleteAsync(id);
            if (regiondomainModel == null)
            {
                return NotFound();
            }
            var regiondto = _mapper.Map<Regiondto>(regiondomainModel);
            return Ok(regiondto);

        }
    }
}
