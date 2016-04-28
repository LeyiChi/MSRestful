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
    public class DeckInfoMethod
    {
        public ResponseResult getDeckInfo(DataConnection pclsCache)
        {    
            List<DeckInfo> deckInfoList = new List<DeckInfo>();
             ResponseResult result = new ResponseResult
            {
                data = null,
                code = 1,
                msg = "获取首页甲板概况失败"
            };
            CacheCommand cmd = null;
            CacheDataReader cdr = null;
            try
            {
                if (!pclsCache.Connect())
                {
                    //MessageBox.Show("Cache数据库连接失败");
                    return null;
                }
                cmd = new CacheCommand();
                cmd = Vs.MstDeckInfo.GetHomeDeckInfo(pclsCache.CacheConnectionObject);            
                cdr = cmd.ExecuteReader();
                //string deckSectionNames = "";             
                while (cdr.Read())
                {
                        DeckInfo deckInfo = new DeckInfo();
                        deckInfo.ID = Convert.ToInt32(cdr["DeckId"]);
                        deckInfo.DeckName = cdr["DeckName"].ToString();
                        string[] deckSectionNames = cdr["DeckSectionNames"].ToString().Split('*');
                        deckInfo.DeckSectionNames=new string[deckSectionNames.Length-1];
                        Array.ConstrainedCopy(deckSectionNames, 0, deckInfo.DeckSectionNames, 0, deckSectionNames.Length-1); 
                        deckInfo.BedCount = Convert.ToInt32(cdr["BedCount"]);
                        deckInfo.BedAvailCount = Convert.ToInt32(cdr["BedAvailCount"]);
                        deckInfo.SurgeryRoomCount = Convert.ToInt32(cdr["SurgeryCount"]);
                        deckInfo.SurgeryRoomAvailCount = Convert.ToInt32(cdr["SurgeryAvailCount"]);
                        deckInfo.DutyRoomCount = Convert.ToInt32(cdr["DutyRoomCount"]);
                        deckInfoList.Add(deckInfo);
                }
                result.data = deckInfoList;
                result.code = 0;
                result.msg = "获取首页甲板概况成功";
                return result;
            }
            catch (Exception ex)
            {
                HygeiaComUtility.WriteClientLog(HygeiaEnum.LogType.ErrorLog, "DeckInfoMethod.getDeckInfo", "数据库操作异常！ error information : " + ex.Message + Environment.NewLine + ex.StackTrace);
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

        public ResponseResult getDeckInfoById(DataConnection pclsCache,string id)
        {
            DeckSectionInfo deckInfo= new DeckSectionInfo();
            ResponseResult result = new ResponseResult
            {
                data = null,
                code = 1,
                msg = "获取甲板分区信息失败"
            };
            
            try
            {
                if (!pclsCache.Connect())
                {
                    //MessageBox.Show("Cache数据库连接失败");
                    return null;
                }
                CacheSysList List = Vs.MstDeckInfo.GetDeckSectionInfo(pclsCache.CacheConnectionObject, id);
                deckInfo.ID = id;
                deckInfo.BedCount = Convert.ToInt32(List[2]);
                deckInfo.BedAvailCount = Convert.ToInt32(List[3]);
                deckInfo.SurgeryRoomCount = Convert.ToInt32(List[4]);
                deckInfo.SurgeryRoomAvailCount = Convert.ToInt32(List[5]);
                deckInfo.DutyDoctorCount = Convert.ToInt32(List[6]);

                result.data = deckInfo;
                result.code = 0;
                result.msg = "获取甲板分区信息成功";
                return result;
            }
            catch (Exception ex)
            {
                HygeiaComUtility.WriteClientLog(HygeiaEnum.LogType.ErrorLog, "DeckInfoMethod.getDeckInfoById", "数据库操作异常！ error information : " + ex.Message + Environment.NewLine + ex.StackTrace);
                return null;
            }
            finally
            {             
                pclsCache.DisConnect();
            }
        }


        public ResponseResult getDeckInfoDetailById(DataConnection pclsCache, string id)
        {
            ResponseResult result = new ResponseResult
            {
                data = null,
                code = 1,
                msg = "查看甲板信息详情失败"
            };
            DeckInfoDetail res = new DeckInfoDetail();

            res.bedInfoList = getBedInfoList(pclsCache, id);
            res.surgeryRoomInfoList = getSurgeryRoomInfoList(pclsCache, id);
            res.dutyDoctorInfoList = getDutyDoctorInfoList(pclsCache, id);

            result.data=res;
            result.code = 0;
            result.msg = "查看甲板信息详情成功";
            return result;

        }

        public List<BedInfo> getBedInfoList(DataConnection pclsCache, string id)
        {
            List<BedInfo> bedInfoList = new List<BedInfo>();
 
            CacheCommand cmd = null;
            CacheDataReader cdr = null;
            try
            {
                if (!pclsCache.Connect())
                {
                    //MessageBox.Show("Cache数据库连接失败");
                    return null;
                }
                cmd = new CacheCommand();
                cmd = Vs.DeckBed.GetBedInfoList(pclsCache.CacheConnectionObject);
                //cmd = Vs.MstDeckInfo.SetData(pclsCache.CacheConnectionObject);
                cmd.Parameters.Add("DeckId", CacheDbType.NVarChar).Value = id;

                cdr = cmd.ExecuteReader();        
                while (cdr.Read())
                {
                    BedInfo bedInfo = new BedInfo();
                    bedInfo.DeckId = cdr["DeckId"].ToString();
                    bedInfo.DeckSectionId = cdr["DeckSectionId"].ToString();
                    bedInfo.WardCode = cdr["WardCode"].ToString();
                    bedInfo.RoomCode = cdr["RoomCode"].ToString();
                    bedInfo.BedCode = cdr["BedCode"].ToString();
                    bedInfo.Status = Convert.ToInt32(cdr["Status"]);
                    bedInfo.PatientName = cdr["PatientId"].ToString();
                    bedInfoList.Add(bedInfo);
                }

                return bedInfoList;
            }
            catch (Exception ex)
            {
                HygeiaComUtility.WriteClientLog(HygeiaEnum.LogType.ErrorLog, "DeckInfoMethod.getBedInfoList", "数据库操作异常！ error information : " + ex.Message + Environment.NewLine + ex.StackTrace);
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

        public List<SurgeryRoomInfo> getSurgeryRoomInfoList(DataConnection pclsCache, string id)
        {
            List<SurgeryRoomInfo> surgeryRoomInfoList = new List<SurgeryRoomInfo>();

            CacheCommand cmd = null;
            CacheDataReader cdr = null;
            try
            {
                if (!pclsCache.Connect())
                {
                    //MessageBox.Show("Cache数据库连接失败");
                    return null;
                }
                cmd = new CacheCommand();
                cmd = Vs.DeckSurgeryRoom.GetSurgeryInfoList(pclsCache.CacheConnectionObject);
                cmd.Parameters.Add("DeckId", CacheDbType.NVarChar).Value = id;

                cdr = cmd.ExecuteReader();
                while (cdr.Read())
                {
                    SurgeryRoomInfo surgeryRoomInfo = new SurgeryRoomInfo();
                    surgeryRoomInfo.DeckId = cdr["DeckId"].ToString();
                    surgeryRoomInfo.DeckSectionId = cdr["DeckSectionId"].ToString();
                    surgeryRoomInfo.SurgeryRoomId = cdr["SurgeryRoomId"].ToString();
                    surgeryRoomInfo.SubSurgeryRoomId = cdr["SubSurgeryRoomId"].ToString();
                    surgeryRoomInfo.Status = Convert.ToInt32(cdr["Status"]);
                    surgeryRoomInfoList.Add(surgeryRoomInfo);
                }

                return surgeryRoomInfoList;
            }
            catch (Exception ex)
            {
                HygeiaComUtility.WriteClientLog(HygeiaEnum.LogType.ErrorLog, "DeckInfoMethod.getSurgeryRoomInfoList", "数据库操作异常！ error information : " + ex.Message + Environment.NewLine + ex.StackTrace);
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

        public List<DutyDoctorInfo> getDutyDoctorInfoList(DataConnection pclsCache, string id)
        {
            List<DutyDoctorInfo> dutyDoctorInfoList = new List<DutyDoctorInfo>();

            CacheCommand cmd = null;
            CacheDataReader cdr = null;
            try
            {
                if (!pclsCache.Connect())
                {
                    //MessageBox.Show("Cache数据库连接失败");
                    return null;
                }
                cmd = new CacheCommand();
                cmd = Vs.MstSchedule.GetDutyDoctorInfoList(pclsCache.CacheConnectionObject);
                cmd.Parameters.Add("DeckId", CacheDbType.NVarChar).Value = id;

                cdr = cmd.ExecuteReader();
                while (cdr.Read())
                {
                    DutyDoctorInfo dutyDoctorInfo = new DutyDoctorInfo();
                    dutyDoctorInfo.DeckId = cdr["DeckId"].ToString();
                    dutyDoctorInfo.DeckSectionId = cdr["DeckSectionId"].ToString();
                    dutyDoctorInfo.DoctorId = cdr["DoctorId"].ToString();
                    dutyDoctorInfo.SortNo = cdr["SortNo"].ToString();
                    dutyDoctorInfo.Time1 = cdr["Time1"].ToString();
                    dutyDoctorInfo.Time2 = cdr["Time2"].ToString();
                    dutyDoctorInfo.DoctorName = cdr["UserName"].ToString();
                    dutyDoctorInfo.Affiliation = cdr["Affiliation"].ToString();

                    dutyDoctorInfoList.Add(dutyDoctorInfo);
                }

                return dutyDoctorInfoList;
            }
            catch (Exception ex)
            {
                HygeiaComUtility.WriteClientLog(HygeiaEnum.LogType.ErrorLog, "DeckInfoMethod.getDutyDoctorInfoList", "数据库操作异常！ error information : " + ex.Message + Environment.NewLine + ex.StackTrace);
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
    }
}