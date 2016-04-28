using MSRestful.CommonLibrary;
using MSRestful.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSRestful.Models
{
    public interface IPsTrnOutpatientRepository
    {
        ResponseResult GetOutPatients(DataConnection pclsCache, string PatientName, string ClinicDate, string DepartmentCode, string SexType, string ClinicType, string DoctorCode);

        ResponseResult GetPatientDetails(DataConnection pclsCache, string PatientId);

        ResponseResult GetInPatients(DataConnection pclsCache, string PatientId, string PatientName, string AdmissionDate, string RoomCode);

        ResponseResult GetTrnOutInfo(DataConnection pclsCache, string DepartmentCode, string ClinicDate, string PatientName, string DoctorCode, string MedicalStatus);

        ResponseResult GetOutDetailsByPID(DataConnection pclsCache, string PatientId);
    }
}