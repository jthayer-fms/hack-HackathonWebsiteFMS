namespace HackathonService.Dtos
{
    public class  Pitch
    {
        public Pitch(Guid eventId, Guid id, string description, User creator)
        {
            this.eventId = eventId;
            this.id = id;
            this.description = description;
            this.creator = creator;
        }

        public void signUp(string user)
        {
            if (!teamMembers.Contains(user))
            {
                teamMembers?.Add(user);
            }
            else
            { 
                throw new Exception("the user signed up"); 
            }

            if (teamMembers.Count >= 4)
            {
                throw new Exception("the pitch has maximum of 4 members");
            }

        }

        public  void Vote()
        {
            votes += 1;
        }

        public  void UnVote()
        {
            votes -= 1;
        }

        public Guid eventId { get; set; }
        public Guid id { get; set; }
        public string? description { get; set; }

        public DateTime creationTime { get; } = DateTime.UtcNow;

        public User? creator { get; set; }

        public List<string>? teamMembers { get; set; } = new List<string>();

        public  int votes { get; set; } = 0;
    }
}
