using HackathonService.Dtos;

namespace HackathonService.Services
{
    public interface IPitchService
    {
        Task<signUpResult> pitchSignUp(Guid id, User user);
    }
}
