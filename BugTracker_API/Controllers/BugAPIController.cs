using BugTracker_API.Data;
using BugTracker_API.Models;
using BugTracker_API.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BugTracker_API.Controllers
{
    [Route("api/BugAPI")]
    [ApiController]
    public class BugAPIController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        public BugAPIController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<BugDTO>>> GetBugs()
        {
            return Ok(await _db.Bugs.ToListAsync());
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
            var bug = await _db.Bugs.FirstOrDefaultAsync(x => x.Id == id);
            if (bug == null)
            {
                return NotFound();
            }

            return Ok(bug);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<BugDTO>> CreateBug([FromBody]BugCreateDTO bugDTO)
        {
            if (bugDTO == null)
            {
                return BadRequest(bugDTO);
            }

            Bug model = new()
            {
                Title = bugDTO.Title,
                Description = bugDTO.Description,
                DateCreated = bugDTO.DateCreated,
                Status = bugDTO.Status,
                User= bugDTO.User,
                UserId= bugDTO.UserId                
            };

            await _db.Bugs.AddAsync(model);
            await _db.SaveChangesAsync();

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
            var bug = await _db.Bugs.FirstOrDefaultAsync(x => x.Id == id);
            if (bug == null)
            {
                return NotFound();
            }

            _db.Bugs.Remove(bug);
            await _db.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut("{id::int}", Name ="UpdateBug")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateBug(int id, [FromBody]BugUpdateDTO bugDTO)
        {
            if (bugDTO == null || id != bugDTO.Id)
            {
                return BadRequest();
            }
            //var bug = BugStore.bugList.FirstOrDefault(x => x.BugId == id);
            //bug.Title = bugDTO.Title;
            //bug.Description = bugDTO.Description;
            //bug.Status = bugDTO.Status;
            //bug.DateCreated = bugDTO.DateCreated;
            //bug.User.UserId = bugDTO.User.UserId;

            Bug model = new()
            {
                Id = bugDTO.Id,
                Title = bugDTO.Title,
                Description = bugDTO.Description,
                DateCreated = bugDTO.DateCreated,
                Status = bugDTO.Status,
                User = bugDTO.User,
                UserId = bugDTO.UserId
            };

            _db.Bugs.Update(model);
            await _db.SaveChangesAsync();

            return NoContent();
        }
    }
}