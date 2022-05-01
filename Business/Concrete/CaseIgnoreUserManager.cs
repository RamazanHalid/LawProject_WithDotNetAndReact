using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.CaseIngonereUserDtos;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class CaseIgnoreUserManager : ICaseIgnoreUserService
    {
        private readonly ICaseIgnoreUserDal _caseIgnoreUserDal;
        private readonly IMapper _mapper;
        public ICurrentUserService _currentUserService;
        public CaseIgnoreUserManager(ICaseIgnoreUserDal caseIgnoreUserDal, IMapper mapper, ICurrentUserService currentUserService)
        {
            _caseIgnoreUserDal = caseIgnoreUserDal;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }

        public IResult DeleteAndAdd(List<CaseIgnoreUserAddDto> caseIgnoreUserAddDtos)
        {
            var result = DeleteByCaseeId(caseIgnoreUserAddDtos[0].CaseeId, _currentUserService.GetLicenceId());
            if (!result.Success)
                return result;
            var resultAdd = AddWithRange(caseIgnoreUserAddDtos);
            return resultAdd;
        }
        public IResult AddWithRange(List<CaseIgnoreUserAddDto> caseIgnoreUserAddDtos)
        {
            List<CaseIgnoreUser> caseIgnoreUsers = new List<CaseIgnoreUser>();
            caseIgnoreUserAddDtos.ForEach(x => caseIgnoreUsers.Add(new CaseIgnoreUser
            {
                CaseeId = x.CaseeId,
                UserId = x.UserId,
                LicenceId = _currentUserService.GetLicenceId()
            }));

            _caseIgnoreUserDal.AddWithRange(caseIgnoreUsers);
            return new SuccessResult(Messages.AddedSuccessfuly);
        }

        public IResult DeleteWithRange(List<int> caseIgnoreUserIds)
        {
            _caseIgnoreUserDal.DeleteWithRange(caseIgnoreUserIds);
            return new SuccessResult(Messages.DeletedSuccessfuly);
        }
        public IResult DeleteByCaseeId(int caseId, int licenceId)
        {
            _caseIgnoreUserDal.DeleteByCaseeId(caseId, licenceId);
            return new SuccessResult(Messages.DeletedSuccessfuly);
        }
        public IDataResult<List<CaseIgnoreGetDto>> GetAllByCaseeId(int caseeId)
        {
            var caseIgnoreUsers = _caseIgnoreUserDal.GetAllWithInclude(w => w.CaseeId == caseeId);
            List<CaseIgnoreGetDto> caseIgnoreGetDtos = _mapper.Map<List<CaseIgnoreGetDto>>(caseIgnoreUsers);
            return new SuccessDataResult<List<CaseIgnoreGetDto>>(caseIgnoreGetDtos, Messages.GetAllSuccessfuly);
        }
        public IDataResult<List<CaseIgnoreUser>> GetAllByUserId(int userId)
        {
            var caseIgnoreUsers = _caseIgnoreUserDal.GetAllWithInclude(w => w.UserId == userId);
            return new SuccessDataResult<List<CaseIgnoreUser>>(caseIgnoreUsers, Messages.GetAllSuccessfuly);
        }
        public IDataResult<List<int>> GetAllCaseIdsByUserId(int userId)
        {
            var caseIgnoreUsers = _caseIgnoreUserDal.GetAllIdsWithInclude(w => w.UserId == userId);
            return new SuccessDataResult<List<int>>(caseIgnoreUsers, Messages.GetAllSuccessfuly);
        }
    }
}
