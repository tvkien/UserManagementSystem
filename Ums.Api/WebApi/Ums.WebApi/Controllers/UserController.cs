using System;
using System.Threading.Tasks;
using Ums.Application.Features.Users.Commands.CreateUser;
using Ums.Application.Features.Users.Commands.DeleteUserById;
using Ums.Application.Features.Users.Commands.UpdateUser;
using Ums.Application.Features.Users.Queries.GetAllUsers;
using Ums.Application.Features.Users.Queries.GetDataUsersToExport;
using Ums.Application.Features.Users.Queries.GetUserByEmail;
using Ums.Application.Features.Users.Queries.GetUserById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Ums.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class UserController : BaseApiController
    {
        public UserController(IMediator mediator) : base(mediator) { }

        [HttpGet("get-user-by-id/{id}")]
        public async Task<IActionResult> GetUserByIdAsync(Guid id)
        {
            var response = await mediator.Send(new GetUserByIdQuery { Id = id });
            return Ok(response);
        }

        [HttpGet("get-user-by-email/{email}")]
        public async Task<IActionResult> GetUserByEmailAsync(string email)
        {
            var response = await mediator.Send(new GetUserByEmailQuery { Email = email });
            return Ok(response);
        }

        [HttpGet("get-all-users")]
        public async Task<IActionResult> GetAllUsersAsync()
        {
            var response = await mediator.Send(new GetAllUsersQuery());
            return Ok(response);
        }

        [HttpGet("get-users-to-export")]
        public async Task<IActionResult> GetDataUsersToExportAsync()
        {
            var response = await mediator.Send(new GetDataUsersToExportQuery());
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(CreateUserCommand command)
        {
            var response = await mediator.Send(command);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(Guid id, UpdateUserCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            var response = await mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var response = await mediator.Send(new DeleteUserByIdCommand { Id = id });
            return Ok(response);
        }
    }
}