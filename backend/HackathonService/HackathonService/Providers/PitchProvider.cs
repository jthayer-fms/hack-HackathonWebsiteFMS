using HackathonService.Dtos;

namespace HackathonService.Providers
{
    public class PitchProvider: IPitchProvider
    {
        public PitchProvider()
        { 
        }

        public async Task<Pitch> SignUp(Guid id, User user)
        {
            //mock the pitch dto
            var pitch = await GetById(id);
            pitch.signUp(user.name);
            return pitch;
        }

        public async Task<Pitch> GetById(Guid id)
        {
            var obj = new Pitch(Guid.NewGuid(), Guid.NewGuid(), "Hackathon Website", new User("Michael Crawford"));
            return obj;
        }

        // negative test
        public async Task<Pitch> GetByIdReturnInvalidOne(Guid id)
        {
            var obj = new Pitch(Guid.NewGuid(), Guid.NewGuid(), "Hackathon Website", new User("Michael Crawford"));
            obj.teamMembers.Add("Michael Crawford");
            return obj;
        }

    }
}
