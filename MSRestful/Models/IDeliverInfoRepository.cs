using MSRestful.CommonLibrary;
using MSRestful.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MSRestful.Models
{
    public interface IDeliverInfoRepository
    {
        ResponseResult CmPDAInfoGetPatientsInfo(DataConnection pclsCache, string PatientId, int Gender, string PatientName, string BloodType);

        ResponseResult CmMstUserGetDoctorsInfo(DataConnection pclsCache, string DoctorId, string Affiliation, string Status, string DoctorName, string Position);

        ResponseResult CmMstUserGetDoctorInfoDetail(DataConnection pclsCache, string DoctorId);

        ResponseResult OdTrnOrderingSurgeryGetSurgeriesInfo(DataConnection pclsCache, string SurgeryRoom1, string SurgeryRoom2, string SurgeryDateTime, string SurgeryDeptCode);

        ResponseResult OdTrnOrderingSurgeryGetSurgeriesInfoDetail(DataConnection pclsCache, string RoomId);
        ResponseResult getDiagnosisInfoList(DataConnection pclsCache, string DepartmentCode, string Status, string ClinicDate, string PatientName);
    }
}