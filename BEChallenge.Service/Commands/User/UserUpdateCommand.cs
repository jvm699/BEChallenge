namespace BEChallenge.Service.Commands
{
    public class UserUpdateCommand
    {
        public UserUpdateCommand(Int32 id, Boolean active)
        {
            this.Id = id;
            this.Active = active;
        }

        public Int32 Id { get; private set; }
        public Boolean Active { get; private set; }
    }
}
