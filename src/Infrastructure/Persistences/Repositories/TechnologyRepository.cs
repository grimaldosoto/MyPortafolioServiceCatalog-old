using Domain.Entities;
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
    }
}
