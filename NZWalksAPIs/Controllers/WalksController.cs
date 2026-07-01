using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Identity.Client;
using NZWalksAPIs.CustomActionFilter;
using NZWalksAPIs.Model.Domain;
using NZWalksAPIs.Model.DTO;
using NZWalksAPIs.Repositories;
using System.Threading.Tasks;

namespace NZWalksAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IwalkRepository _walkrepository;

        private IMapper _mapper { get; }

        public WalksController(IMapper mapper, IwalkRepository walkrepository)
        {
            _mapper = mapper;
            _walkrepository = walkrepository;
        }

        [HttpPost]
        [ValidateModel] 
        [Authorize(Roles = "Writer, Reader")]
        public async Task<IActionResult> Create([FromBody] AddWalkRequestdto requestdto)
        {
                var walk = _mapper.Map<Walks>(requestdto);
                var createdwalk = await _walkrepository.CreateAsync(walk);
                var createdwalkdto = _mapper.Map<Walkdtos>(createdwalk);
                return Ok(createdwalkdto);
        }


        [HttpGet]
        [Authorize(Roles = "Writer, Reader")]
        public async Task<IActionResult> GetAll([FromQuery] string? filteron, [FromQuery] string? Filterquery,
            [FromQuery] string? SortBy, [FromQuery] bool? isAsending, [FromQuery] int pagenumber =1 ,
            [FromQuery] int pagesize  =1000)
        {
            var result = await _walkrepository.GetAllAsync(filteron,Filterquery, SortBy,isAsending ?? true, pagenumber, pagesize);
            return Ok(_mapper.Map<List<Walkdtos>>(result));
        }

        [HttpGet]
        [Route("{id:guid}")]
        [Authorize(Roles = "Writer, Reader")]
        public async Task<IActionResult> GetbyId([FromRoute] Guid id)
        {
            var result = await _walkrepository.GetbyId(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<Walkdtos>(result));
        }

        [HttpPut]
        [Route("{id:guid}")]
        [ValidateModel]
        [Authorize(Roles = "Writer, Reader")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateWalkRequestdto requestdto)
        { 
            var walk = _mapper.Map<Walks>(requestdto);
            var updatedwalk = await _walkrepository.UpdateAsync(id, walk);
            if (updatedwalk == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<Walkdtos>(updatedwalk));
            
        }

        [HttpDelete]
        [Route("{id:guid}")]
        [Authorize(Roles = "Writer, Reader")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var deletedwalk = await _walkrepository.DeleteAsync(id);
            if (deletedwalk == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<Walkdtos>(deletedwalk));
        }
    }
}
