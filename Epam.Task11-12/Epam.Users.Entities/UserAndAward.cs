namespace Epam.Users.Entities
{
    public class UserAndAward
    {
        public int UserId { get; set; }

        public int AwardId { get; set; }

        public override string ToString()
        {
            return $"{UserId} {AwardId}";
        }
    }
}
