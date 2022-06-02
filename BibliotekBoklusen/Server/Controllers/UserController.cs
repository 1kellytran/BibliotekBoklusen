using Microsoft.AspNetCore.Mvc;
namespace BibliotekBoklusen.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserManager _userManager;
        public UserController(IUserManager userManager)
        {
            _userManager = userManager;
        }

        [HttpGet("getallusers")]
        public async Task<ActionResult<List<User>>> GetAllUser()
        {
            var result = await _userManager.GetAllUser();
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = _userManager.GetUser(id);

            if (user != null)
            {
                return Ok(user);
            }
            return NotFound();
        }

        [HttpGet("currentuser")]
        public async Task<ActionResult<User>> GetCurrentUser([FromQuery] string userEmail)
        {
            var currentUser = await _userManager.GetCurrentUser(userEmail);
            if (currentUser != null)
            {
                return Ok(currentUser);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ServiceResponse<User>>> UpdateUser([FromBody] UpdatedUserDto model, int id)
        {
            var result = await _userManager.UpdateUser(model, id);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] int id)
        {
            var result = await _userManager.DeleteUserFromDb(id);
            if (result != null)
            {
                return Ok();
            }
            return NotFound();
        }

        [HttpPut("ChangePassword")]
        public async Task<ActionResult> ChangePassword([FromBody] PasswordDto editPassword)
        {

            var result = await _userManager.ChangePassword(editPassword);
            if (result != null)
            {
                return Ok();
            }
            return NotFound();
        }

        [HttpGet("usersBySearch")]
        public async Task<ActionResult<List<User>>> SearchUsers(string searchText)
        {
            var result = await _userManager.SearchUsers(searchText);
            if (result != null)
            { 
                return Ok(result);
            }
            return NotFound();

        }
    }
}
