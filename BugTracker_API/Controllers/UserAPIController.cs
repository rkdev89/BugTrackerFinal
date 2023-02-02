using AutoMapper;
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
        private readonly IMapper _mapper;

        public UserAPIController(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsers()
        {
            IEnumerable<User> userList = await _db.Users.ToListAsync();
            return Ok(_mapper.Map<List<UserDTO>>(userList));
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

            return Ok(_mapper.Map<UserDTO>(user));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UserDTO>> CreateUser([FromBody] UserCreateDTO createDTO)
        {
            if (createDTO == null)
            {
                return BadRequest(createDTO);
            }

            User model = _mapper.Map<User>(createDTO);

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
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UserUpdateDTO updateDTO)
        {
            if (updateDTO == null || id != updateDTO.Id)
            {
                return BadRequest();
            }
            User model = _mapper.Map<User>(updateDTO);

            _db.Users.Update(model);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
}
