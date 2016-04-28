using MSRestful.CommonLibrary;
using MSRestful.DataModels;
using MSRestful.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MSRestful.Controllers
{
    public class AccountController : ApiController
    {
        static readonly IAccountRepository repository = new AccountRepository();
        DataConnection pclsCache = new DataConnection();

        [Route("Api/v1/account/login")]
        [HttpPost]
        public ResponseResult Login(Login login)
        {
            return repository.Login(pclsCache, login.userId, login.password, login.type);
        }
    }
}
