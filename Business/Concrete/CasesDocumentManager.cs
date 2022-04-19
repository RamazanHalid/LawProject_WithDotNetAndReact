using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.CasesDocumentDtos;
using System;
using System.Collections.Generic;
namespace Business.Concrete
{
    public class CasesDocumentManager : ICasesDocumentService
    {
        private readonly ICasesDocumentDal _casesDocumentDal;
        private readonly ICurrentUserService _authenticatedUserInfoService;
        private readonly IMapper _mapper;
        public CasesDocumentManager(ICasesDocumentDal casesDocumentDal, IMapper mapper, ICurrentUserService authenticatedUserInfoService)
        {
            _casesDocumentDal = casesDocumentDal;
            _mapper = mapper;
            _authenticatedUserInfoService = authenticatedUserInfoService;
        }

        public IResult Add(CasesDocumentAddDto casesDocumentAddDto)
        {
            CasesDocument casesDocument = _mapper.Map<CasesDocument>(casesDocumentAddDto);
            casesDocument.CreatedDate = DateTime.Now;
            casesDocument.CreatorId = _authenticatedUserInfoService.GetUserId();
            _casesDocumentDal.Add(casesDocument);
            return new SuccessResult(Messages.AddedSuccessfuly);
        }

        public IResult Delete(int id)
        {
            var casesDocument = _casesDocumentDal.Get(cs => cs.CasesDocumentId == id);
            if (casesDocument == null)
                return new ErrorResult(Messages.TheItemDoesNotExists);
            _casesDocumentDal.Delete(casesDocument);
            return new SuccessResult(Messages.DeletedSuccessfuly);
        }

        public IDataResult<List<CasesDocumentGetDto>> GetAll()
        {
            List<CasesDocument> casesDocumentes = _casesDocumentDal.GetAllWithInclude(c => c.Casee.LicenceId == _authenticatedUserInfoService.GetLicenceId());
            List<CasesDocumentGetDto> casesDocumentDtos = _mapper.Map<List<CasesDocumentGetDto>>(casesDocumentes);
            return new SuccessDataResult<List<CasesDocumentGetDto>>(casesDocumentDtos, Messages.GetAllSuccessfuly);
        }

        public IDataResult<CasesDocumentGetDto> GetById(int id)
        {
            var casesDocument = _casesDocumentDal.GetByIdWithInclude(cs => cs.CasesDocumentId == id);
            CasesDocumentGetDto casesDocumentDto = _mapper.Map<CasesDocumentGetDto>(casesDocument);
            if (casesDocument == null)
                return new ErrorDataResult<CasesDocumentGetDto>(Messages.TheItemDoesNotExists);
            return new SuccessDataResult<CasesDocumentGetDto>(casesDocumentDto, Messages.GetByIdSuccessfuly);
        }
        public IResult Update(CasesDocumentUpdateDto casesDocumentUpdateDto)
        {
            CasesDocument casesDocument = _casesDocumentDal.Get(d => d.CasesDocumentId == casesDocumentUpdateDto.CaseDocumentId);
            if (casesDocument == null)
                return new ErrorResult(Messages.TheItemDoesNotExists);
            if (!string.IsNullOrEmpty(casesDocumentUpdateDto.DocumentPath) || casesDocument.DocumentPath != casesDocumentUpdateDto.DocumentPath)
                casesDocument.DocumentPath = casesDocumentUpdateDto.DocumentPath;
            casesDocument.Details = casesDocumentUpdateDto.Details;
            casesDocument.Title = casesDocumentUpdateDto.Title;
            _casesDocumentDal.Update(casesDocument);
            return new SuccessResult(Messages.UpdatedSuccessfuly);
        }
        public IDataResult<int> GetCountByLicenceId(int licenceId)
        {
            var casesDocumentCount = _casesDocumentDal.GetCount(cs => cs.Casee.LicenceId == licenceId);
            return new SuccessDataResult<int>(casesDocumentCount, Messages.GetByIdSuccessfuly);
        }

        public IDataResult<List<CasesDocumentGetDto>> GetAllByLicenceId(int licenceId)
        {
            List<CasesDocument> casesDocumentes = _casesDocumentDal.GetAllWithInclude(c => c.Casee.LicenceId == licenceId);
            List<CasesDocumentGetDto> casesDocumentDtos = _mapper.Map<List<CasesDocumentGetDto>>(casesDocumentes);
            return new SuccessDataResult<List<CasesDocumentGetDto>>(casesDocumentDtos, Messages.GetAllSuccessfuly);
        }
    }
}
