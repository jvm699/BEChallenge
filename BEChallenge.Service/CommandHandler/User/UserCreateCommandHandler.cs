using BEChallenge.CrossCutting.Exceptions;
using BEChallenge.Domain;
using BEChallenge.Domain.Entities;
using BEChallenge.Service.Commands;

namespace BEChallenge.Service.CommandHandler
{
    public class UserCreateCommandHandler : ICommandHandler<UserCreateCommand>
    {
        private readonly IUnitOfWork unitOfWork;

        public UserCreateCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task Handle(UserCreateCommand command)
        {
            Argument.ThrowIfNull(() => command);

            Boolean existUser = this.unitOfWork.UserRepository.All().Any(x => x.Name == command.Name || x.Id == command.Id);

            if (existUser)
                throw new ValidationException("User already exists");

            this.unitOfWork.UserRepository.Add(BuildNewUser(command));

            await unitOfWork.SaveChangesAsync();

            await Task.CompletedTask;
        }

        private static User BuildNewUser(UserCreateCommand command)
        {
            User newUser = new(command.Id, command.Name, command.BirthDate, true);

            return newUser;
        }
    }
}
