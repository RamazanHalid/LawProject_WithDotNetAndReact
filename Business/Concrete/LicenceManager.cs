using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class LicenceManager : ILicenceService
    {
        private readonly ILicenceDal _licenceDal;
        private readonly IMapper _mapper;
        private readonly IAuthenticatedUserInfoService _authenticatedUserInfoService;
        public LicenceManager(ILicenceDal licenceDal, IMapper mapper, IAuthenticatedUserInfoService authenticatedUserInfoService)
        {

            _licenceDal = licenceDal;
            _mapper = mapper;
            _authenticatedUserInfoService = authenticatedUserInfoService;
        }
        public IResult Add(LicenceAddDto licenceAddDto)
        {
            Licence licence = _mapper.Map<Licence>(licenceAddDto);
            licence.Balance = 0;
            licence.Gb = 1;
            licence.IsApproved = false;
            licence.SmsAccountId = 1;
            licence.SmsCount = 20;
            licence.UserCount = 0;
            licence.StartDate = DateTime.Now;
            _licenceDal.Add(licence);
            return new SuccessResult(Messages.AddedSuccessfuly);
        }

        public IDataResult<Licence> GetById(int id)
        {
            var licence = _licenceDal.GetByIdWithInclude(l => l.LicenceId == id);
            if (licence == null)
                return new ErrorDataResult<Licence>(Messages.TheItemDoesNotExists);
            return new SuccessDataResult<Licence>(licence, Messages.GetByIdSuccessfuly);
        }

        public IDataResult<List<Licence>> GetAll()
        {
            return new SuccessDataResult<List<Licence>>(_licenceDal.GetAllWithInclude());
        }

        public IResult Update(Licence licence)
        {
            _licenceDal.Update(licence);
            return new SuccessResult(Messages.UpdatedSuccessfuly);
        }
    }
}
