using MSRestful.CommonLibrary;
using MSRestful.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSRestful.Models
{
    public interface IAccountRepository
    {
        ResponseResult Login(DataConnection pclsCache, string userId, string password, int type);

    }
}
