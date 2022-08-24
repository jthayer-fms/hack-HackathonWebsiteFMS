using HackathonService.Dtos;
using HackathonService.Providers;

namespace HackathonService.Services
{
    public class PitchService: IPitchService
    {
        public IPitchProvider provider;

        public PitchService(IPitchProvider provider)
        {
            this.provider = provider;
        }
        public async Task<signUpResult> pitchSignUp(Guid id, User user)
        {
           Pitch pitch =  await this.provider.GetById(id);

            try {
                pitch.signUp(user);
                return new signUpResult { success = true };
            }
            catch (Exception e)
            {
                return new signUpResult { success = false };
            }
          
            
        }

    }
}
