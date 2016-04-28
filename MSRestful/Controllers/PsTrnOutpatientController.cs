using MSRestful.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MSRestful.CommonLibrary;
using MSRestful.DataModels;

namespace MSRestful.Controllers
{
    public class PsTrnOutpatientController : ApiController
    {
        static readonly IPsTrnOutpatientRepository repository = new PsTrnOutpatientRepository();
        DataConnection pclsCache = new DataConnection();

        /// <summary>
        /// 病人信息查询 施宇帆 2016-04-27 
        /// </summary>
        /// <param name="PatientName"></param>
        /// <param name="ClinicDate"></param>
        /// <param name="DepartmentCode"></param>
        /// <param name="SexType"></param>
        /// <param name="ClinicType"></param>
        /// <param name="DoctorCode"></param>
        /// <returns></returns>
        public ResponseResult GetOutPatients(string PatientName, string ClinicDate, string DepartmentCode, string SexType, string ClinicType, string DoctorCode)
        {
            return repository.GetOutPatients(pclsCache, PatientName, ClinicDate, DepartmentCode, SexType, ClinicType, DoctorCode);
        }

        /// <summary>
        /// 查看病人详情 施宇帆 2016-04-28
        /// </summary>
        /// <param name="PatientId"></param>
        /// <returns></returns>
        public ResponseResult GetPatientDetails(string PatientId)
        {
            return repository.GetPatientDetails(pclsCache, PatientId);
        }

        /// <summary>
        /// 查看伤员详情 施宇帆 2016-04-28
        /// </summary>
        /// <param name="PatientId"></param>
        /// <returns></returns>
        public ResponseResult GetInjuryPDetails(string PatientId)
        {
            return repository.GetPatientDetails(pclsCache, PatientId);
        }

        /// <summary>
        /// 住院信息查询 施宇帆 2016-04-28
        /// </summary>
        /// <param name="PatientId"></param>
        /// <param name="PatientName"></param>
        /// <param name="AdmissionDate"></param>
        /// <param name="RoomCode"></param>
        /// <returns></returns>
        public ResponseResult GetInPatients(string PatientId, string PatientName, string AdmissionDate, string RoomCode)
        {
            return repository.GetInPatients(pclsCache, PatientId, PatientName, AdmissionDate, RoomCode);
        }

        /// <summary>
        /// 门诊信息查询 施宇帆 2016-04-28
        /// </summary>
        /// <param name="DepartmentCode"></param>
        /// <param name="ClinicDate"></param>
        /// <param name="PatientName"></param>
        /// <param name="DoctorCode"></param>
        /// <param name="MedicalStatus"></param>
        /// <returns></returns>
        public ResponseResult GetTrnOutInfo(string DepartmentCode, string ClinicDate, string PatientName, string DoctorCode, string MedicalStatus)
        {
            return repository.GetTrnOutInfo(pclsCache, DepartmentCode, ClinicDate, PatientName, DoctorCode, MedicalStatus);
        }

        /// <summary>
        /// 获取病人门诊信息详情 最新一条数据 施宇帆 2016-04-28
        /// </summary>
        /// <param name="PatientId"></param>
        /// <returns></returns>
        public ResponseResult GetOutDetailsByPID(string PatientId)
        {
            return repository.GetOutDetailsByPID(pclsCache, PatientId);
        }
    }
}