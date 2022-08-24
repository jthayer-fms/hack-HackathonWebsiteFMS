namespace HackathonService.Dtos
{
    public class Pitch
    {
        public Pitch(Guid eventId, Guid id, string description, User creator)
        {
            this.eventId = eventId;
            this.id = id;
            this.description = description;
            this.creator = creator;
        }

        public Guid eventId { get; set; }
        public Guid id { get; set; }
        public string? description { get; set; }

        public DateTime creationTime { get; } = DateTime.UtcNow;

        public User? creator { get; set; }

        public List<User>? teamMembers { get; set; }

        public int votes { get; set; }
    }
}
