using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public List<OperationClaim> GetClaims(User user,int licenceId)
        {
            return _userDal.GetClaims(user,licenceId);
        }

        public void Add(User user)
        {
            _userDal.Add(user);
        }

        public User GetByCellPhone(string cellPhone)
        {
            return _userDal.Get(u => u.CellPhone== cellPhone);
        }
        public IDataResult<List<User>> GetAll()
        {
            return  new SuccessDataResult<List<User>> (_userDal.GetAll());   
        }

        public void Update(User user)
        {
            _userDal.Update(user);
        }
    }
}
