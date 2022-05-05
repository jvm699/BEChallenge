using BEChallenge.Domain.Entities;
using BEChallenge.Domain.View;
using BEChallenge.Service;
using BEChallenge.Service.Commands;
using BEChallenge.Service.Queries;
using BEChallenge.Service.QueryHandler;
using Microsoft.AspNetCore.Mvc;

namespace BEChallenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IQueryHandler<UserAllQuery, List<UserView>> UserAllQueryHandler;

        private readonly ICommandHandler<UserCreateCommand> UserCreateCommandHandler;
        private readonly ICommandHandler<UserUpdateCommand> UserUpdateCommandHandler;
        private readonly ICommandHandler<UserDeleteCommand> UserDeleteCommandHandler;

        public UserController(IQueryHandler<UserAllQuery, List<UserView>> userAllQueryHandler, ICommandHandler<UserCreateCommand> userCreateCommandHandler, ICommandHandler<UserUpdateCommand> userUpdateCommandHandler, ICommandHandler<UserDeleteCommand> userDeleteCommandHandler)
        {
            this.UserAllQueryHandler = userAllQueryHandler;
            this.UserCreateCommandHandler = userCreateCommandHandler;
            this.UserUpdateCommandHandler = userUpdateCommandHandler;
            this.UserDeleteCommandHandler = userDeleteCommandHandler;
        }

        //GET: api/<UserController>
        [HttpGet]
        public async Task<List<UserView>> GetAll()
        {
            return await this.UserAllQueryHandler.Handle(new UserAllQuery() { });
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]UserCreateView user)
        {
            UserCreateCommand command = new(user.Id, user.Name, user.BirthDate, true);

            await UserCreateCommandHandler.Handle(command);

            return this.Ok(new { Message = "User created successfully" });
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, bool active)
        {
            UserUpdateCommand command = new(id, active);

            await UserUpdateCommandHandler.Handle(command);

            return this.Ok(new { Message = "User edited successfully" });
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await UserDeleteCommandHandler.Handle(new UserDeleteCommand(id));

            return this.Ok(new { Message = "User successfully deleted" });
        }
    }
}
