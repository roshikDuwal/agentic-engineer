using AgenticEngineer.Application.Common.Interfaces.Messaging;
using AgenticEngineer.Application.Common.Interfaces.Repositories;
using AgenticEngineer.Application.Common.Models;
using AgenticEngineer.Application.Features.Users.ResponseDTOs;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgenticEngineer.Application.Features.Users.Queries.GetUserByIdQuery
{
    public class GetUserByIdQueryHandler : IQueryHandler<GetUserByIdQuery, Result<UserDto>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUserByIdQueryHandler(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<Result<UserDto>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);
            if (user is null) return Result<UserDto>.Failure("User not found");
            var userDto = _mapper.Map<UserDto>(user);
            return Result<UserDto>.Success(userDto);
        }
    }
}
