using AgenticEngineer.Application.Common.Interfaces.Messaging;
using AgenticEngineer.Application.Common.Models;
using AgenticEngineer.Application.Features.Users.ResponseDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgenticEngineer.Application.Features.Users.Queries.GetUserByIdQuery
{
    public record GetUserByIdQuery(Guid Id) : IQuery<Result<UserDto>>;
    
}
