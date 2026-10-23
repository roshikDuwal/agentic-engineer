using AgenticEngineer.Application.Common.Interfaces.Messaging;
using AgenticEngineer.Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace AgenticEngineer.Application.Features.Users.Commands.DeleteUser
{
    public record DeleteUserCommand(Guid Id) : ICommand<Result<bool>>;
   
}
