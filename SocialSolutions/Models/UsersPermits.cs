namespace SocialSolutions.Models
{
    public class UsersPermits
    {
        public int Id { get; set; }

        public User User { get; set; }

        public Permit Permit { get; set; }
    }
}
