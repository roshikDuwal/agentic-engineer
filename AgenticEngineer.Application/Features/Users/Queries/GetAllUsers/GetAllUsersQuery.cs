using AgenticEngineer.Application.Common.Interfaces.Messaging;
using AgenticEngineer.Application.Common.Models;
using AgenticEngineer.Application.Features.Users.ResponseDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgenticEngineer.Application.Features.Users.Queries.GetAllUsers
{
    public record class GetAllUsersQuery():IQuery<Result<IEnumerable<UserDto>>>;
}
