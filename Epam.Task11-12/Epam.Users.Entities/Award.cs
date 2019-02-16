namespace Epam.Users.Entities
{
    public class Award
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Image { get; set; }

        public override string ToString()
        {
            return $"{Id} {Title} {Image}";
        }
    }
}
