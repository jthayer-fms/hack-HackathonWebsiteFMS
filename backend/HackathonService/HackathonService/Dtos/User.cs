namespace HackathonService.Dtos
{
    public class User
    {
        public Guid id { get; set; }
        public string name { get; set; }

        public string? email { get; set; }

        public User(string name)
        {
            this.name = name;
        }
    }
}