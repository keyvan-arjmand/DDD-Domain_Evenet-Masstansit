using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using User.Application.Contracts;
using User.Application.Services.Command;
using User.Application.Services.Models;
using User.Application.Services.Query;
using User.Domain.Contracs;
using User.Domain.Entities;
using User.Domain.Event;

namespace User.Controller
{
    [ApiController]
    [Route("api/[controller]")]
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
        public async Task<ActionResult> Post(UserDto model)
        {
            var user = new Domain.Entities.User
            {
                LastName = model.LastName,
                Name = model.Name,
                Id = model.Id,
                PassWord = model.PassWord,
                PhoneNumber = model.PhoneNumber,
                UserName = model.UserName,
            };
            var message = UserMap.CreateMap(user);
            await _bus.Publish(message);
            return Ok();
        }
        [HttpPut]
        public async Task<ActionResult> Put(UserDto model)
        {
            var user = new Domain.Entities.User
            {
                LastName = model.LastName,
                Name = model.Name,
                Id = model.Id,
                PassWord = model.PassWord,
                PhoneNumber = model.PhoneNumber,
                UserName = model.UserName,
            };
            var message = UserMap.DeleteMap(user);
            await _bus.Publish(message);
            return Ok();
        }
        [HttpGet]
        public async Task<List<UserDto>> GetAll()
        {
            return await _mediator.Send(new GetAllUsersCommand());
        }
        [HttpGet("{id}")]
        public async Task<UserDto> GetById(int id)
        {
            return await _mediator.Send(new GetByIdUserCommand
            {
                Id = id
            });

        }
        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var user = new Domain.Entities.User { Id = id };
            var message = UserMap.DeleteMap(user);
            await _bus.Publish(message);
            return Ok();
        }
    }
}
