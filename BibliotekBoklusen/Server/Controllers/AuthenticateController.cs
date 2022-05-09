//using BibliotekBoklusen.Server.Models;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.IdentityModel.Tokens;
//using System.IdentityModel.Tokens.Jwt;
//using System.Security.Claims;
//using System.Text;

//// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

//namespace BibliotekBoklusen.Server.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class AuthenticateController : ControllerBase
//    {
//        private readonly SignInManager<ApplicationUser> _signInManager;
//        private readonly RoleManager<IdentityRole> _roleManager;
//        private readonly IConfiguration _configuration;
//        private readonly AppDbContext _appDbContext;

//        public AuthenticateController(SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration, AppDbContext appDbContext)
//        {
//            _signInManager = signInManager;
//            _roleManager = roleManager;
//            _configuration = configuration;
//            _appDbContext = appDbContext;
//        }
     

      
//        private JwtSecurityToken GetToken(List<Claim> authClaims)
//        {
//            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));

//            var token = new JwtSecurityToken(
//                issuer: _configuration["JWT:ValidIssuer"],
//                audience: _configuration["JWT:ValidAudience"],
//                expires: DateTime.Now.AddHours(3),
//                claims: authClaims,
//                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
//                );

//            return token;
//        }
//    }
//}
