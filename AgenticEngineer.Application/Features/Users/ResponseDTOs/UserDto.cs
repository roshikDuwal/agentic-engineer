using System;
using System.Collections.Generic;
using System.Text;

namespace AgenticEngineer.Application.Features.Users.ResponseDTOs
{
    public record UserDto(Guid Id, string Name, string Email, DateTime CreatedAt);
}
