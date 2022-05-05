using BEChallenge.CrossCutting.Exceptions;
using BEChallenge.Domain;
using BEChallenge.Domain.Entities;
using BEChallenge.Service.Commands;

namespace BEChallenge.Service.CommandHandler
{
    public class UserUpdateCommandHandler : ICommandHandler<UserUpdateCommand>
    {
        private readonly IUnitOfWork unitOfWork;

        public UserUpdateCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task Handle(UserUpdateCommand command)
        {
            Argument.ThrowIfNull(() => command);

            User user = this.unitOfWork.UserRepository.All().SingleOrDefault(x => x.Id == command.Id);

            if (user == null)
                throw new ValidationException("User not found");

            user.SetActive(command.Active);

            await unitOfWork.SaveChangesAsync();

            await Task.CompletedTask;
        }
    }
}
