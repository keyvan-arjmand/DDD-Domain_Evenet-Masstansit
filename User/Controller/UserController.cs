using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using User.Application.Contracts;
using User.Application.Services.Command;
using User.Application.Services.Models;
using User.Application.Services.Query;
using User.Domain.Entities;
using User.Domain.Event;
using User.Domain.ValueObjects;

namespace User.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IRepository<Domain.Entities.User> _Service;
        private readonly IBus _bus;

        public UserController(IMediator mediator, IRepository<Domain.Entities.User> Service, IBus bus)
        {
            _mediator = mediator;
            _Service = Service;
            _bus = bus;
        }
        [HttpPost]
        public async Task<ActionResult> PostUser(CreateUserCommand model)
        {
            await _mediator.Send(model);
            return Ok();
        }
        [HttpPut]
        public async Task<ActionResult> Put(UpdateUserCommand model)
        {
            await _mediator.Send(model);
            return Ok();
        }
        //[HttpGet]
        //public async Task<List<UserDto>> GetAll()
        //{
        //    return await _mediator.Send(new GetAllUsersCommand());
        //}
        [HttpGet("{id}")]
        public async Task<UserDto> GetById(int id)
        {
            return await _mediator.Send(new GetByIdUserCommand
            {
                Id = id
            });

        }
        [HttpDelete]
        public async Task<ActionResult> Delete(ObjectId id)
        {
            await _mediator.Send(new DeleteUserCommand { Id = id });
            return Ok();
        }

    }
}
