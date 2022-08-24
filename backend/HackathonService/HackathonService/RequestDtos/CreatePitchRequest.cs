using HackathonService.Dtos;

namespace HackathonService.RequestDtos
{
    public class CreatePitchRequest
    {
        public Guid eventId { get; set; }

        public string? description { get; set; }

        public DateTime creationTime { get; } = DateTime.UtcNow;

        public User? Creator { get; set; }
    }
}
