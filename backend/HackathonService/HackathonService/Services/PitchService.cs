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
        public async Task<Result> PitchSignUp(Guid id, User user)
        {
           Pitch pitch =  await this.provider.GetById(id);

            try {
                pitch.signUp(user.name);
                return new Result { success = true };
            }
            catch (Exception e)
            {
                return new Result { success = false , message = e.Message};
            }         
        }

        public async Task<Result> Vote(Guid id, User user)
        {
            Pitch pitch = await this.provider.GetById(id);

            pitch.Vote();
            
            return new Result { success = true };
        }

        public async Task<Result> Unvote(Guid id, User user)
        {
            Pitch pitch = await this.provider.GetById(id);

            pitch.UnVote();

            return new Result { success = true };
        }
    }
}
