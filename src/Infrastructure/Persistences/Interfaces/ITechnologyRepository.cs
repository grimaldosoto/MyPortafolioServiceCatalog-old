using Domain.Entities;
using Infrastructure.Commons.Bases.Request;
using Infrastructure.Commons.Bases.Response;

namespace Infrastructure.Persistences.Interfaces
{
    public interface ITechnologyRepository
    {
        Task<bool> CreateTechnology(Technology technology);                                 // C
        Task<BaseEntityResponse<Technology>> ReadTechnologies(BaseFiltersRequest filters);   // R
        Task<bool> UpdateTechnology(Technology technology);                                 // U
        Task<bool> DeleteTechnology(int technologyId);                                      // D
        Task<IEnumerable<Technology>> ListSelectTechnologies();
        Task<Technology> TechnologyById(int id);


    }
}
