using InterSystems.Data.CacheClient;
using InterSystems.Data.CacheTypes;
using MSRestful.CommonLibrary;
using MSRestful.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MSRestful.DataMethod
{
    public class DeliverInfoMethod
    {
        /// <summary>
        /// 伤员信息查询
        /// </summary>
        /// <param name="pclsCache"></param>
        /// <param name="PatientId"></param>
        /// <param name="Gender"></param>
        /// <param name="PatientName"></param>
        /// <param name="BloodType"></param>
        /// <returns></returns>
        public ResponseResult CmPDAInfoGetPatientsInfo(DataConnection pclsCache, string PatientId, int Gender, string PatientName, string BloodType)
        {
            ResponseResult Result = new ResponseResult
            {
                data = null,
                code = 1,
                msg = "伤员信息获取失败"
            };
            List<PatientInfo> list = new List<PatientInfo>();
            CacheCommand cmd = null;
            CacheDataReader cdr = null;
            try
            {
                if (!pclsCache.Connect())
                {
                    return Result;
                }
                cmd = new CacheCommand();
                cmd = Cm.PDAInfo.GetPatientsInfo(pclsCache.CacheConnectionObject);
                cmd.Parameters.Add("PatientId", CacheDbType.NVarChar).Value = PatientId;
                cmd.Parameters.Add("Gender", CacheDbType.NVarChar).Value = Gender;
                cmd.Parameters.Add("PatientName", CacheDbType.NVarChar).Value = PatientName;
                cmd.Parameters.Add("BloodType", CacheDbType.NVarChar).Value = BloodType;
                cdr = cmd.ExecuteReader();
                while (cdr.Read())
                {
                    list.Add(new PatientInfo
                    {
                        PatientId = cdr["PatientId"].ToString(),
                        PatientName = cdr["PatientName"].ToString(),
                        Gender = cdr["Gender"].ToString(),
                        Birthday = cdr["Birthday"].ToString(),
                        BloodType = cdr["BloodType"].ToString(),
                        DrugAllergy = cdr["DrugAllergy"].ToString(),
                        Diagnosis = cdr["Diagnosis"].ToString(),
                        ToPlace = cdr["ToPlace"].ToString()
                    });
                    if (PatientId != null)
                    {
                        CacheSysList PDAInfo = Cm.PDAInfo.GetPDAInfo(pclsCache.CacheConnectionObject, PatientId);
                        if (PDAInfo == null)
                        {
                            list = new List<PatientInfo>();
                        }
                        break;
                    }
                }
                Result = new ResponseResult
                {
                    data = list,
                    code = 0,
                    msg = "伤员信息获取成功"
                };
                return Result;
            }
            catch (Exception ex)
            {
                HygeiaComUtility.WriteClientLog(HygeiaEnum.LogType.ErrorLog, "DeliverInfoMethod.GetPatientsInfo", "数据库操作异常！ error information : " + ex.Message + Environment.NewLine + ex.StackTrace);
                return Result;
            }
            finally
            {
                if ((cdr != null))
                {
                    cdr.Close();
                    cdr.Dispose(true);
                    cdr = null;
                }
                if ((cmd != null))
                {
                    cmd.Parameters.Clear();
                    cmd.Dispose();
                    cmd = null;
                }
                pclsCache.DisConnect();
            }
        }

        /// <summary>
        /// 医生信息查询
        /// </summary>
        /// <param name="pclsCache"></param>
        /// <param name="DoctorId"></param>
        /// <param name="Affiliation"></param>
        /// <param name="Status"></param>
        /// <param name="DoctorName"></param>
        /// <param name="Position"></param>
        /// <returns></returns>
        public ResponseResult CmMstUserGetDoctorsInfo(DataConnection pclsCache, string DoctorId, string Affiliation, string Status, string DoctorName, string Position)
        {
            ResponseResult Result = new ResponseResult
            {
                data = null,
                code = 1,
                msg = "医生信息获取失败"
            };
            List<DoctorInfo> list = new List<DoctorInfo>();
            CacheCommand cmd = null;
            CacheDataReader cdr = null;
            try
            {
                if (!pclsCache.Connect())
                {
                    return Result;
                }
                cmd = new CacheCommand();
                cmd = Cm.MstUser.GetDoctorsInfo(pclsCache.CacheConnectionObject);
       
                cmd.Parameters.Add("DoctorId", CacheDbType.NVarChar).Value = DoctorId;
                cmd.Parameters.Add("Affiliation", CacheDbType.NVarChar).Value = Affiliation;
                cmd.Parameters.Add("Status", CacheDbType.NVarChar).Value = Status;
                cmd.Parameters.Add("DoctorName", CacheDbType.NVarChar).Value = DoctorName;
                cmd.Parameters.Add("Position", CacheDbType.NVarChar).Value = Position;
                cdr = cmd.ExecuteReader();
                while (cdr.Read())
                {
                    list.Add(new DoctorInfo
                    {
                        DoctorId = cdr["DoctorId"].ToString(),
                        DoctorName = cdr["DoctorName"].ToString(),
                        Affiliation = cdr["Affiliation"].ToString(),
                        Occupation = cdr["Occupation"].ToString(),
                        Position = cdr["Position"].ToString(),
                        Status = cdr["Status"].ToString(),
                        DutyRoom = cdr["DutyRoom"].ToString()
                    });
                    if (DoctorId != null)
                    {
                        break;
                    }
                }
                Result = new ResponseResult
                {
                    data = list,
                    code = 0,
                    msg = "医生信息获取成功"
                };
                return Result;
            }
            catch (Exception ex)
            {
                HygeiaComUtility.WriteClientLog(HygeiaEnum.LogType.ErrorLog, "DeliverInfoMethod.GetDoctorsInfo", "数据库操作异常！ error information : " + ex.Message + Environment.NewLine + ex.StackTrace);
                return Result;
            }
            finally
            {
                if ((cdr != null))
                {
                    cdr.Close();
                    cdr.Dispose(true);
                    cdr = null;
                }
                if ((cmd != null))
                {
                    cmd.Parameters.Clear();
                    cmd.Dispose();
                    cmd = null;
                }
                pclsCache.DisConnect();
            }
        }

        /// <summary>
        /// 医生信息详情
        /// </summary>
        /// <param name="pclsCache"></param>
        /// <param name="DoctorId"></param>
        /// <returns></returns>
        public ResponseResult CmMstUserGetDoctorInfoDetail(DataConnection pclsCache, string DoctorId)
        {
            ResponseResult Result = new ResponseResult
            {
                data = null,
                code = 1,
                msg = "医生详细信息获取失败"
            };
            DoctorInfoDetail ret = new DoctorInfoDetail();
            try
            {
                if (!pclsCache.Connect())
                {
                    return Result;
                }
                CacheSysList List = Cm.MstUser.GetDoctorInfoDetail(pclsCache.CacheConnectionObject, DoctorId);
                
                ret.DoctorId = List[0];
                ret.DoctorName = List[1];
                ret.DeptName = List[2];
                ret.PositionName = List[3];
                ret.Status = List[4];
                ret.DoctorIntro = List[5];
                ret.DutyStatus = List[6];
                ret.Time1 = List[7];
                ret.Time2 = List[8];
                ret.RoomName = List[9];
                Result = new ResponseResult
                {
                    data = ret,
                    code = 0,
                    msg = "医生详细信息获取成功"
                };
                return Result;
            }
            catch (Exception ex)
            {
                HygeiaComUtility.WriteClientLog(HygeiaEnum.LogType.ErrorLog, "DeliverInfoMethod.GetDoctorInfoDetail", "数据库操作异常！ error information : " + ex.Message + Environment.NewLine + ex.StackTrace);
                return Result;
            }
            finally
            {
                pclsCache.DisConnect();
            }
        }

        /// <summary>
        /// 手术室信息查询
        /// </summary>
        /// <param name="pclsCache"></param>
        /// <param name="SurgeryRoom1"></param>
        /// <param name="SurgeryRoom2"></param>
        /// <param name="SurgeryDateTime"></param>
        /// <param name="SurgeryDeptCode"></param>
        /// <returns></returns>
        public ResponseResult OdTrnOrderingSurgeryGetSurgeriesInfo(DataConnection pclsCache, string SurgeryRoom1, string SurgeryRoom2, string SurgeryDateTime, string SurgeryDeptCode)
        {
            ResponseResult Result = new ResponseResult
            {
                data = null,
                code = 1,
                msg = "手术信息获取失败"
            };
            List<SurgeryInfo> list = new List<SurgeryInfo>();
            CacheCommand cmd = null;
            CacheDataReader cdr = null;
            try
            {
                if (!pclsCache.Connect())
                {
                    return Result;
                }
                cmd = new CacheCommand();
                cmd = Od.TrnOrderingSurgery.GetSurgeriesInfo(pclsCache.CacheConnectionObject);
                cmd.Parameters.Add("SurgeryRoom1", CacheDbType.NVarChar).Value = SurgeryRoom1;
                cmd.Parameters.Add("SurgeryRoom2", CacheDbType.NVarChar).Value = SurgeryRoom2;
                cmd.Parameters.Add("SurgeryDateTime", CacheDbType.NVarChar).Value = SurgeryDateTime;
                cmd.Parameters.Add("SurgeryDeptCode", CacheDbType.NVarChar).Value = SurgeryDeptCode;
                cdr = cmd.ExecuteReader();
                while (cdr.Read())
                {
                    list.Add(new SurgeryInfo
                    {
                        SurgeryRoomId = cdr["SurgeryRoomId"].ToString(),
                        SurgeryRoom1 = cdr["SurgeryRoom1"].ToString().Replace("\0", ""),
                        SurgeryRoom2 = cdr["SurgeryRoom2"].ToString().Replace("\0", ""),
                        SurgeryTable = cdr["SurgeryTable"].ToString(),
                        SurgeryDate = cdr["SurgeryDate"].ToString().Replace("\0", ""),
                        SurgeryDeptCode = cdr["SurgeryDeptCode"].ToString(),
                        PatientId = cdr["PatientId"].ToString(),
                        PatientName = cdr["PatientName"].ToString(),
                        Diagnosis = cdr["Diagnosis"].ToString(),
                        SurgeryName = cdr["SurgeryName"].ToString(),
                        SurgeryDoctor = cdr["SurgeryDoctor"].ToString()
                    });
                }
                Result = new ResponseResult
                {
                    data = list,
                    code = 0,
                    msg = "手术信息获取成功"
                };
                return Result;
            }
            catch (Exception ex)
            {
                HygeiaComUtility.WriteClientLog(HygeiaEnum.LogType.ErrorLog, "DeliverInfoMethod.GetSurgeriesInfo", "数据库操作异常！ error information : " + ex.Message + Environment.NewLine + ex.StackTrace);
                return Result;
            }
            finally
            {
                if ((cdr != null))
                {
                    cdr.Close();
                    cdr.Dispose(true);
                    cdr = null;
                }
                if ((cmd != null))
                {
                    cmd.Parameters.Clear();
                    cmd.Dispose();
                    cmd = null;
                }
                pclsCache.DisConnect();
            }
        }
      
        /// <summary>
        /// 查看手术室详情信息
        /// </summary>
        /// <param name="pclsCache"></param>
        /// <param name="RoomId"></param>
        /// <returns></returns>
        public ResponseResult OdTrnOrderingSurgeryGetSurgeriesInfoDetail(DataConnection pclsCache, string RoomId)
        {
            ResponseResult Result = new ResponseResult
            {
                data = null,
                code = 1,
                msg = "手术详细信息获取失败"
            };
            List<SurgeryInfoDetail> list = new List<SurgeryInfoDetail>();
            CacheCommand cmd = null;
            CacheDataReader cdr = null;
            try
            {
                if (!pclsCache.Connect())
                {
                    return Result;
                }
                cmd = new CacheCommand();
                cmd = Od.TrnOrderingSurgery.GetSurgeriesInfoDetail(pclsCache.CacheConnectionObject);
                cmd.Parameters.Add("RoomId", CacheDbType.NVarChar).Value = RoomId;
                cdr = cmd.ExecuteReader();
                while (cdr.Read())
                {
                    list.Add(new SurgeryInfoDetail
                    {
                        PatientId = cdr["PatientId"].ToString(),
                        PatientName = cdr["PatientName"].ToString(),
                        SurgeryName = cdr["SurgeryName"].ToString(),
                        Diagnosis = cdr["Diagnosis"].ToString(),
                        DiseaseCondition = cdr["DiseaseCondition"].ToString(),
                        SurgeryDate = cdr["SurgeryDate"].ToString().Replace("\0", ""),
                        SurgeryRoom1 = cdr["SurgeryRoom1"].ToString().Replace("\0", ""),
                        SurgeryRoom2 = cdr["SurgeryRoom2"].ToString().Replace("\0", ""),
                        SurgeryTable = cdr["SurgeryTable"].ToString(),
                        IsolationFlag = cdr["IsolationFlag"].ToString(),
                        SurgeryLevel = cdr["SurgeryLevel"].ToString(),
                        SurgeryDept = cdr["SurgeryDept"].ToString(),
                        SurgeryDoctor = cdr["SurgeryDoctor"].ToString(),
                        Assistant1 = cdr["Assistant1"].ToString(),
                        Assistant2 = cdr["Assistant2"].ToString(),
                        Assistant3 = cdr["Assistant3"].ToString(),
                        Assistant4 = cdr["Assistant4"].ToString(),
                        TransfusionDoctor = cdr["TransfusionDoctor"].ToString(),
                        AnesthesiaMethod = cdr["AnesthesiaMethod"].ToString(),
                        AnesthesiaDoctor1 = cdr["AnesthesiaDoctor1"].ToString(),
                        AnesthesiaDoctor2 = cdr["AnesthesiaDoctor2"].ToString(),
                        TableNurse1 = cdr["TableNurse1"].ToString(),
                        TableNurse2 = cdr["TableNurse2"].ToString(),
                        SupplyNurse1 = cdr["SupplyNurse1"].ToString(),
                        SupplyNurse2 = cdr["SupplyNurse2"].ToString()
                    });
                }
                Result = new ResponseResult
                {
                    data = list,
                    code = 0,
                    msg = "手术详细信息获取成功"
                };
                return Result;
            }
            catch (Exception ex)
            {
                HygeiaComUtility.WriteClientLog(HygeiaEnum.LogType.ErrorLog, "DeliverInfoMethod.GetSurgeriesInfoDetail", "数据库操作异常！ error information : " + ex.Message + Environment.NewLine + ex.StackTrace);
                return Result;
            }
            finally
            {
                if ((cdr != null))
                {
                    cdr.Close();
                    cdr.Dispose(true);
                    cdr = null;
                }
                if ((cmd != null))
                {
                    cmd.Parameters.Clear();
                    cmd.Dispose();
                    cmd = null;
                }
                pclsCache.DisConnect();
            }
        }

        public ResponseResult getDiagnosisInfoList(DataConnection pclsCache, string DepartmentCode, string Status, string ClinicDate, string PatientName)
        {
            ResponseResult result = new ResponseResult
            {
                data = null,
                code = 1,
                msg = "辅诊信息查询失败"
            };

            List<Ordering> list = new List<Ordering>();
            CacheCommand cmd = null;
            CacheDataReader cdr = null;
            try
            {
                if (!pclsCache.Connect())
                {
                    return result;
                }
                cmd = new CacheCommand();
                cmd = Od.TrnOrdering.GetDiagnosisInfoList(pclsCache.CacheConnectionObject);
                cmd.Parameters.Add("DepartmentCode", CacheDbType.NVarChar).Value = DepartmentCode;
                cmd.Parameters.Add("piStatus", CacheDbType.NVarChar).Value = Status;
  
                cdr = cmd.ExecuteReader();
                while (cdr.Read())
                {
                    list.Add(new Ordering
                    {
                        PatientId = cdr["PatientId"].ToString(),
                        PatientName = cdr["PatientName"].ToString(),
                        OrderName = cdr["OrderName"].ToString(),
                        Status = cdr["Status"].ToString(),
                        ApplyDepartment = cdr["DepartmentCode"].ToString(),
                        TargetDepartment = cdr["DivisionCode"].ToString(),
                        ClinicDate = cdr["ClinicDate"].ToString()                
                    });
                }

                if (PatientName != null)
                {
                    //过滤
                    list = list.Where(x => x.PatientName == PatientName).ToList();                
                }
                if (ClinicDate != null)
                {
                    //过滤
                    list = list.Where(x => x.ClinicDate == ClinicDate).ToList();          
                }
                result.data = list;
                result.code = 0;
                result.msg = "辅诊信息查询成功";
                return result;
            }
            catch (Exception ex)
            {
                HygeiaComUtility.WriteClientLog(HygeiaEnum.LogType.ErrorLog, "DeliverInfoMethod.getDiagnosisInfoList", "数据库操作异常！ error information : " + ex.Message + Environment.NewLine + ex.StackTrace);
                return result;
            }
            finally
            {
                if ((cdr != null))
                {
                    cdr.Close();
                    cdr.Dispose(true);
                    cdr = null;
                }
                if ((cmd != null))
                {
                    cmd.Parameters.Clear();
                    cmd.Dispose();
                    cmd = null;
                }
                pclsCache.DisConnect();
            }
        }
    }
}