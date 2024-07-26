﻿using Application.Commons.Bases;
using Application.Dtos.Request;
using Application.Dtos.Response;
using Application.Interfaces;
using Application.Validators.Technology;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Commons.Bases.Request;
using Infrastructure.Commons.Bases.Response;
using Infrastructure.Persistences.Interfaces;
using Utilities.Static;

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

        public async Task<BaseResponse<bool>> CreateTechnology(TechnologyRequestDto requestDto)
        {
            var response = new BaseResponse<bool>();
            var validationResult = await _validatorRules.ValidateAsync(requestDto);
            if (!validationResult.IsValid)
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_VALIDATE;
                response.Errors = validationResult.Errors;

                return response;
            }

            var technology = _mapper.Map<Technology>(requestDto);
            response.Data = await _unitOfWork.Technology.CreateAsync(technology);

            if (response.Data)
            {
                response.IsSuccess = true;
                response.Message = ReplyMessage.MESSAGE_CREATE;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_FAILED;
            }

            return response;
        }
        public async Task<BaseResponse<BaseEntityResponse<TechnologyResponseDto>>> ReadTechnologies(BaseFiltersRequest filters)
        {
            var response = new BaseResponse<BaseEntityResponse<TechnologyResponseDto>>();
            var technologies = await _unitOfWork.Technology.ReadTechnologies(filters);

            if (technologies is null)
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
                return response;
            }

            response.IsSuccess = true;
            response.Data = _mapper.Map<BaseEntityResponse<TechnologyResponseDto>>(technologies);
            response.Message = ReplyMessage.MESSAGE_QUERY;
            
            return response;
        }
        public async Task<BaseResponse<bool>> UpdateTechnology(int technologyId, TechnologyRequestDto requestDto)
        {
            var response = new BaseResponse<bool>();
            var technolgyUpdate = await TechnologyById(technologyId);

            if (technolgyUpdate.Data is null)
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
            }

            var technology = _mapper.Map<Technology>(requestDto);
            technology.Id = technologyId;
            response.Data = await _unitOfWork.Technology.UpdateAsync(technology);

            if (response.Data)
            {
                response.IsSuccess = true;
                response.Message = ReplyMessage.MESSAGE_UPDATE;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_FAILED;
            }
            return response;
        }
        public async Task<BaseResponse<bool>> DeleteTechnology(int technologyId)
        {
            var response = new BaseResponse<bool>();
            var technology = await TechnologyById(technologyId);

            if(technology.Data is null)
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
            }

            response.Data = await _unitOfWork.Technology.DeleteAsync(technologyId);

            if (response.Data)
            {
                response.IsSuccess = true;
                response.Message = ReplyMessage.MESSAGE_DELETE;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_FAILED;
            }

            return response; 
        }

        public async Task<BaseResponse<IEnumerable<TechnologySelectResponseDto>>> ListSelectTechnologies()
        {
            var response = new BaseResponse<IEnumerable<TechnologySelectResponseDto>>();
            var technologies = await _unitOfWork.Technology.GetAllAsync();

            if (technologies is null) {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
                return response;
            }
            response.IsSuccess = true;
            response.Data = _mapper.Map<IEnumerable<TechnologySelectResponseDto>>(technologies);
            response.Message = ReplyMessage.MESSAGE_QUERY;

            return response;
        }
        public async Task<BaseResponse<TechnologyResponseDto>> TechnologyById(int technologyId)
        {
            var response = new BaseResponse<TechnologyResponseDto>();
            var tecnology = await _unitOfWork.Technology.GetByIdAsync(technologyId);

            if (tecnology is null)
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
                return response;
            }

            response.IsSuccess = true;
            response.Data = _mapper.Map<TechnologyResponseDto>(tecnology);
            response.Message = ReplyMessage.MESSAGE_QUERY;

            return response;
        }

    }
}
