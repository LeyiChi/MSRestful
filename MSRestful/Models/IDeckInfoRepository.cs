using MSRestful.CommonLibrary;
using MSRestful.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSRestful.Models
{
    public interface IDeckInfoRepository
    {
        ResponseResult getDeckInfo(DataConnection pclsCache);
        ResponseResult getDeckInfoById(DataConnection pclsCache, string id);
        ResponseResult getDeckInfoDetailById(DataConnection pclsCache, string id);
    }
}
