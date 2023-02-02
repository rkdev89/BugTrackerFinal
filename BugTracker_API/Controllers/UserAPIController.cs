using AutoMapper;
using BugTracker_API.Data;
using BugTracker_API.Models;
using BugTracker_API.Models.Dto;
using BugTracker_API.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BugTracker_API.Controllers
{
    [Route("api/UserAPI")]
    [ApiController]
    public class UserAPIController : ControllerBase
    {
        private readonly IUserRepository _dbUser;
        private readonly IMapper _mapper;

        public UserAPIController(IUserRepository dbUser, IMapper mapper)
        {
            _dbUser = dbUser;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsers()
        {
            IEnumerable<User> userList = await _dbUser.GetAllAsync();
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
            var user = await _dbUser.GetAsync(x => x.Id == id);
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

            await _dbUser.CreateAsync(model);

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
            var user = await _dbUser.GetAsync(x => x.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            await _dbUser.RemoveAsync(user);

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
            
            await _dbUser.UpdateAsync(model);

            return NoContent();
        }
    }
}
