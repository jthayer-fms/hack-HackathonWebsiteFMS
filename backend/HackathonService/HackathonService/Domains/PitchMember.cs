namespace HackathonService.Dtos
{
    public class PitchMember
    {
        public Guid userId { get; set; }

        public User user { get; set; }

        public Guid pitchId { get; set; }

        public Pitch pitch { get; set; }
    }
}
