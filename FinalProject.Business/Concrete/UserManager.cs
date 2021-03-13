﻿using Core.Entities.Concrete;
using Core.Utilities.Resluts;
using Core.Utilities.Results;
using FinalProject.Business.Abstract;
using FinalProject.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IDataResult < List<OperationClaim>> GetClaims(User user)
        {
            return new SuccessDataResult<List<OperationClaim>> (_userDal.GetClaims(user));
        }

        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult();
        }

        public IDataResult<User> GetByMail(string email)
        {
            return new SuccessDataResult<User>( _userDal.Get(u => u.Email == email));
        }
    }
}
