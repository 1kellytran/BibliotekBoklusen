using BibliotekBoklusen.Server.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BibliotekBoklusen.Server.Controllers
{
    [Route("api/[controller]/[action]")]
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

        [HttpPost]
        [ActionName("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto model)
        {
            var user = await _signInManager.UserManager.FindByEmailAsync(model.Email);
            if (user != null && await _signInManager.UserManager.CheckPasswordAsync(user, model.Password))
            {
                var userRoles = await _signInManager.UserManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var token = _userManager.GetToken(authClaims);

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });
            }
            return Unauthorized();
        }
        [HttpPost]
        [ActionName("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto model)
        {
            var userExists = await _signInManager.UserManager.FindByEmailAsync(model.Email);
            if (userExists != null)
                return BadRequest("User already exists!");

            ApplicationUser user = new()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username
            };

            var result = await _signInManager.UserManager.CreateAsync(user, model.Password);
            UserModel userModel = new UserModel()
            {

                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                IsActive = true

            };

            _context.Users.Add(userModel);
            await _context.SaveChangesAsync();

            if (!result.Succeeded)
                return BadRequest("User creation failed! Please check user details and try again.");

            return Ok("User created successfully!");
        }


        [HttpPost]
        [Route("register-admin")]
        public async Task<IActionResult> RegisterAdmin([FromBody] RegisterDto model)
        {
            var userExists = await _signInManager.UserManager.FindByEmailAsync(model.Email);
            if (userExists != null)
                return BadRequest("User already exists!");

            ApplicationUser user = new()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username
            };
            var result = await _signInManager.UserManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return BadRequest("User creation failed! Please check user details and try again.");

            if (!await _roleManager.RoleExistsAsync(UserRoles.Admin))
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
            if (!await _roleManager.RoleExistsAsync(UserRoles.User))
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.User));

            if (await _roleManager.RoleExistsAsync(UserRoles.Admin))
            {
                await _signInManager.UserManager.AddToRoleAsync(user, UserRoles.Admin);
            }
            if (await _roleManager.RoleExistsAsync(UserRoles.Admin))
            {
                await _signInManager.UserManager.AddToRoleAsync(user, UserRoles.User);
            }
            UserModel userModel = new UserModel()
            {

                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                IsActive = true

            };

            _context.Users.Add(userModel);
            await _context.SaveChangesAsync();
            return Ok("User created successfully!");
        }

        [HttpPost]
        [Route("register-librarian")]
        public async Task<IActionResult> RegisterLibrarian([FromBody] RegisterDto model)
        {
            var userExists = await _signInManager.UserManager.FindByEmailAsync(model.Email);
            if (userExists != null)
                return BadRequest("User already exists!");

            ApplicationUser user = new()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username
            };
            var result = await _signInManager.UserManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return BadRequest("User creation failed! Please check user details and try again.");

            if (!await _roleManager.RoleExistsAsync(UserRoles.Librarian))
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.Librarian));
            if (!await _roleManager.RoleExistsAsync(UserRoles.User))
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.User));

            if (await _roleManager.RoleExistsAsync(UserRoles.Librarian))
            {
                await _signInManager.UserManager.AddToRoleAsync(user, UserRoles.Librarian);
            }
            if (await _roleManager.RoleExistsAsync(UserRoles.User))
            {
                await _signInManager.UserManager.AddToRoleAsync(user, UserRoles.User);
            }
            UserModel userModel = new UserModel()
            {

                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                IsActive = true

            };
            return Ok("User created successfully!");
        }


        [HttpGet]
        public ActionResult<List<UserModel>> GetAllUser()
        {
            var result = _context.Users.ToList();
            if (result == null)

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

            var dbUser = _context.Users
                .Where(x => x.Id == id)
                .FirstOrDefault();

            if (dbUser != null)
            {
                return dbUser;
            }

            return BadRequest();
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

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] int id)
        {
            var userDb = _context.Users.Where(x => x.Id == id).FirstOrDefault();
            _context.Remove(userDb);
            await _context.SaveChangesAsync();
            if (userDb != null)
            {
                var user = _signInManager.UserManager.Users.FirstOrDefault(x => x.Email == userDb.Email);
                if (user != null)
                {
                    await _signInManager.UserManager.DeleteAsync(user);
                   
                    return Ok("User Deleted");
                }
            }
            return BadRequest("User could not be deleted");
        }


        [HttpPost]

        public async Task<IActionResult> ProductLoan(ProductModel productToAdd)
        {
            var email = "bnma@hotmail.com";
            var user = _signInManager.UserManager.Users.FirstOrDefault(p => p.Email == email);
            if (user != null)
            {
                var dbUser = _context.Users.FirstOrDefault(u => u.Email == email);
                ReservationModel reservationModel = new()
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
