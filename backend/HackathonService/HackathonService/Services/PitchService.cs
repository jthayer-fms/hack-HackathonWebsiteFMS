using HackathonService.Dtos;
using HackathonService.Persistency;
using HackathonService.Providers;

namespace HackathonService.Services
{
    public class PitchService : IPitchService
    {
        public IPitchProvider provider;
        public HackContext _context;

        public PitchService(IPitchProvider provider, HackContext context)
        {
            this.provider = provider;
            this._context = context;
        }
        public async Task<Result> AddPitch()
        {
            try
            {
                return new Result { success = true, message = "Not implemeneted or used" };
            }
            catch (Exception e)
            {
                return new Result { success = false, message = e.Message };
            }
        }
        public async Task<Result> PitchSignUp(Guid id, User user)
        {
            Pitch pitch = await this.provider.GetById(id);

            try
            {
                pitch.signUp(user);

                _context.SaveChanges();

                return new Result { success = true };
            }
            catch (Exception e)
            {
                return new Result { success = false, message = e.Message };
            }
        }

        public async Task<Result> Vote(Guid id, User user)
        {
            Pitch pitch = await this.provider.GetById(id);

            pitch.Vote();

            _context.SaveChanges();

            return new Result { success = true };
        }

        public async Task<Result> Unvote(Guid id, User user)
        {
            Pitch pitch = await this.provider.GetById(id);

            pitch.UnVote();

            _context.SaveChanges();

            return new Result { success = true };
        }
    }
}
