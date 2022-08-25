using HackathonService.RequestDtos;

namespace HackathonService.Dtos
{
    public class Pitch
    {
        public Pitch(Guid eventId, Guid id, string description)
        {
            this.eventId = eventId;
            this.id = id;
            this.description = description;

        }
        public Pitch(Guid eventId, CreatePitchRequest request)
        {
            this.eventId = eventId;
            this.creationTime = request.creationTime;
            this.creator = request.Creator;
            this.description = request.description;
            this.id = Guid.NewGuid();

        }

        public void signUp(User user)
        {
            if (!pitchMembers.Any(pm => pm.userId == user.id))
            {
                pitchMembers.Add(new PitchMember { userId = user.id, pitchId = id });
            }
            else
            {
                throw new Exception("the user signed up");
            }

            if (pitchMembers.Count >= 4)
            {
                throw new Exception("the pitch has maximum of 4 members");
            }

        }

        public void Vote()
        {
            votes += 1;
        }

        public void UnVote()
        {
            votes -= 1;
        }

        public Guid eventId { get; set; }

        public Guid id { get; set; }

        public string? description { get; set; }

        public DateTime creationTime { get; } = DateTime.UtcNow;

        public int creatorId { get; set; }

        public User creator { get; set; }

        public IList<PitchMember> pitchMembers { get; set; }

        public int votes { get; set; } = 0;
    }
}
