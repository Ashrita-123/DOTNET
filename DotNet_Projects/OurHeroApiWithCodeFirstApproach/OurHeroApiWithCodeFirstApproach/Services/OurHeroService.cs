using OurHeroApiWithCodeFirstApproach.Entity;
using OurHeroApiWithCodeFirstApproach.Models;
//using OurHeroApiWithCodeFirstApproach.Services;

namespace OurHeroApiWithCodeFirstApproach.Services
{
    public class OurHeroService : IOurHeroService
    {
        private readonly OurHeroDbContext _db;
        public OurHeroService(OurHeroDbContext db)
        {
            _db = db;
        }

        public Task<OurHeroModel?> AddOurHero(AddUpdateOurHero obj)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteHerosByID(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<OurHeroModel>> GetAllHeros(bool? isActive)
        {
            throw new NotImplementedException();
        }

        public Task<OurHeroModel?> GetHerosByID(int id)
        {
            throw new NotImplementedException();
        }

        public Task<OurHeroModel?> UpdateOurHero(int id, AddUpdateOurHero obj)
        {
            throw new NotImplementedException();
        }
    }
}
