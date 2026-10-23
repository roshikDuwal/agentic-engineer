using AgenticEngineer.Application.Common.Interfaces.Messaging;
using AgenticEngineer.Application.Common.Models;
using MediatR;
using System.Windows.Input;

namespace AgenticEngineer.Application.Features.Users.Commands.RegisterUser
{
    public record RegisterUserCommand(string Name, string Email) : ICommand<Result<Guid>>;
}
