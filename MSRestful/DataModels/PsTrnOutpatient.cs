using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MSRestful.DataModels
{
   
    public class PsTrnOutpatient
    {
        public string PatientId { get; set; }
        public string PatientName { get; set; }
        public string SexType { get; set; }
        public string Age { get; set; }
        public string DepartmentName { get; set; }

        public string DoctorName { get; set; }
        public string BloodTypeName { get; set; }
        public string ClinicTypeName { get; set; }
        public int ClinicDate { get; set; }
        public string DiseaseName { get; set; }
    }

    public class CmTrnPatient
    {
        public string PatientName { get; set; }
        public string Age { get; set; }
        public string Sex { get; set; }
        public string Blood { get; set; }
        public int ClinicDate { get; set; }
       
        public string DepartmentName { get; set; }
        public string DoctorName { get; set; }
    }

    public class Assistant //助手对象数组
    {
        public string Assistant1Name { get; set; }
        public string Assistant2Name { get; set; }
        public string Assistant3Name { get; set; }
        public string Assistant4Name { get; set; }
    }

    public class Nurse //护士对象数组
    {
        public string TableNurse1Name { get; set; }
        public string TableNurse2Name { get; set; }
    }
    public class OrderingSurgery
    {

        public string OrderName { get; set; }
        public string DiseaseCondition { get; set; }
        public string SurgeryRoom1 { get; set; }
        public string SurgeryDepartmentName { get; set; }
        public string IsolationFlag { get; set; }
        public string PreDiagnosis { get; set; }
        
        public Assistant Assistant{ get; set; }

        public string SurgeryDateTime { get; set; }
        public string SurgeryRoom2 { get; set; }
        public string SurgeryLevel { get; set; }
        public string SurgeryDoctorName { get; set; }
        public string TransfusionDoctorName { get; set; }
        public string AnesthesiaMethod { get; set; }
        public Nurse TableNurse { get; set; }
        public OrderingSurgery()
        {
            Assistant = new Assistant();
            TableNurse = new Nurse();
        }
    }

    public class PsTrnInpatient
    {
        public string AdmissionDate { get; set; }
        public int AdDays { get; set; }
        public string DoctorName { get; set; }
        public string NurseName { get; set; }
        public string RoomName { get; set; }
        public string BedName { get; set; }
        public string WardName { get; set; }
        public string Diagnosis { get; set; }
    }

    public class PatientDetails
    {
        public CmTrnPatient CmTrnPatient { get; set; }
        public List<OrderingSurgery> OrderingSurgery { get; set; }
        public List<PsTrnInpatient> PsTrnInpatient { get; set; }
    }

    public class Inpatients
    {

        public string PatientId { get; set; }
        public string PatientName { get; set; }
        public string SexType { get; set; }
        public int Age { get; set; }
        public string WardName { get; set; }
        public string AdmissionDate { get; set; }
        public int AdDays { get; set; }
        public string DoctorName { get; set; }
        public string NurseName { get; set; }
        public string Diagnosis { get; set; }
        public string RoomName { get; set; }
        public string BedName { get; set; }

    }

    public class Outpatients
    {
        public string PatientId { get; set; }
        public string PatientName { get; set; }
        public int ConsultationType { get; set; }
        public string DepartmentName { get; set; }
        public string DoctorName { get; set; }
        public int ClinicDate { get; set; }
        public string ClinicTypeName { get; set; }
        public int MedicalStatus { get; set; }
        public string DiseaseName { get; set; }
    }

    public class OutpatientDetails
    {
        public string PatientId { get; set; }
        public string PatientName { get; set; }
        public string PatientSexName { get; set; }
        public string PatientAge { get; set; }
        public string PatientBloodName { get; set; }

        public string ConsultationType { get; set; }
        public string ClinicType { get; set; }
        public string MedicalStatus { get; set; }
        public string RegisterTime { get; set; }
        public string ClinicTime { get; set; }

        public string DepartmentName { get; set; }
        public string DoctorName { get; set; }
        public string DiseaseName { get; set; }
        public string Number { get; set; }
    }

}