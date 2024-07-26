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
        public TechnologyRepository(MyPortaLiveContext context) : base(context) { }

        public async Task<BaseEntityResponse<Technology>> ReadTechnologies(BaseFiltersRequest filters)
        {
            var response = new BaseEntityResponse<Technology>();

            var technologies = GetEntityQuery();
            
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
            if (filters.Sort is null) filters.Sort = "Id";

            // ==> EndFiltros

            response.TotalRecords = await technologies.CountAsync();
            response.Items = await Ordering(filters, technologies, !(bool)filters.Download!).ToListAsync();

            return response;
        }



    }
}
