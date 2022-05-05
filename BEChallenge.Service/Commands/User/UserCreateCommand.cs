namespace BEChallenge.Service.Commands
{
    public class UserCreateCommand
    {
		public UserCreateCommand(int id, String name, DateTime birthDate, Boolean active)
		{
			this.Id = id;
			this.Name = name;
			this.BirthDate = birthDate;
			this.Active = active;
		}

		public Int32 Id { get; private set; }
		public String Name { get; private set; }
		public DateTime BirthDate { get; private set; }
		public Boolean Active { get; private set; }
	}
}
