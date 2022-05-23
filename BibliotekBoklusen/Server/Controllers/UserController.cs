using BibliotekBoklusen.Server.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        public UserController(SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager,
            AppDbContext context,
            IUserManager userManager
            )
        {
            _signInManager = signInManager;
            _roleManager = roleManager;
            _context = context;
            _userManager = userManager;
        }

        [HttpGet("getallusers")]
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

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {

            var dbUser = await _context.Users
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

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

            if (currentUser != null)
            {
                return currentUser;
            }
            return null;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUserInformation([FromBody] UpdatedUserDto model, int id)
        {
            var userDb = _context.Users.Where(x => x.Id == id).FirstOrDefault();
            var authUser = _signInManager.UserManager.Users.FirstOrDefault(x => x.Email == userDb.Email);

            if (userDb != null && authUser != null)
            {
                authUser.FirstName = model.FirstName;
                authUser.LastName = model.LastName;

                userDb.FirstName = model.FirstName;
                userDb.LastName = model.LastName;
                userDb.IsActive = model.IsActive;

                if (model.IsAdmin)
                {
                    userDb.IsAdmin = true;
                    await _signInManager.UserManager.RemoveFromRoleAsync(authUser, UserRoles.Librarian);
                    await _signInManager.UserManager.AddToRoleAsync(authUser, UserRoles.Admin);
                }
                else
                {
                    userDb.IsAdmin = false;
                    await _signInManager.UserManager.RemoveFromRoleAsync(authUser, UserRoles.Admin);
                    await _signInManager.UserManager.AddToRoleAsync(authUser, UserRoles.Librarian);
                }

                _context.Update(userDb);
                await _context.SaveChangesAsync();

                _signInManager.UserManager.UpdateAsync(authUser);
                return Ok("Change successful");
            }
            return BadRequest();
        }

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

        [HttpGet("usersBySearch")]
        public async Task<List<User>> SearchUsers(string searchText)
        {
            return await _context.Users.Where(u => u.FirstName.ToLower().Contains(searchText.ToLower()) || u.LastName.ToLower().Contains(searchText.ToLower())).ToListAsync();
        }
    }
}
