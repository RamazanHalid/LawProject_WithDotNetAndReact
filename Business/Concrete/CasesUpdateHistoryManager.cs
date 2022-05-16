using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.CaseUpdateHistoryDtos;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class CasesUpdateHistoryManager : ICasesUpdateHistoryService
    {
        private readonly ICasesUpdateHistoryDal _casesUpdateHistoryDal;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;

        public CasesUpdateHistoryManager(ICasesUpdateHistoryDal casesUpdateHistoryDal, IMapper mapper, ICurrentUserService currentUserService)
        {
            _casesUpdateHistoryDal = casesUpdateHistoryDal;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }

        public IResult Add(CasesUpdateHistory casesUpdateHistory)
        {
            _casesUpdateHistoryDal.Add(casesUpdateHistory);
            return new SuccessResult(Messages.AddedSuccessfuly);
        }

        public IDataResult<List<CaseUpdateHistoryGetDto>> GetAll(int skipVal, int takeVal, int caseId)
        {
            List<CasesUpdateHistory> casesUpdateHistories = _casesUpdateHistoryDal
                .GetAllWithInclude(skipVal, takeVal, c => c.CaseeId == caseId && c.LicenceId == _currentUserService.GetLicenceId());
            List<CaseUpdateHistoryGetDto> caseUpdateHistoryGetDtos = _mapper.Map<List<CaseUpdateHistoryGetDto>>(casesUpdateHistories);
            return new SuccessDataResult<List<CaseUpdateHistoryGetDto>>(caseUpdateHistoryGetDtos, Messages.GetAllSuccessfuly);
        }

        public IDataResult<CaseUpdateHistoryGetDto> GetById(int id)
        {
            CasesUpdateHistory casesUpdateHistory = _casesUpdateHistoryDal
             .GetByIdWithInclude(c => c.CaseeId == id && c.LicenceId == _currentUserService.GetLicenceId());
            CaseUpdateHistoryGetDto caseUpdateHistoryGetDto = _mapper.Map<CaseUpdateHistoryGetDto>(casesUpdateHistory);
            return new SuccessDataResult<CaseUpdateHistoryGetDto>(caseUpdateHistoryGetDto, Messages.GetAllSuccessfuly);
        }

        public IDataResult<int> GetCountByLicenceId(int caseeId)
        {
            return new SuccessDataResult<int>(_casesUpdateHistoryDal
                .GetCount(c => c.CaseeId == caseeId && c.LicenceId == _currentUserService.GetLicenceId()), Messages.GetCountSuccessfuly);
        }
    }
}
