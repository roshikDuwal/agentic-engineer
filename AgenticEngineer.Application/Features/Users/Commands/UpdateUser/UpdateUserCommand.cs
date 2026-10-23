using AgenticEngineer.Application.Common.Interfaces.Messaging;
using AgenticEngineer.Application.Common.Models;
using AgenticEngineer.Application.Features.Users.ResponseDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgenticEngineer.Application.Features.Users.Commands.UpdateUser
{
    public record UpdateUserCommand(Guid Id,string Name,string Email) : ICommand<Result<bool>>;
}
