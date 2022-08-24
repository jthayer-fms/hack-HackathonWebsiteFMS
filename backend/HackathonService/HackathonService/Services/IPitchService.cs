using HackathonService.Dtos;

namespace HackathonService.Services
{
    public interface IPitchService
    {
        Task<Result> PitchSignUp(Guid id, User user);

        Task<Result> Vote(Guid id, User user);

        Task<Result> Unvote(Guid id, User user);
    }
}
