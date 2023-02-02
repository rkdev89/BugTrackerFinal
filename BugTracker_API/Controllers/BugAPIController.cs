using AutoMapper;
using BugTracker_API.Data;
using BugTracker_API.Models;
using BugTracker_API.Models.Dto;
using BugTracker_API.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Converters;

namespace BugTracker_API.Controllers
{
    [Route("api/BugAPI")]
    [ApiController]
    public class BugAPIController : ControllerBase
    {
        private readonly IBugRepository _dbBug;
        private readonly IMapper _mapper;
        public BugAPIController(IBugRepository dbUser, IMapper mapper)
        {
            _dbBug = dbUser;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<BugDTO>>> GetBugs()
        {
            IEnumerable<Bug> bugList = await _dbBug.GetAllAsync();
            return Ok(_mapper.Map<List<BugDTO>>(bugList));
        }

        [HttpGet("{id::int}", Name ="GetBug")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<BugDTO>> GetBug(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var bug = await _dbBug.GetAsync(x => x.Id == id);
            if (bug == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<BugDTO>(bug));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<BugDTO>> CreateBug([FromBody]BugCreateDTO createDTO)
        {
            if (createDTO == null)
            {
                return BadRequest(createDTO);
            }
            Bug model = _mapper.Map<Bug>(createDTO);

            await _dbBug.CreateAsync(model);

            return CreatedAtRoute("GetBug", new {id = model.Id }, model);
        }

        [HttpDelete("{id::int}", Name="DeleteBug")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteBug(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var bug = await _dbBug.GetAsync(x => x.Id == id);
            if (bug == null)
            {
                return NotFound();
            }

            await _dbBug.RemoveAsync(bug);

            return NoContent();
        }

        [HttpPut("{id::int}", Name ="UpdateBug")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateBug(int id, [FromBody]BugUpdateDTO updateDTO)
        {
            if (updateDTO == null || id != updateDTO.Id)
            {
                return BadRequest();
            }
            Bug model = _mapper.Map<Bug>(updateDTO);    

            await _dbBug.UpdateAsync(model);

            return NoContent();
        }
    }
}