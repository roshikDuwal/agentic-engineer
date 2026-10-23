using AgenticEngineer.Application.Features.Users.ResponseDTOs;
using AgenticEngineer.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgenticEngineer.Application.Features.Users.Mappings
{
    public class UserMappingProfile:Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User, UserDto>();
        }
    }
}
