using Domain.Entities;
using Infrastructure.Commons.Bases.Request;
using Infrastructure.Commons.Bases.Response;

namespace Infrastructure.Persistences.Interfaces
{
    public interface ITechnologyRepository : IGenericRepository<Technology>
    {
        Task<BaseEntityResponse<Technology>> ReadTechnologies(BaseFiltersRequest filters);   // R
    }
}
