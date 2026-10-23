using AgenticEngineer.Application.Common.Interfaces.Messaging;
using AgenticEngineer.Application.Common.Interfaces.Repositories;
using AgenticEngineer.Application.Common.Models;
using AgenticEngineer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgenticEngineer.Application.Features.Users.Commands.RegisterUser
{
    public class RegisterUserCommandHandler : ICommandHandler<RegisterUserCommand, Result<Guid>>
    {
        private readonly IUserRepository _userRepository;
        public RegisterUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Result<Guid>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var emailExists = await _userRepository.EmailExistsAsync(request.Email);
            if (emailExists) return Result<Guid>.Failure("A user with this email already exists.");
            var user = User.Create(request.Name, request.Email);
            await _userRepository.AddAsync(user);
            return Result<Guid>.Success(user.Id);
        }
    }

}
