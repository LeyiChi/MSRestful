using MSRestful.CommonLibrary;
using MSRestful.DataModels;
using InterSystems.Data.CacheClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MSRestful.DataMethod
{
    
    public class PsTrnOutpatientMethod
    {
        public int Code(object code)
        {
            if(code != null)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        public string MSG(object msg)
        {
            if (msg != null)
            {
                return "获取成功";
            }
            else
            {
                return "获取失败";
            }
        }

        #region<PsTrnOutpatient>
        /// <summary>
        /// 病人信息查询 施宇帆 2016-04-28
        /// </summary>
        /// <param name="pclsCache"></param>
        /// <param name="PatientName"></param>
        /// <param name="ClinicDate"></param>
        /// <param name="DepartmentCode"></param>
        /// <param name="SexType"></param>
        /// <param name="ClinicType"></param>
        /// <param name="DoctorCode"></param>
        /// <returns></returns>
        public ResponseResult GetOutPatients(DataConnection pclsCache, string PatientName, string ClinicDate, string DepartmentCode, string SexType, string ClinicType, string DoctorCode)
        {
            if (PatientName == "{PatientName}")
            {
                PatientName = null;
            }
            if (ClinicDate == "{ClinicDate}")
            {
                ClinicDate = null;
            }
            if (DepartmentCode == "{DepartmentCode}")
            {
                DepartmentCode = null;
            }
            if (SexType == "{SexType}")
            {
                SexType = null;
            }
            if (ClinicType == "{ClinicType}")
            {
                ClinicType = null;
            }
            if (DoctorCode == "{DoctorCode}")
            {
                DoctorCode = null;
            }
            ResponseResult Result = new ResponseResult();
            List<PsTrnOutpatient> items = new List<PsTrnOutpatient>();
            CacheCommand cmd = null;
            CacheDataReader cdr = null;
            try
            {
                if (!pclsCache.Connect())
                {
                    return null;
                }
                cmd = Ps.TrnOutpatient.GetOutPatients(pclsCache.CacheConnectionObject);

                cmd.Parameters.Add("PatientName", CacheDbType.NVarChar).Value       = PatientName;
                cmd.Parameters.Add("ClinicDate", CacheDbType.NVarChar).Value        = ClinicDate;
                cmd.Parameters.Add("DepartmentCode", CacheDbType.NVarChar).Value    = DepartmentCode;
                cmd.Parameters.Add("SexType", CacheDbType.NVarChar).Value           = SexType;
                cmd.Parameters.Add("ClinicType", CacheDbType.NVarChar).Value        = ClinicType;
                cmd.Parameters.Add("DoctorCode", CacheDbType.NVarChar).Value        = DoctorCode;

                cdr = cmd.ExecuteReader();
                while (cdr.Read())
                {
                    PsTrnOutpatient item = new PsTrnOutpatient();

                    item.PatientId          = cdr["PatientId"].ToString();
                    item.PatientName        = cdr["PatientName"].ToString();
                    item.SexType            = cdr["SexType"].ToString();
                    item.Age                = cdr["Age"].ToString();
                    item.DepartmentName     = cdr["DepartmentName"].ToString();

                    item.DoctorName         = cdr["DoctorName"].ToString();
                    item.BloodTypeName      = cdr["BloodTypeName"].ToString();
                    item.ClinicTypeName     = cdr["ClinicTypeName"].ToString();
                    item.ClinicDate         = Convert.ToInt32(cdr["ClinicDate"]);
                    item.DiseaseName        = cdr["DiseaseName"].ToString();
                    
                    items.Add(item);
                }
                Result.data = items;
                Result.code = Code(items);
                Result.msg = "病人信息查询" + MSG(items);
                return Result;
            }
            catch (Exception ex)
            {
                HygeiaComUtility.WriteClientLog(HygeiaEnum.LogType.ErrorLog, "PsTrnOutpatientMethod.GetOutPatients", "数据库操作异常！ error information : " + ex.Message + Environment.NewLine + ex.StackTrace);
                return null;
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
        /// 门诊信息查询 施宇帆 2016-04-28
        /// </summary>
        /// <param name="pclsCache"></param>
        /// <param name="DepartmentCode"></param>
        /// <param name="ClinicDate"></param>
        /// <param name="PatientName"></param>
        /// <param name="DoctorCode"></param>
        /// <param name="MedicalStatus"></param>
        /// <returns></returns>
        public ResponseResult GetTrnOutInfo(DataConnection pclsCache, string DepartmentCode, string ClinicDate, string PatientName, string DoctorCode, string MedicalStatus)
        {
            if (DepartmentCode == "{DepartmentCode}")
            {
                DepartmentCode = null;
            }
            if (ClinicDate == "{ClinicDate}")
            {
                ClinicDate = null;
            }
            if (PatientName == "{PatientName}")
            {
                PatientName = null;
            }
            if (DoctorCode == "{DoctorCode}")
            {
                DoctorCode = null;
            }
            if (MedicalStatus == "{MedicalStatus}")
            {
                MedicalStatus = null;
            }

            ResponseResult Result = new ResponseResult();
            List<Outpatients> items = new List<Outpatients>();
            CacheCommand cmd = null;
            CacheDataReader cdr = null;
            try
            {
                if (!pclsCache.Connect())
                {
                    return null;
                }
                cmd = Ps.TrnOutpatient.GetTrnOutInfo(pclsCache.CacheConnectionObject);

                cmd.Parameters.Add("piDepartmentCode", CacheDbType.NVarChar).Value = DepartmentCode;              
                cmd.Parameters.Add("piClinicDate", CacheDbType.NVarChar).Value = ClinicDate;
                cmd.Parameters.Add("piPatientName", CacheDbType.NVarChar).Value = PatientName;   
                cmd.Parameters.Add("piDoctorCode", CacheDbType.NVarChar).Value = DoctorCode;
                cmd.Parameters.Add("piMedicalStatus", CacheDbType.NVarChar).Value = MedicalStatus;

                cdr = cmd.ExecuteReader();
                while (cdr.Read())
                {
                    Outpatients item = new Outpatients();

                    item.PatientId = cdr["PatientId"].ToString();
                    item.PatientName = cdr["PatientName"].ToString();
                    item.ConsultationType = Convert.ToInt32(cdr["ConsultationType"]);
                    item.DepartmentName = cdr["DepartmentName"].ToString();
                    item.DoctorName = cdr["DoctorName"].ToString();
                   
                    item.ClinicDate = Convert.ToInt32(cdr["ClinicDate"]);
                    item.ClinicTypeName = cdr["ClinicTypeName"].ToString();
                    item.MedicalStatus = Convert.ToInt32(cdr["MedicalStatus"]);
                    item.DiseaseName = cdr["DiseaseName"].ToString();

                    items.Add(item);
                }
                Result.data = items;
                Result.code = Code(items);
                Result.msg = "门诊信息查询" + MSG(items);
                return Result;
            }
            catch (Exception ex)
            {
                HygeiaComUtility.WriteClientLog(HygeiaEnum.LogType.ErrorLog, "PsTrnOutpatientMethod.GetTrnOutInfo", "数据库操作异常！ error information : " + ex.Message + Environment.NewLine + ex.StackTrace);
                return null;
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
        /// 获取病人门诊信息详情 最新一条数据 施宇帆 2016-04-28 15
        /// </summary>
        /// <param name="pclsCache"></param>
        /// <param name="PatientId"></param>
        /// <returns></returns>
        public ResponseResult GetOutDetailsByPID(DataConnection pclsCache, string PatientId)
        {
            ResponseResult Result = new ResponseResult();
            OutpatientDetails info = new OutpatientDetails();
            try
            {
                if (!pclsCache.Connect())
                {
                    return null;
                }
                InterSystems.Data.CacheTypes.CacheSysList list = null;
                list = Ps.TrnOutpatient.GetOutDetailsByPID(pclsCache.CacheConnectionObject, PatientId);
                if (list != null)
                {
                    info.PatientId          = list[0];
                    info.PatientName        = list[1];
                    info.PatientSexName     = list[2];
                    info.PatientAge         = list[3];
                    info.PatientBloodName   = list[4];

                    info.ConsultationType   = list[5];
                    info.ClinicType         = list[6];
                    info.MedicalStatus      = list[7];
                    info.RegisterTime       = list[8];
                    info.ClinicTime         = list[9];

                    info.DepartmentName     = list[10];
                    info.DoctorName         = list[11];
                    info.DiseaseName        = list[12];
                    info.Number             = list[13];
                }
                Result.data = info;
                Result.code = Code(info);
                Result.msg = "病人门诊信息详情" + MSG(info);
                return Result;
            }
            catch (Exception ex)
            {
                HygeiaComUtility.WriteClientLog(HygeiaEnum.LogType.ErrorLog, "PsTrnOutpatientMethod.GetOutDetailsByPID", "数据库操作异常！ error information : " + ex.Message + Environment.NewLine + ex.StackTrace);
                return null;
            }
            finally
            {
                pclsCache.DisConnect();
            }
        }
        #endregion

        #region<CmTrnPatient>
        /// <summary>
        /// 施宇帆 2016-04-28 基本信息新增了门诊表的信息
        /// </summary>
        /// <param name="pclsCache"></param>
        /// <param name="PatientId"></param>
        /// <returns></returns>
        public CmTrnPatient GetPatientInfoNew(DataConnection pclsCache, string PatientId)
        {
            CmTrnPatient info = new CmTrnPatient();
            try
            {
                if (!pclsCache.Connect())
                {
                    return null;
                }
                InterSystems.Data.CacheTypes.CacheSysList list = null;
                list = Cm.TrnPatient.GetPatientInfoNew(pclsCache.CacheConnectionObject, PatientId);
                if (list != null)
                {
                    info.PatientName    = list[0];
                    info.Age            = list[1];
                    info.Sex            = list[2];
                    info.Blood          = list[3];
                    info.ClinicDate     = Convert.ToInt32(list[4]);
                    info.DepartmentName = list[5];
                    info.DoctorName     = list[6];
                }
                return info;
            }
            catch (Exception ex)
            {
                HygeiaComUtility.WriteClientLog(HygeiaEnum.LogType.ErrorLog, "PsTrnOutpatientMethod.GetPatientInfoNew", "数据库操作异常！ error information : " + ex.Message + Environment.NewLine + ex.StackTrace);
                return null;
            }
            finally
            {
                pclsCache.DisConnect();
            }
        }
        #endregion

        #region<OdOrderingSurgery>
        /// <summary>
        /// 查看病人手术室信息 施宇帆 2016-04-28
        /// </summary>
        /// <param name="pclsCache"></param>
        /// <param name="PatientId"></param>
        /// <returns></returns>
        public List<OrderingSurgery> GetInfobyPID(DataConnection pclsCache, string PatientId)
        {
            List<OrderingSurgery> items = new List<OrderingSurgery>();
            CacheCommand cmd = null;
            CacheDataReader cdr = null;
            try
            {
                if (!pclsCache.Connect())
                {
                    return null;
                }
                cmd = Od.TrnOrderingSurgery.GetInfobyPID(pclsCache.CacheConnectionObject);

                cmd.Parameters.Add("PatientId", CacheDbType.NVarChar).Value = PatientId;

                cdr = cmd.ExecuteReader();
                while (cdr.Read())
                {
                    OrderingSurgery item = new OrderingSurgery();

                    item.OrderName = cdr["OrderName"].ToString();
                    item.DiseaseCondition = cdr["DiseaseCondition"].ToString();
                    item.SurgeryRoom1 = cdr["SurgeryRoom1"].ToString();
                    item.SurgeryDepartmentName = cdr["SurgeryDepartmentName"].ToString();
                    item.IsolationFlag = cdr["IsolationFlag"].ToString();
                    item.PreDiagnosis = cdr["PreDiagnosis"].ToString();

                    item.Assistant.Assistant1Name = cdr["Assistant1Name"].ToString();
                    item.Assistant.Assistant2Name = cdr["Assistant2Name"].ToString();
                    item.Assistant.Assistant3Name = cdr["Assistant3Name"].ToString();
                    item.Assistant.Assistant4Name = cdr["Assistant4Name"].ToString();

                    item.SurgeryDateTime = cdr["SurgeryDateTime"].ToString();
                    item.SurgeryRoom2 = cdr["SurgeryRoom2"].ToString();
                    item.SurgeryLevel = cdr["SurgeryLevel"].ToString();
                    item.SurgeryDoctorName = cdr["SurgeryDoctorName"].ToString();
                    item.TransfusionDoctorName = cdr["TransfusionDoctorName"].ToString();
                    item.AnesthesiaMethod = cdr["AnesthesiaMethod"].ToString();

                    item.TableNurse.TableNurse1Name = cdr["TableNurse1Name"].ToString();
                    item.TableNurse.TableNurse2Name = cdr["TableNurse2Name"].ToString();

                    items.Add(item);
                }
                return items;
            }
            catch (Exception ex)
            {
                HygeiaComUtility.WriteClientLog(HygeiaEnum.LogType.ErrorLog, "PsTrnOutpatientMethod.GetInfobyPID", "数据库操作异常！ error information : " + ex.Message + Environment.NewLine + ex.StackTrace);
                return null;
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
        #endregion

        #region<PsTrnInpatient>
        /// <summary>
        /// 获取病人住院信息 施宇帆 2016-04-28 
        /// </summary>
        /// <param name="pclsCache"></param>
        /// <param name="PatientId"></param>
        /// <returns></returns>
        public List<PsTrnInpatient> GetInPByPID(DataConnection pclsCache, string PatientId)
        {
            List<PsTrnInpatient> items = new List<PsTrnInpatient>();
            CacheCommand cmd = null;
            CacheDataReader cdr = null;
            try
            {
                if (!pclsCache.Connect())
                {
                    return null;
                }
                cmd = Ps.TrnInpatient.GetInPByPID(pclsCache.CacheConnectionObject);

                cmd.Parameters.Add("PatientId", CacheDbType.NVarChar).Value = PatientId;

                cdr = cmd.ExecuteReader();
                while (cdr.Read())
                {
                    PsTrnInpatient item = new PsTrnInpatient();

                    item.AdmissionDate      = cdr["AdmissionDate"].ToString();
                    item.AdDays             = Convert.ToInt32(cdr["AdDays"]);
                    item.DoctorName         = cdr["DoctorName"].ToString();
                    item.NurseName          = cdr["NurseName"].ToString();
                    item.RoomName           = cdr["RoomName"].ToString();
                    item.BedName            = cdr["BedName"].ToString();
                    item.WardName           = cdr["WardName"].ToString();
                    item.Diagnosis          = cdr["Diagnosis"].ToString();


                    items.Add(item);
                }
                return items;
            }
            catch (Exception ex)
            {
                HygeiaComUtility.WriteClientLog(HygeiaEnum.LogType.ErrorLog, "PsTrnOutpatientMethod.GetInPByPID", "数据库操作异常！ error information : " + ex.Message + Environment.NewLine + ex.StackTrace);
                return null;
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
        /// 住院信息查询 施宇帆 2016-04-28
        /// </summary>
        /// <param name="pclsCache"></param>
        /// <param name="PatientId"></param>
        /// <param name="PatientName"></param>
        /// <param name="AdmissionDate"></param>
        /// <param name="RoomCode"></param>
        /// <returns></returns>
        public ResponseResult GetInPatients(DataConnection pclsCache, string PatientId, string PatientName, string AdmissionDate, string RoomCode)
        {
            if (PatientId == "{PatientId}")
            {
                PatientId = null;
            }
            if (PatientName == "{PatientName}")
            {
                PatientName = null;
            }
            if (AdmissionDate == "{AdmissionDate}")
            {
                AdmissionDate = null;
            }
            if (RoomCode == "{RoomCode}")
            {
                RoomCode = null;
            }

            ResponseResult Result = new ResponseResult();
            List<Inpatients> items = new List<Inpatients>();
            CacheCommand cmd = null;
            CacheDataReader cdr = null;
            try
            {
                if (!pclsCache.Connect())
                {
                    return null;
                }
                cmd = Ps.TrnInpatient.GetInPatients(pclsCache.CacheConnectionObject);

                cmd.Parameters.Add("piPatientId", CacheDbType.NVarChar).Value = PatientId;
                cmd.Parameters.Add("piPatientName", CacheDbType.NVarChar).Value = PatientName;
                cmd.Parameters.Add("piAdmissionDate", CacheDbType.NVarChar).Value = AdmissionDate;
                cmd.Parameters.Add("piRoomCode", CacheDbType.NVarChar).Value = RoomCode;

                cdr = cmd.ExecuteReader();
                while (cdr.Read())
                {
                    Inpatients item = new Inpatients();

                    item.PatientId = cdr["PatientId"].ToString();
                    item.PatientName = cdr["PatientName"].ToString();
                    item.SexType = cdr["SexType"].ToString();
                    item.Age = Convert.ToInt32(cdr["Age"]);
                    item.WardName = cdr["WardName"].ToString();

                    item.AdmissionDate = cdr["AdmissionDate"].ToString();
                    item.AdDays = Convert.ToInt32(cdr["AdDays"]);
                    item.DoctorName = cdr["DoctorName"].ToString();
                    item.NurseName = cdr["NurseName"].ToString();                
                    item.Diagnosis = cdr["Diagnosis"].ToString();

                    item.RoomName = cdr["RoomName"].ToString();
                    item.BedName = cdr["BedName"].ToString();

                    items.Add(item);
                }
                Result.data = items;
                Result.code = Code(items);
                Result.msg = "住院信息查询" + MSG(items);
                return Result;
            }
            catch (Exception ex)
            {
                HygeiaComUtility.WriteClientLog(HygeiaEnum.LogType.ErrorLog, "PsTrnOutpatientMethod.GetInPatients", "数据库操作异常！ error information : " + ex.Message + Environment.NewLine + ex.StackTrace);
                return null;
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
        #endregion
    }
}