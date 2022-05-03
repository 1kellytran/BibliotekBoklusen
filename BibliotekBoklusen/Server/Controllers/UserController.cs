using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BibliotekBoklusen.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly AppDbContext _context;

        public UserController(SignInManager<IdentityUser> signInManager, AppDbContext context)
        {
            _signInManager = signInManager;
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<UserModel>> GetAllUser()
        {
            
            var result = _context.Users
                .ToList();
               if(result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }


        // get a specific user
        // GET api/UserController>/id
        [HttpGet("{id}")]
        public async Task<ActionResult<UserModel>> GetUser(int id)
        {
            var identityUser = _signInManager.UserManager.Users
                .Where(x => x.Id.Equals(id))
                .FirstOrDefault();
            var dbUser = _context.Users
                .Where(x => x.Email == identityUser.Email)
                .FirstOrDefault();

            if (dbUser != null)
            {
                return dbUser;
            }

            return BadRequest();
        }


        // PUT api/<UserController>/5
        [HttpPut]
        public async Task<IActionResult> UpdateUserInformation([FromBody] UpdatedUserDto model)
        {
            var identityUser = _signInManager.UserManager.Users.FirstOrDefault(x => x.Email == model.Email);
            if (identityUser != null)
            {
                var userDb = _context.Users.Where(x => x.Email == identityUser.Email).FirstOrDefault();
                userDb.FirstName = model.FirstName;
                userDb.LastName = model.LastName;
                userDb.Email = model.Email;


                _context.Update(userDb);
                await _context.SaveChangesAsync();
                identityUser.Email = model.Email;
                _signInManager.UserManager.UpdateAsync(identityUser);
                return Ok();
            }
            return BadRequest();

        }

        // PUT : Change password
        [HttpPut("ChangePassword")]
        public async Task<ActionResult> ChangePassword([FromBody] PasswordDto editPassword)
        {
            var user = _signInManager.UserManager.Users.FirstOrDefault(u => u.Email == editPassword.Email);


            if (user != null)
            {
                var result = await _signInManager.UserManager.ChangePasswordAsync(user, editPassword.OldPassword, editPassword.NewPassword);
                if (result.Succeeded)
                {
                    return Ok();
                }
            }
            return BadRequest("User not found");
        }


        // DELETE api/<UserController>/5
        [HttpDelete]
        public async Task<IActionResult> DeleteUser(string email)
        {

            var user = _signInManager.UserManager.Users.FirstOrDefault(x => x.Email == email);
            if (user != null)
            {
                await _signInManager.UserManager.DeleteAsync(user);
                _context.Remove(user);
                await _context.SaveChangesAsync();
                return Ok(user);
            }

            return BadRequest();
        }


    }
}
