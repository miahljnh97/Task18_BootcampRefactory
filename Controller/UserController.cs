using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Task18_BootcampRefactory.Model;

namespace Task18_BootcampRefactory.Controller
{
    [ApiController]
    [AllowAnonymous]
    [Route("authenticate")]

    public class UserController : ControllerBase
    {
        [HttpPost]

        public IActionResult Authenticate(User user)
        {
            var users = new List<User>(){
                new User(){username="tigreal1", password="hujan"},
                new User(){username="tigreal2", password="langit"},
                new User(){username="tigreal3", password="sore"},
            };

            var _user = users.Find(e => e.username == user.username);

            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenDescription = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.Name, _user.username),
                    new Claim(ClaimTypes.Sid, _user.password)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes("ini secret key nya harus panjang")), SecurityAlgorithms.HmacSha512Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescription);

            var tokenResponse = new
            {
                token = tokenHandler.WriteToken(token),
                user = _user.username
            };

            return Ok(tokenResponse);
        }
    }
}
