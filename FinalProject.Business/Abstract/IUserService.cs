using Core.Entities.Concrete;
using Core.Utilities.Resluts;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Business.Abstract
{
    public interface IUserService
    {
       IDataResult< List<OperationClaim>> GetClaims(User user);
        IResult Add(User user);
       IDataResult<User> GetByMail(string email);
    }
}
