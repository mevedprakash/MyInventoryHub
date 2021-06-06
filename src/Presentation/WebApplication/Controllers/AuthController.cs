using DTO;
using Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
       
        private readonly ILogger<AuthController> _logger;
        private readonly IAuthenticationService authenticationService;
        private readonly IJwtService jwtService;

        public AuthController(ILogger<AuthController> logger,
            IAuthenticationService authenticationService,
            IJwtService jwtService
            )
        {
            _logger = logger;
            this.authenticationService = authenticationService;
            this.jwtService = jwtService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthResponse>> Login(AuthModel model)
        {
            var userInfo = await authenticationService.Authenticate(model.Email, model.Password);
            if (userInfo == null)
                return BadRequest("User name or password is not correct");
            var authResponse = new AuthResponse();
            authResponse.TokenExpireAt = DateTime.UtcNow.AddDays(7);
            var userClaims = new Dictionary<string, string>();
            userClaims.Add(ClaimTypes.NameIdentifier,userInfo.Id.ToString());
            foreach (var role in userInfo.Roles)
            {
                userClaims.Add(ClaimTypes.Role, role);
            }
            authResponse.AccessToken = jwtService.CreateToken(userClaims, authResponse.TokenExpireAt);
            return Ok(authResponse);
        }
    }
}
