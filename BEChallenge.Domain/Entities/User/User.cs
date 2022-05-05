namespace BEChallenge.Domain.Entities
{
    public class User
    {
        #region Constructor

        public User(Int32 id, String name, DateTime birthDate, Boolean active)
        {
            this.Id = id;
            this.Name = name;
            this.BirthDate = birthDate;
            this.Active = active;
        }

        #endregion

        #region Properties

        public Int32 Id { get; private set; }
        public String Name { get; private set; }
        public DateTime BirthDate { get; private set; }
        public bool Active { get; private set; }

        #endregion

        #region Methods

        public void SetName(String name)
        {
            this.Name = name;
        }

        public void SetBirthDate(DateTime birthDate)
        {
            this.BirthDate = birthDate;
        }

        public void SetActive(Boolean active)
        {
            this.Active = active;
        }

        #endregion
    }
}
