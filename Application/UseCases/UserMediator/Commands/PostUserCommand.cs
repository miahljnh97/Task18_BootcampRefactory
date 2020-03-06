using System;
using MediatR;
using Task18_BootcampRefactory.Application.UseCases.UserMediator.Request;

namespace Task18_BootcampRefactory.Application.UseCases.UserMediator.Commands
{
    public class PostUserCommand : Users, IRequest<UserDTO>
    {
        
    }

    public class Users
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
