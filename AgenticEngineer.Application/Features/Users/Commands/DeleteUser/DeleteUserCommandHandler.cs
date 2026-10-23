using AgenticEngineer.Application.Common.Interfaces.Messaging;
using AgenticEngineer.Application.Common.Interfaces.Repositories;
using AgenticEngineer.Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgenticEngineer.Application.Features.Users.Commands.DeleteUser
{
    public class DeleteUserCommandHandler : ICommandHandler<DeleteUserCommand, Result<bool>>
    {
        private readonly IUserRepository _userRepository;

        public DeleteUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Result<bool>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);
            if (user is null) return Result<bool>.Failure("User not found.");

            await _userRepository.DeleteAsync(user.Id);
            return Result<bool>.Success(true);

        }
    }
}
