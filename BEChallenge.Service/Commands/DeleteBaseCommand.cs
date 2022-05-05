namespace BEChallenge.Service.Commands
{
    public abstract class DeleteBaseCommand
    {
        protected DeleteBaseCommand(Int32 id)
        {
            this.Id = id;
        }

        public Int32 Id { get; private set; }
    }
}
