using AgenticEngineer.API.DTOs;
using AgenticEngineer.Application.Features.Users.Commands.RegisterUser;
using AgenticEngineer.Application.Features.Users.Queries.GetUserByIdQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AgenticEngineer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterUserRequest request)
        {
            var command = new RegisterUserCommand(request.Name, request.Email);
            var result = await _mediator.Send(command);
            if (!result.IsSuccess) return BadRequest(result.Error);
            return CreatedAtAction(nameof(RegisterUser), new { id = result.Value }, result.Value);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            var query = new GetUserByIdQuery(id);
            var result = await _mediator.Send(query);

            if (!result.IsSuccess)
                return NotFound(result.Error);

            return Ok(result.Value);
        }
    }
}
