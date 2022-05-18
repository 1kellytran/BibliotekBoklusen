using BibliotekBoklusen.Server.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BibliotekBoklusen.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly AppDbContext _context;
        private readonly IUserManager _userManager;

        public UserController(SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager, AppDbContext context, IUserManager userManager)
        {
            _signInManager = signInManager;
            _roleManager = roleManager;
            _context = context;
            _userManager = userManager;
        }

        [HttpGet]
        public ActionResult<List<User>> GetAllUser()
        {
            var result = _context.Users.ToList();
            if (result == null)

            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpGet("users")]
        public async Task<ActionResult<ServiceResponse<List<User>>>> SearchForMembers([FromQuery] string searchText)
        {
            var result = await _userManager.SearchForMembers(searchText);
            return Ok(result);
        }

        // get a specific user
        // GET api/UserController>/id
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {

            var dbUser = _context.Users
                .Where(x => x.Id == id)
                .FirstOrDefault();

            if (dbUser != null)
            {
                return dbUser;
            }

            return BadRequest();
        }

        [HttpGet("currentuser")]
        public async Task<User> GetCurrentUser([FromQuery] string userEmail)
        {
            var currentUser = await _userManager.GetCurrentUser(userEmail);
            return currentUser;
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]

        public async Task<IActionResult> UpdateUserInformation([FromBody] UpdatedUserDto model, int id)
        {
            var userDb = _context.Users.Where(x => x.Id == id).FirstOrDefault();
            if (userDb != null)
            {
                userDb.FirstName = model.FirstName;
                userDb.LastName = model.LastName;

                _context.Update(userDb);
                await _context.SaveChangesAsync();

                var AuthUser = _signInManager.UserManager.Users.FirstOrDefault(x => x.Email == userDb.Email);
                if (AuthUser != null)
                    AuthUser.FirstName = model.FirstName;
                AuthUser.LastName = model.LastName;
                _signInManager.UserManager.UpdateAsync(AuthUser);
                return Ok("Change successful");
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

        //// DELETE api/<UserController>/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteUser([FromRoute]int id)
        //{
        //    var userDb =  _context.Users.Where(x => x.Id == id).FirstOrDefault();
        //    if(userDb != null)
        //    {
        //        var user =  _signInManager.UserManager.Users.FirstOrDefault(x => x.Email == userDb.Email);
        //        if (user != null)
        //        {
        //            await _signInManager.UserManager.DeleteAsync(user);
        //            _context.Remove(user);
        //            await _context.SaveChangesAsync();
        //            return Ok("User Deleted");
        //        }

        //    }

        //    return BadRequest("User could not be deleted");
        //}

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] int id)
        {
            await _userManager.DeleteUserFromDb(id);

            return Ok("User has been deleted");

        }


        [HttpPost]

        public async Task<IActionResult> ProductLoan(Product productToAdd)
        {
            var email = "bnma@hotmail.com";
            var user = _signInManager.UserManager.Users.FirstOrDefault(p => p.Email == email);
            if (user != null)
            {
                var dbUser = _context.Users.FirstOrDefault(u => u.Email == email);
                Reservation reservationModel = new()
                {
                    Product = productToAdd,
                    User = dbUser,
                };
                var result = _context.Reservations.Add(reservationModel);
                if (result != null)
                {
                    return Ok("Product has been added!!");
                }
            }
            return BadRequest("User was not found :(");
        }
    }
}
