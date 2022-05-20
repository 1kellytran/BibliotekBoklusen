using BibliotekBoklusen.Server.Models;
using Microsoft.AspNetCore.Identity;

namespace BibliotekBoklusen.Server.Services.AuthenticateManager
{
    public class AuthenticateManager : IAuthenticateManager
    {
        //        public AuthenticateManager(SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration, AppDbContext appDbContext)
        //        {
        //            _signInManager = signInManager;
        //        }
        //        public Task<ServiceResponse<string>> Login(LoginDto userLogin)
        //        {
        //           var response = new ServiceResponse<string>();
        //        var user = await _signInManager.UserManager.FindByEmailAsync(request.Email);

        //        }

        //            if (user != null)
        //            {
        //                var result = await _signInManager.UserManager.CheckPasswordAsync(user, request.Password);

        //                if private readonly SignInManager<ApplicationUser> signInManager;

        //        (!result)
        //                {
        //                    return Unauthorized("Wrong password.");
        //    }

        //    var userRoles = await _signInManager.UserManager.GetRolesAsync(user);

        //    var authClaims = new List<Claim>
        //                {
        //                    new Claim(ClaimTypes.NameIdentifier, user.Email),
        //                    new Claim(ClaimTypes.Name, user.FirstName),
        //                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        //                };

        //                foreach (var userRole in userRoles)
        //                {
        //                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
        //                }

        //var token = GetToken(authClaims);

        //return Ok(new
        //{
        //    token = new JwtSecurityTokenHandler().WriteToken(token),
        //    expiration = token.ValidTo
        //});
        //            }
        //            return NotFound("User not found.");
        //    }
        public Task<ServiceResponse<string>> Login(LoginDto userLogin)
        {
            throw new NotImplementedException();
        }
    }
}