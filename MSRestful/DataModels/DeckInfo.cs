using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MSRestful.DataModels
{
    public class DeckInfo
    {
        public int ID { get; set; }
        public string DeckName { get; set; }
        public string[] DeckSectionNames { get; set; }
        public int BedCount { get; set; }
        public int BedAvailCount { get; set; }
        public int SurgeryRoomCount { get; set; }
        public int SurgeryRoomAvailCount { get; set; }
        public int DutyRoomCount { get; set; }
    }

    public class DeckSectionInfo
    {
        public string ID { get; set; }
        public int BedCount { get; set; }
        public int BedAvailCount { get; set; }
        public int SurgeryRoomCount { get; set; }
        public int SurgeryRoomAvailCount { get; set; }
        public int DutyDoctorCount { get; set; }
    }

    public class SurgeryRoomInfo
    {
        public string DeckId { get; set; }
        public string DeckSectionId { get; set; }
        public string SurgeryRoomId { get; set; }
        public string SubSurgeryRoomId { get; set; }
        public int Status { get; set; }
    }

    public class BedInfo
    {
        public string DeckId { get; set; }
        public string DeckSectionId { get; set; }
        public string WardCode { get; set; }
        public string RoomCode { get; set; }
        public string BedCode { get; set; }
        public int Status { get; set; }
        public string PatientName { get; set; }

    }

    public class DutyDoctorInfo
    {
        public string DeckId { get; set; }
        public string DeckSectionId { get; set; }
        public string DoctorId { get; set; }
        public string SortNo { get; set; }
        public string DoctorName { get; set; }
        public string Time1 { get; set; }
        public string Time2 { get; set; }
        public string Affiliation { get; set; }
    }

    public class DeckInfoDetail
    {
        public List<BedInfo> bedInfoList { get; set; }
        public List<SurgeryRoomInfo> surgeryRoomInfoList { get; set; }
        public List<DutyDoctorInfo> dutyDoctorInfoList { get; set; }
        public DeckInfoDetail()
        {
            bedInfoList = new List<BedInfo>();
            surgeryRoomInfoList = new List<SurgeryRoomInfo>();
            dutyDoctorInfoList = new List<DutyDoctorInfo>();
        }
    }
}