using GymPal.config;
using GymPal.Helpers;
using JWT;
using JWT.Algorithms;
using JWT.Exceptions;
using JWT.Serializers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace GymPal.Controllers
{
    [Route("api")]
    [ApiController]
    public class APIController : ControllerBase
    {
        private readonly Auth0Secrets _auth0Settings;
        private readonly JwtHelper _jwtHelper;
        public APIController(IOptions<Auth0Secrets> auth0Secrets, JwtHelper jwtHelper)
        {
            _auth0Settings = auth0Secrets.Value;
            _jwtHelper = jwtHelper;
        }

        [HttpGet("private")]
        [Authorize]
        public async Task<IActionResult> Private([FromHeader(Name = "Authorization")] string jwt)
        {
            try
            {
                var userId = await _jwtHelper.ParseUserFromJWT(jwt);
                return Ok(new { userId });
            }
            catch (TokenNotYetValidException ex)
            {
                Console.WriteLine("Token is not valid yet");
                return BadRequest(ex.Message);
            }
            catch (TokenExpiredException ex)
            {
                Console.WriteLine("Token has expired");
                return Unauthorized(ex.Message);
            }
            catch (SignatureVerificationException ex)
            {
                Console.WriteLine("Token has invalid signature");
                return Problem();
            }
        }

        [HttpGet("private-scoped")]
        [Authorize("read:messages")]
        public IResult Scoped()
        {
            return Results.Ok(new
            {
                Message = "Hello from a private-scoped endpoint!"
            });
        }

    }
}
