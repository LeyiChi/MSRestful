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
    public class DeliverInfoController : ApiController
    {
        static readonly IDeliverInfoRepository repository = new DeliverInfoRepository();
        DataConnection pclsCache = new DataConnection();

        /// <summary>
        /// 伤员信息查询(Gender输入为0时表示输出全部性别)
        /// </summary>
        /// <param name="PatientId"></param>
        /// <param name="Gender"></param>
        /// <param name="PatientName"></param>
        /// <param name="BloodType"></param>
        /// <returns></returns>
        [Route("Api/v1/PDAInfo/PatientsInfo")]
        public ResponseResult GetPatientsInfo(string PatientId, int Gender, string PatientName, string BloodType)
        {
            return repository.CmPDAInfoGetPatientsInfo(pclsCache, PatientId, Gender, PatientName, BloodType);
        }

        /// <summary>
        /// 医生信息查询
        /// </summary>
        /// <param name="DoctorId"></param>
        /// <param name="Affiliation"></param>
        /// <param name="Status"></param>
        /// <param name="DoctorName"></param>
        /// <param name="Position"></param>
        /// <returns></returns>
        [Route("Api/v1/MstUser/DoctorsInfo")]
        public ResponseResult GetDoctorsInfo(string DoctorId, string Affiliation, string Status, string DoctorName, string Position)
        {
            return repository.CmMstUserGetDoctorsInfo(pclsCache, DoctorId, Affiliation, Status, DoctorName, Position);
        }

        /// <summary>
        /// 医生信息详情
        /// </summary>
        /// <param name="DoctorId"></param>
        /// <returns></returns>
        [Route("Api/v1/MstUser/DoctorInfoDetail")]
        public ResponseResult GetDoctorInfoDetail(string DoctorId)
        {
            return repository.CmMstUserGetDoctorInfoDetail(pclsCache, DoctorId);
        }

        /// <summary>
        /// 手术室信息查询
        /// </summary>
        /// <param name="SurgeryRoom1"></param>
        /// <param name="SurgeryRoom2"></param>
        /// <param name="SurgeryDateTime"></param>
        /// <param name="SurgeryDeptCode"></param>
        /// <returns></returns>
        [Route("Api/v1/TrnOrderingSurgery/SurgeriesInfo")]
        public ResponseResult GetSurgeriesInfo(string SurgeryRoom1, string SurgeryRoom2, string SurgeryDateTime, string SurgeryDeptCode)
        {
            return repository.OdTrnOrderingSurgeryGetSurgeriesInfo(pclsCache, SurgeryRoom1, SurgeryRoom2, SurgeryDateTime, SurgeryDeptCode);
        }

        /// <summary>
        /// 查看手术室详情信息
        /// </summary>
        /// <param name="RoomId"></param>
        /// <returns></returns>
        [Route("Api/v1/TrnOrderingSurgery/SurgeriesInfoDetail")]
        public ResponseResult GetSurgeriesInfoDetail(string RoomId)
        {
            return repository.OdTrnOrderingSurgeryGetSurgeriesInfoDetail(pclsCache, RoomId);
        }

        [Route("Api/v1/orderings")]
        public ResponseResult getDiagnosisInfoList(string DepartmentCode, string Status,string ClinicDate, string PatientName)
        {
            return repository.getDiagnosisInfoList(pclsCache, DepartmentCode, Status, ClinicDate, PatientName);
        }
    }
}
