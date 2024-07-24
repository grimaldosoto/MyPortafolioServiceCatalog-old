using Application.Commons.Bases;
using Application.Dtos.Request;
using Application.Dtos.Response;
using Infrastructure.Commons.Bases.Request;
using Infrastructure.Commons.Bases.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ITechnologyApplication
    {
        Task<BaseResponse<bool>> CreateTechnology(TechnologyRequestDto requestDto);
        Task<BaseResponse<BaseEntityResponse<TechnologyResponseDto>>> ReadTechnologies(BaseFiltersRequest filters);
        Task<BaseResponse<bool>> UpdateTechnology(int technologyId, TechnologyRequestDto requestDto); 
        Task<BaseResponse<bool>> DeleteTechnology(int technologyId);

        Task<BaseResponse<IEnumerable<TechnologySelectResponseDto>>> ListSelectTechnologies();
        Task<BaseResponse<TechnologyResponseDto>> TechnologyById(int technologyId);
    }

}
