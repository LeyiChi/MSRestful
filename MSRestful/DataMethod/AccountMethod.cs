using InterSystems.Data.CacheTypes;
using MSRestful.CommonLibrary;
using MSRestful.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MSRestful.DataMethod
{
    public class AccountMethod
    {
        public ResponseResult Login(DataConnection pclsCache, string userId, string password, int type)
        {
            ResponseResult result = new ResponseResult
            {
                data = null,
                code = 1,
                msg = "登录失败"
            };
            try
            {
                if (!pclsCache.Connect())
                {
                    return result;
                }

                int flag = (int)Cm.MstUser.Login(pclsCache.CacheConnectionObject, userId, password);
                if(flag ==1)
                {
                    User user = new User();
                    CacheSysList List = Cm.MstUser.GetUserInfo(pclsCache.CacheConnectionObject, userId,99999999);
                    user.userId = userId;
                    user.userName = List[0];
                    user.occupation = List[2];
                    user.position = List[4];
                    user.affiliation = List[6];
                    result.data = user;
                    result.code = 0;
                    result.msg = "登录成功";
                }       
                return result;
            }
            catch (Exception ex)
            {
                HygeiaComUtility.WriteClientLog(HygeiaEnum.LogType.ErrorLog, "AccountMethod.Login", "数据库操作异常！ error information : " + ex.Message + Environment.NewLine + ex.StackTrace);
                return result;
            }
            finally
            {           
                pclsCache.DisConnect();
            }
        }
    }
}