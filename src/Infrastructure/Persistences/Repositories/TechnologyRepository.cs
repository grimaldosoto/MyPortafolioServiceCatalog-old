using Domain.Entities;
using Infrastructure.Commons.Bases.Request;
using Infrastructure.Commons.Bases.Response;
using Infrastructure.Persistences.Contexts;
using Infrastructure.Persistences.Interfaces;

namespace Infrastructure.Persistences.Repositories
{
    public class TechnologyRepository : GenericRepository<Technology>, ITechnologyRepository
    {
        private readonly MyPortaLiveContext _context;

        public TechnologyRepository(MyPortaLiveContext context)
        {
            _context = context;
        }

        public Task<bool> CreateTechnology(Technology technology)
        {
            throw new NotImplementedException();
        }

        public Task<BaseEntityResponse<Technology>> ReadTechnologies(BaseFiltersRequest filter)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateTechnology(Technology technology)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteTechnology(int technologyId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Technology>> ListSelectTechnologies()
        {
            throw new NotImplementedException();
        }

        public Task<Technology> TechnologyById(int id)
        {
            throw new NotImplementedException();
        }

    }
}
