namespace HackathonService.Dtos
{
    public class HackathonEvents
    {
        public Guid id { get; set; }
        public string name { get; set; }

        public DateTime startTime { get; } = DateTime.UtcNow;

        public DateTime endTime { get; } = DateTime.UtcNow + TimeSpan.FromDays(14);
    }
}
