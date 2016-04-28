using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MSRestful.DataModels
{
    public class DeliverInfo
    {
    }

    public class ResponseResult
    {
        public object data { get; set; }
        public int code { get; set; }
        public string msg { get; set; }
    }

    public class PatientInfo
    {
        public string PatientId { get; set; }
        public string PatientName { get; set; }
        public string Gender { get; set; }
        public string Birthday { get; set; }
        public string BloodType { get; set; }
        public string DrugAllergy { get; set; }
        public string Diagnosis { get; set; }
        public string ToPlace { get; set; }
    }

    public class DoctorInfo
    {
        public string DoctorId { get; set; }
        public string DoctorName { get; set; }
        public string Affiliation { get; set; }
        public string Occupation { get; set; }
        public string Position { get; set; }
        public string Status { get; set; }
        public string DutyRoom { get; set; }
    }

    public class DoctorInfoDetail
    {
        public string DoctorId { get; set; }
        public string DoctorName { get; set; }
        public string DeptName { get; set; }
        public string PositionName { get; set; }
        public string Status { get; set; }
        public string DoctorIntro { get; set; }
        public string DutyStatus { get; set; }
        public string Time1 { get; set; }
        public string Time2 { get; set; }
        public string RoomName { get; set; }
    }

    public class SurgeryInfo
    {
        public string SurgeryRoomId { get; set; }
        public string SurgeryRoom1 { get; set; }
        public string SurgeryRoom2 { get; set; }
        public string SurgeryTable { get; set; }
        public string SurgeryDate { get; set; }
        public string SurgeryDeptCode { get; set; }
        public string PatientId { get; set; }
        public string PatientName { get; set; }
        public string Diagnosis { get; set; }
        public string SurgeryName { get; set; }
        public string SurgeryDoctor { get; set; }
    }

    public class SurgeryInfoDetail
    {
        public string PatientId { get; set; }
        public string PatientName { get; set; }
        public string SurgeryName { get; set; }
        public string Diagnosis { get; set; }
        public string DiseaseCondition { get; set; }
        public string SurgeryDate { get; set; }
        public string SurgeryRoom1 { get; set; }
        public string SurgeryRoom2 { get; set; }
        public string SurgeryTable { get; set; }
        public string IsolationFlag { get; set; }
        public string SurgeryLevel { get; set; }
        public string SurgeryDept { get; set; }
        public string SurgeryDoctor { get; set; }
        public string Assistant1 { get; set; }
        public string Assistant2 { get; set; }
        public string Assistant3 { get; set; }
        public string Assistant4 { get; set; }
        public string TransfusionDoctor { get; set; }
        public string AnesthesiaMethod { get; set; }
        public string AnesthesiaDoctor1 { get; set; }
        public string AnesthesiaDoctor2 { get; set; }
        public string TableNurse1 { get; set; }
        public string TableNurse2 { get; set; }
        public string SupplyNurse1 { get; set; }
        public string SupplyNurse2 { get; set; }
    }

    public class Ordering
    {
        public string PatientId { get; set; }
        public string PatientName { get; set; }
        public string OrderName { get; set; }
        public string Status { get; set; }
        public string ApplyDepartment { get; set; }
        public string TargetDepartment { get; set; }
        public string ClinicDate { get; set; }
    }
}