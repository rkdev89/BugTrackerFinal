using BugTracker_API.Data;
using BugTracker_API.Models;
using BugTracker_API.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BugTracker_API.Controllers
{
    [Route("api/UserAPI")]
    [ApiController]
    public class UserAPIController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        public UserAPIController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<BugDTO>>> GetUsers()
        {
            return Ok(await _db.Users.ToListAsync());
        }

        [HttpGet("{id::int}", Name = "GetUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UserDTO>> GetUser(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var user = await _db.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UserDTO>> CreateUser([FromBody] UserCreateDTO userDTO)
        {
            if (userDTO == null)
            {
                return BadRequest(userDTO);
            }

            User model = new()
            {
                UserName = userDTO.UserName,
                Bugs = userDTO.Bugs,
            };

            await _db.Users.AddAsync(model);
            await _db.SaveChangesAsync();

            return CreatedAtRoute("GetUser", new { id = model.Id }, model);
        }

        [HttpDelete("{id::int}", Name = "DeleteUser")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var user = await _db.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            _db.Users.Remove(user);
           await _db.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut("{id::int}", Name = "UpdateUser")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UserUpdateDTO userDTO)
        {
            if (userDTO == null || id != userDTO.Id)
            {
                return BadRequest();
            }
            User model = new()
            {
                Id = userDTO.Id,
                UserName = userDTO.UserName,
                Bugs = userDTO.Bugs,
            };
            _db.Users.Update(model);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
}
