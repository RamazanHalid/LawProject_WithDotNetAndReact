﻿using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class OperationClaimManager : IOperationClaimService
    {
        private readonly IOperationClaimDal _operationClaimDal;

        public OperationClaimManager(IOperationClaimDal operationClaimDal)
        {
            _operationClaimDal = operationClaimDal;
        }

        public IDataResult<List<OperationClaim>> GetAllByCategoryId(int operationClaimCategoryId)
        {
            return new SuccessDataResult<List<OperationClaim>>(_operationClaimDal.GetAll(o => o.OperationClaimCategoryId == operationClaimCategoryId));
        }
    }
}