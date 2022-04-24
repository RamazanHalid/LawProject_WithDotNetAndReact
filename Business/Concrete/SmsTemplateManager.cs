using AutoMapper;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.SmsTemplateDtos;
using System.Collections.Generic;
namespace Business.Concrete
{
    public class SmsTemplateManager : ISmsTemplateService
    {
        private readonly ISmsTemplateDal _smsTemplateDal;
        private readonly ICurrentUserService _authenticatedUserInfoService;
        private readonly IMapper _mapper;
        public SmsTemplateManager(ISmsTemplateDal smsTemplateDal, IMapper mapper, ICurrentUserService authenticatedUserInfoService)
        {
            _smsTemplateDal = smsTemplateDal;
            _mapper = mapper;
            _authenticatedUserInfoService = authenticatedUserInfoService;
        }

        public IResult Add(SmsTemplateAddDto smsTemplateAddDto)
        {
            SmsTemplate smsTemplate = _mapper.Map<SmsTemplate>(smsTemplateAddDto);
            smsTemplate.LicenceId = _authenticatedUserInfoService.GetLicenceId();
            _smsTemplateDal.Add(smsTemplate);
            return new SuccessResult(Messages.AddedSuccessfuly);
        }
        public IResult Update(SmsTemplateUpdateDto smsTemplateUpdateDto)
        {
            SmsTemplate smsTemplate = _smsTemplateDal.Get(s => s.SmsTemplateId == smsTemplateUpdateDto.SmsTemplateId);
            if (smsTemplate == null)
                return new ErrorResult(Messages.TheItemDoesNotExists);
            smsTemplate.Message = smsTemplateUpdateDto.Message;
            smsTemplate.SmsHeader = smsTemplateUpdateDto.SmsHeader;
            _smsTemplateDal.Update(smsTemplate);
            return new SuccessResult(Messages.UpdatedSuccessfuly);
        }
        public IResult Delete(int id)
        {
            var smsTemplate = _smsTemplateDal.Get(cs => cs.SmsTemplateId == id);
            if (smsTemplate == null)
                return new ErrorResult(Messages.TheItemDoesNotExists);
            _smsTemplateDal.Delete(smsTemplate);
            return new SuccessResult(Messages.DeletedSuccessfuly);
        }

        public IDataResult<List<SmsTemplateGetDto>> GetAll()
        {
            List<SmsTemplate> smsTemplatees = _smsTemplateDal.GetAll(c => c.LicenceId == _authenticatedUserInfoService.GetLicenceId());
            List<SmsTemplateGetDto> smsTemplateDtos = _mapper.Map<List<SmsTemplateGetDto>>(smsTemplatees);
            return new SuccessDataResult<List<SmsTemplateGetDto>>(smsTemplateDtos, Messages.GetAllSuccessfuly);
        }

        public IDataResult<SmsTemplateGetDto> GetById(int id)
        {
            var smsTemplate = _smsTemplateDal.Get(cs => cs.SmsTemplateId == id);
            SmsTemplateGetDto smsTemplateDto = _mapper.Map<SmsTemplateGetDto>(smsTemplate);
            if (smsTemplate == null)
                return new ErrorDataResult<SmsTemplateGetDto>(Messages.TheItemDoesNotExists);
            return new SuccessDataResult<SmsTemplateGetDto>(smsTemplateDto, Messages.GetByIdSuccessfuly);
        }
        public IDataResult<SmsTemplate> GetByLicenceId(int licenceId)
        {
            var smsTemplate = _smsTemplateDal.Get(cs => cs.LicenceId == licenceId);
            return new SuccessDataResult<SmsTemplate>(smsTemplate, Messages.GetByIdSuccessfuly);
        }
    }
}
