using MSRestful.CommonLibrary;
using MSRestful.DataMethod;
using MSRestful.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MSRestful.Models
{
    public class PsTrnOutpatientRepository : IPsTrnOutpatientRepository
    {
        public ResponseResult GetOutPatients(DataConnection pclsCache, string PatientName, string ClinicDate, string DepartmentCode, string SexType, string ClinicType, string DoctorCode)
        {

            return new PsTrnOutpatientMethod().GetOutPatients(pclsCache, PatientName, ClinicDate, DepartmentCode, SexType, ClinicType, DoctorCode);
        }

        /// <summary>
        /// 封装查看病人详情 施宇帆 2016-04-28
        /// </summary>
        /// <param name="pclsCache"></param>
        /// <param name="PatientId"></param>
        /// <returns></returns>
        public ResponseResult GetPatientDetails(DataConnection pclsCache, string PatientId)
        {
            ResponseResult Result = new ResponseResult();
            PatientDetails PatientDetails   = new PatientDetails();
            PatientDetails.CmTrnPatient     = new PsTrnOutpatientMethod().GetPatientInfoNew(pclsCache, PatientId);
            PatientDetails.OrderingSurgery  = new PsTrnOutpatientMethod().GetInfobyPID(pclsCache, PatientId);
            PatientDetails.PsTrnInpatient   = new PsTrnOutpatientMethod().GetInPByPID(pclsCache, PatientId);
            Result.data = PatientDetails;
            Result.code = new PsTrnOutpatientMethod().Code(PatientDetails);
            Result.msg = "病人门诊信息详情" + new PsTrnOutpatientMethod().MSG(PatientDetails);
            return Result;
        }

        public ResponseResult GetInPatients(DataConnection pclsCache, string PatientId, string PatientName, string AdmissionDate, string RoomCode)
        {
            return new PsTrnOutpatientMethod().GetInPatients(pclsCache, PatientId, PatientName, AdmissionDate, RoomCode);
        }

        public ResponseResult GetTrnOutInfo(DataConnection pclsCache, string DepartmentCode, string ClinicDate, string PatientName, string DoctorCode, string MedicalStatus)
        {
            return new PsTrnOutpatientMethod().GetTrnOutInfo(pclsCache, DepartmentCode, ClinicDate, PatientName, DoctorCode, MedicalStatus);
        }

        public ResponseResult GetOutDetailsByPID(DataConnection pclsCache, string PatientId)
        {
            return new PsTrnOutpatientMethod().GetOutDetailsByPID(pclsCache, PatientId);
        }
    }
}