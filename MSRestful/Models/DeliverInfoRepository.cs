using MSRestful.CommonLibrary;
using MSRestful.DataMethod;
using MSRestful.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MSRestful.Models
{
    public class DeliverInfoRepository : IDeliverInfoRepository
    {
        DeliverInfoMethod DeliverInfoMethod = new DeliverInfoMethod();
        public ResponseResult CmPDAInfoGetPatientsInfo(DataConnection pclsCache, string PatientId, int Gender, string PatientName, string BloodType)
        {
            return DeliverInfoMethod.CmPDAInfoGetPatientsInfo(pclsCache, PatientId, Gender, PatientName, BloodType);
        }

        public ResponseResult CmMstUserGetDoctorsInfo(DataConnection pclsCache, string DoctorId, string Affiliation, string Status, string DoctorName, string Position)
        {
            return DeliverInfoMethod.CmMstUserGetDoctorsInfo(pclsCache, DoctorId, Affiliation, Status, DoctorName, Position);
        }

        public ResponseResult CmMstUserGetDoctorInfoDetail(DataConnection pclsCache, string DoctorId)
        {
            return DeliverInfoMethod.CmMstUserGetDoctorInfoDetail(pclsCache, DoctorId);
        }

        public ResponseResult OdTrnOrderingSurgeryGetSurgeriesInfo(DataConnection pclsCache, string SurgeryRoom1, string SurgeryRoom2, string SurgeryDateTime, string SurgeryDeptCode)
        {
            return DeliverInfoMethod.OdTrnOrderingSurgeryGetSurgeriesInfo(pclsCache, SurgeryRoom1, SurgeryRoom2, SurgeryDateTime, SurgeryDeptCode);
        }

        public ResponseResult OdTrnOrderingSurgeryGetSurgeriesInfoDetail(DataConnection pclsCache, string RoomId)
        {
            return DeliverInfoMethod.OdTrnOrderingSurgeryGetSurgeriesInfoDetail(pclsCache, RoomId);
        }
        public   ResponseResult getDiagnosisInfoList(DataConnection pclsCache, string DepartmentCode, string Status, string ClinicDate, string PatientName)
        {
            return DeliverInfoMethod.getDiagnosisInfoList(pclsCache, DepartmentCode,  Status,  ClinicDate,  PatientName);
        }

      

    }
}