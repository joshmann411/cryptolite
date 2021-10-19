using cryptolte.Models.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace cryptolte.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private ILogger _logger;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        //private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly RoleManager<IdentityRole> _roleManager;

        public IdentityController(UserManager<IdentityUser> userManager,
                                    ILoggerFactory loggerFactory,
                                    //IJwtTokenGenerator jwtTokenGenerator,
                                    RoleManager<IdentityRole> roleManager,
                                    SignInManager<IdentityUser> signInManager)
        {
            _logger = loggerFactory.CreateLogger(typeof(IdentityController));
            _userManager = userManager;
            _signInManager = signInManager;
            //_jwtTokenGenerator = jwtTokenGenerator;
            _roleManager = roleManager;
        }

        [HttpPost("Register")]
        //[Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            _logger.LogInformation($"Initiate user registration. Username: {model.Username}");

            //if (!await _roleManager.RoleExistsAsync(model.Role))
            //{
            //    await _roleManager.CreateAsync(new IdentityRole(model.Role));
            //}

            var userToCreate = new IdentityUser
            {
                Email = model.Email,
                UserName = model.Username
            };

            _logger.LogInformation($"User to create: {userToCreate} | Password: {model.Password}");

            var result = await _userManager.CreateAsync(userToCreate, model.Password);

            if (result.Succeeded)
            {
                //var userFromDb = await _userManager.FindByNameAsync(userToCreate.UserName);

                //add role to user
                //_logger.LogInformation($"Attach user from DB: {userFromDb} to role: {model.Role}");

                //await _userManager.AddToRoleAsync(userFromDb, model.Role);

                //create claim and add to the user
                //var claim = new Claim("ClaimTitle", model.ClaimTitle);

                //_logger.LogInformation($"Add claim {claim} to user from DB");

                //await _userManager.AddClaimAsync(userFromDb, claim);

                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost]
        [Route("Login")]
        //[Authorize(Policy = "CustomerRole")]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            _logger.LogInformation($"Initiate Login");

            //find out if user exists in the database (by name or email ?)
            //var user = await _userManager.FindByEmailAsync(loginModel.Email);
            var user = await _userManager.FindByNameAsync(loginModel.Username);

            if (user == null)
            {
                _logger.LogInformation($"Bad request. User is NULL");

                return BadRequest();
            }

            //check that the password provided was valid
            var result = await _signInManager.CheckPasswordSignInAsync(user, loginModel.Password, false);

            if (!result.Succeeded)
            {
                _logger.LogInformation($"Bad request. Password mismatch: {loginModel.Password}");

                return BadRequest(result);
            }

            ////grab user's claims (to be added to the generated token)
            var roles = await _userManager.GetRolesAsync(user);

            ////grab user's claims (to be added to the generated token)
            IList<Claim> claims = await _userManager.GetClaimsAsync(user);

            _logger.LogInformation($"Logged in successfully");

            return Ok(new
            {
                result = result,
                username = user.UserName,
                email = user.Email,
                token = "Token goes here"
                //token = _jwtTokenGenerator.generateToken(user, roles, claims)
                //token = JwtTokenGeneratorMachine(user)
            });
        }

        //[HttpPost("confirmEmail")]
        //public IActionResult confirmEmail(confirmEmailViewModel model)
        //{
        //    return Ok();
        //}
    }
}
