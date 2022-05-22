
using BibliotekBoklusen.Server.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BibliotekBoklusen.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly IUserManager _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly AppDbContext _appDbContext;

        public AuthenticateController(IUserManager userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration, AppDbContext appDbContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _appDbContext = appDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            var result = await _userManager.GetEmployees();
            return Ok(result);
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto request)
        {
            var user = await _signInManager.UserManager.FindByEmailAsync(request.Email);
            if (user != null)
            {
                var result = await _signInManager.UserManager.CheckPasswordAsync(user, request.Password);

                if (!result)
                {
                    return Unauthorized("Wrong password.");
                }

                var userRoles = await _signInManager.UserManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Email),
                    new Claim(ClaimTypes.Name, user.FirstName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var token = GetToken(authClaims);

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });
            }
            return NotFound("User not found.");
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto model)
        {
            var userExistsInAuthDb = await _signInManager.UserManager.FindByNameAsync(model.Email);
            var userExistsInDbContext = _appDbContext.Users.FirstOrDefault(x => x.Email == model.Email);

            if (userExistsInAuthDb != null || userExistsInDbContext != null)
                return BadRequest("User already exists.");

            if (model != null)
            {
                ApplicationUser user = new()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = model.Email
                };

                User userModel = new User()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    IsActive = true,
                    IsLibrarian = model.IsLibrarian
                };

                var result = await _signInManager.UserManager.CreateAsync(user, model.Password);

                if (!result.Succeeded)
                    return BadRequest("Något gick snett, försök igen.");

                if (model.IsLibrarian)
                {
                    if (!await _roleManager.RoleExistsAsync(UserRoles.Librarian))
                    {
                        await _roleManager.CreateAsync(new IdentityRole(UserRoles.Librarian));
                    }

                    if (await _roleManager.RoleExistsAsync(UserRoles.Librarian))
                    {
                        await _signInManager.UserManager.AddToRoleAsync(user, UserRoles.Librarian);
                    }
                }
                else
                {
                    if (!await _roleManager.RoleExistsAsync(UserRoles.Member))
                    {
                        await _roleManager.CreateAsync(new IdentityRole(UserRoles.Member));
                    }
                    if (await _roleManager.RoleExistsAsync(UserRoles.Member))
                    {
                        await _signInManager.UserManager.AddToRoleAsync(user, UserRoles.Member);
                    }
                }



                _appDbContext.Users.Add(userModel);
                var dbContextResult = await _appDbContext.SaveChangesAsync();

                if (dbContextResult != 0)
                    return Ok("User created");
            }
            return BadRequest();
        }
        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }
    }
}

