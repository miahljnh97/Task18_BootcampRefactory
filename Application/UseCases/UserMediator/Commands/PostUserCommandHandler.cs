using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Task18_BootcampRefactory.Application.UseCases.UserMediator.Request;

namespace Task18_BootcampRefactory.Application.UseCases.UserMediator.Commands
{
    public class PostUserCommandHandler : IRequestHandler<PostUserCommand, UserDTO>
    {
        private readonly IConfiguration _config;

        public PostUserCommandHandler(IConfiguration config)
        {
            _config = config;
        }

        public async Task<UserDTO> Handle(PostUserCommand request, CancellationToken cancellationToken)
        {
            var userLogin = AuthenticateUser(request);
            var tokenString = GenerateJSONWebToken(userLogin);

            return new UserDTO { Token = tokenString };
        }

        private Users AuthenticateUser(Users user)
        {
            var users = new List<Users>(){
                new Users(){Username="tigreal1", Password="hujan"},
                new Users(){Username="tigreal2", Password="langit"},
                new Users(){Username="tigreal3", Password="sore"},
            };

            Users userLogin = null;
            if (users.Any(x => x.Username == user.Username) && users.Any(x => x.Password == user.Password))
            {
                userLogin = users.First(x => x.Username == user.Username);
            }

            return userLogin;
        }

        private string GenerateJSONWebToken(Users userinfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(_config["Jwt:Issuer"], _config["Jwt:Issuer"], null, expires: DateTime.Now.AddMinutes(120), signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
