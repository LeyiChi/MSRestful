using MSRestful.CommonLibrary;
using MSRestful.DataMethod;
using MSRestful.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MSRestful.Models
{
    public class AccountRepository : IAccountRepository
    {
        AccountMethod accountMethod = new AccountMethod();
        public ResponseResult Login(DataConnection pclsCache, string userId, string password, int type)
        {
            return accountMethod.Login(pclsCache, userId, password, type);
        }
         
    }
}