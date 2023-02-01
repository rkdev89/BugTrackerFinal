using BugTracker_API.Data;
using BugTracker_API.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace BugTracker_API.Controllers
{
    [Route("api/UserAPI")]
    [ApiController]
    public class UserAPIController : ControllerBase
    {

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<BugDTO>> GetUsers()
        {
            return Ok(UserStore.userList);
        }

        [HttpGet("{id::int}", Name = "GetUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<UserDTO> GetUser(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var user = UserStore.userList.FirstOrDefault(x => x.UserId == id);
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
        public ActionResult<UserDTO> CreateUser([FromBody] UserDTO userDTO)
        {
            if (userDTO == null)
            {
                return BadRequest(userDTO);
            }
            if (userDTO.UserId > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            userDTO.UserId = UserStore.userList.OrderByDescending(x => x.UserId).FirstOrDefault().UserId + 1;
            UserStore.userList.Add(userDTO);
            return CreatedAtRoute("GetUser", new { id = userDTO.UserId }, userDTO);
        }

        [HttpDelete("{id::int}", Name = "DeleteUser")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteUser(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var user = UserStore.userList.FirstOrDefault(x => x.UserId == id);
            if (user == null)
            {
                return NotFound();
            }
            UserStore.userList.Remove(user);
            return NoContent();
        }

        [HttpPut("{id::int}", Name = "UpdateUser")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UpdateUser(int id, [FromBody] UserDTO userDTO)
        {
            if (userDTO == null || id != userDTO.UserId)
            {
                return BadRequest();
            }
            var user = UserStore.userList.FirstOrDefault(x => x.UserId == id);
            user.UserName = userDTO.UserName;

            return NoContent();
        }
    }
}
