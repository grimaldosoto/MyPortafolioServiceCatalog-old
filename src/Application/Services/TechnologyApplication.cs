using Application.Commons.Bases;
using Application.Dtos.Request;
using Application.Dtos.Response;
using Application.Interfaces;
using Application.Validators.Technology;
using AutoMapper;
using Infrastructure.Commons.Bases.Request;
using Infrastructure.Commons.Bases.Response;
using Infrastructure.Persistences.Interfaces;

namespace Application.Services
{
    public class TechnologyApplication : ITechnologyApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly TechnologyValidator _validatorRules;

        public TechnologyApplication(IUnitOfWork unitOfWork, IMapper mapper, TechnologyValidator validatorRules)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validatorRules = validatorRules;
        }

        public Task<BaseResponse<bool>> CreateTechnology(TechnologyRequestDto requestDto)
        {
            throw new NotImplementedException();
        }
        public Task<BaseResponse<BaseEntityResponse<TechnologyResponseDto>>> ReadTechnologies(BaseFiltersRequest filters)
        {
            throw new NotImplementedException();
        }
        public Task<BaseResponse<bool>> UpdateTechnology(int technologyId, TechnologyRequestDto requestDto)
        {
            throw new NotImplementedException();
        }
        public Task<BaseResponse<bool>> DeleteTechnology(int technologyId)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<IEnumerable<TechnologySelectResponseDto>>> ListSelectTechnologies()
        {
            throw new NotImplementedException();
        }
        public Task<BaseResponse<TechnologyResponseDto>> TechnologyById(int technologyId)
        {
            throw new NotImplementedException();
        }

    }
}
