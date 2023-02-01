using BugTracker_API.Data;
using BugTracker_API.Logging;
using BugTracker_API.Models;
using BugTracker_API.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace BugTracker_API.Controllers
{
    [Route("api/BugAPI")]
    [ApiController]
    public class BugAPIController : ControllerBase
    {
        private readonly ILogging _logger;

        public BugAPIController(ILogging logging)
        {
            _logger = logging;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<BugDTO>> GetBugs()
        {
            _logger.Log("Getting all bugs", "");
            return Ok(BugStore.bugList);
        }

        [HttpGet("{id::int}", Name ="GetBug")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<BugDTO> GetBug(int id)
        {
            if (id == 0)
            {
                _logger.Log("Get Bug error with Id " + id, "");
                return BadRequest();
            }
            var bug = BugStore.bugList.FirstOrDefault(x => x.BugId == id);
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
        public ActionResult<BugDTO> CreateBug([FromBody]BugDTO bugDTO)
        {
            if (bugDTO == null)
            {
                return BadRequest(bugDTO);
            }
            if (bugDTO.BugId > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            bugDTO.BugId = BugStore.bugList.OrderByDescending(x => x.BugId).FirstOrDefault().BugId + 1;
            BugStore.bugList.Add(bugDTO);
            return CreatedAtRoute("GetBug", new {id = bugDTO.BugId }, bugDTO);
        }

        [HttpDelete("{id::int}", Name="DeleteBug")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteBug(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var bug = BugStore.bugList.FirstOrDefault(x => x.BugId == id);
            if (bug == null)
            {
                return NotFound();
            }
            BugStore.bugList.Remove(bug);
            return NoContent();
        }

        [HttpPut("{id::int}", Name ="UpdateBug")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UpdateBug(int id, [FromBody]BugDTO bugDTO)
        {
            if (bugDTO == null || id != bugDTO.BugId)
            {
                return BadRequest();
            }
            var bug = BugStore.bugList.FirstOrDefault(x => x.BugId == id);
            bug.Title = bugDTO.Title;
            bug.Description = bugDTO.Description;
            bug.Status = bugDTO.Status;
            bug.DateCreated = bugDTO.DateCreated;
            bug.User.UserId = bugDTO.User.UserId;

            return NoContent();
        }
    }
}