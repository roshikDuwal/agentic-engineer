using AgenticEngineer.Application.Common.Interfaces.Messaging;
using AgenticEngineer.Application.Common.Interfaces.Repositories;
using AgenticEngineer.Application.Common.Models;
using AgenticEngineer.Application.Features.Users.ResponseDTOs;
using AgenticEngineer.Domain.Entities;


namespace AgenticEngineer.Application.Features.Users.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : ICommandHandler<UpdateUserCommand, Result<bool>>
    {

        private readonly IUserRepository _userRepository;
        public UpdateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<Result<bool>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);
            if (user is null) return Result<bool>.Failure("User not found.");

            if (request.Email != user.Email)
            {
                var emailExists = await _userRepository.EmailExistsAsync(request.Email);
                if (emailExists) return Result<bool>.Failure("A user with this email already exists.");
            }
    
            user.Update(request.Name, request.Email);
            await _userRepository.UpdateAsync(user);
            return Result<bool>.Success(true);
        }
    }
}
