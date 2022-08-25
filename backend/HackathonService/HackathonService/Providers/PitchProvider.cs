using HackathonService.Dtos;
using HackathonService.Persistency;

namespace HackathonService.Providers
{
    public class PitchProvider : IPitchProvider
    {
        public HackContext _context;

        public PitchProvider(HackContext context)
        {
            _context = context;
        }

        public async Task<Pitch> SignUp(Guid id, User user)
        {
            //mock the pitch dto
            var pitch = await GetById(id);
            
            pitch.signUp(user);
            
            _context.SaveChanges();
        
            return pitch;
        }

        public async Task<Pitch> GetById(Guid id)
        {
            //  var obj =
            var pitch = await _context.Pitches.FindAsync(id);
            if (pitch != null)
            {
                return pitch;
            }
            else {
                return new Pitch(Guid.NewGuid(), Guid.NewGuid(), "Hackathon Website");
            }
        }

        // negative test
        public async Task<Pitch> GetByIdReturnInvalidOne(Guid id)
        {
            var obj = new Pitch(Guid.NewGuid(), Guid.NewGuid(), "Hackathon Website");
            var user = new User("Michael Crawford");
            obj.pitchMembers.Add(new PitchMember { pitchId = obj.id, userId = user.id });
            return obj;
        }

    }
}
