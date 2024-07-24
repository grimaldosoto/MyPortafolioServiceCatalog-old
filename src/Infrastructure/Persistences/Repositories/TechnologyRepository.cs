using Domain.Entities;
using Infrastructure.Commons.Bases.Request;
using Infrastructure.Commons.Bases.Response;
using Infrastructure.Persistences.Contexts;
using Infrastructure.Persistences.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistences.Repositories
{
    public class TechnologyRepository : GenericRepository<Technology>, ITechnologyRepository
    {
        private readonly MyPortaLiveContext _context;

        public TechnologyRepository(MyPortaLiveContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateTechnology(Technology technology)
        {
            await _context.AddAsync(technology);

            var recordsAffected = await _context.SaveChangesAsync();
            return recordsAffected > 0;
        }

        public async Task<BaseEntityResponse<Technology>> ReadTechnologies(BaseFiltersRequest filters)
        {
            var response = new BaseEntityResponse<Technology>();
            var technologies = (from t
                                in _context.Technologies
                                select t)
                                .AsNoTracking()
                                .AsQueryable();
            
            // ==> Filtros
            // Filtro por Nombre o Descripción
            if(filters.NumFilter is not null && !string.IsNullOrEmpty(filters.TextFilter))
            {
                switch (filters.NumFilter)
                {
                    case 1: 
                        technologies = technologies.Where(x => x.Name!.Contains(filters.TextFilter));
                        break;
                    case 2:
                        technologies = technologies.Where(x => x.Description!.Contains(filters.TextFilter));
                        break;
                }
            }
            // Ordenamiento por default TechnologyID
            if (filters.Sort is null) filters.Sort = "TechnologyId";

            // ==> EndFiltros

            response.TotalRecords = await technologies.CountAsync();
            response.Items = await Ordering(filters, technologies, !(bool)filters.Download!).ToListAsync();

            return response;
        }

        public async Task<bool> UpdateTechnology(Technology technology)
        {
            _context.Update(technology);

            var recordAffected = await _context.SaveChangesAsync();
            return recordAffected > 0;
        }

        public async Task<bool> DeleteTechnology(int technologyId)
        {
            var technology = await _context.Technologies
                .AsNoTracking().
                SingleOrDefaultAsync(x => x.TechnologyId.Equals(technologyId));

            _context.Remove(technology!);

            var recordAffected = await _context.SaveChangesAsync();
            return recordAffected > 0;
        }

        public async Task<IEnumerable<Technology>> ListSelectTechnologies()
        {
            var technologies = await _context.Technologies
                .AsNoTracking()
                .ToListAsync();

            return technologies;
        }

        public async Task<Technology> TechnologyById(int id)
        {
            var technology = await _context.Technologies
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.TechnologyId == id);

            return technology!;
        }

    }
}
