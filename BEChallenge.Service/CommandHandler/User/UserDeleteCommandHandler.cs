using BEChallenge.CrossCutting.Exceptions;
using BEChallenge.Domain;
using BEChallenge.Domain.Entities;
using BEChallenge.Service.Commands;

namespace BEChallenge.Service.CommandHandler
{
    public class UserDeleteCommandHandler : ICommandHandler<UserDeleteCommand>
    {
        private readonly IUnitOfWork unitOfWork;

        public UserDeleteCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task Handle(UserDeleteCommand command)
        {
            Argument.ThrowIfNull(() => command);

            User user = unitOfWork.UserRepository.All().SingleOrDefault(x => x.Id == command.Id);

            if (user == null)
                throw new ValidationException("User not found");

            this.unitOfWork.UserRepository.Remove(user);

            await unitOfWork.SaveChangesAsync();

            await Task.CompletedTask;
        }
    }
}
