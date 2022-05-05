namespace BEChallenge.Service
{
    public interface ICommandHandler<in TCommand>
    {
        Task Handle(TCommand command);
    }
}
