using System;
using System.Collections.Generic;

namespace HospitalDALLibrary.Model
{
    public partial class Patient
    {
        public Patient()
        {
            Appointments = new HashSet<Appointment>();
        }
        public Patient(string? patientName, int? patientAge, string? patientGender, string? patientAddress, string? patientPhoneNumber)
        {
            PatientName = patientName;
            PatientAge = patientAge;
            PatientGender = patientGender;
            PatientAddress = patientAddress;
            PatientPhoneNumber = patientPhoneNumber;
        }

        public int PatientId { get; set; }
        public string? PatientName { get; set; }
        public int? PatientAge { get; set; }
        public string? PatientGender { get; set; }
        public string? PatientAddress { get; set; }
        public string? PatientPhoneNumber { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }

        public override string ToString()
        {
            return $"PatientId: {PatientId}, PatientName: {PatientName}, PatientAge: {PatientAge}, PatientGender: {PatientGender}, PatientAddress: {PatientAddress}, PatientPhoneNumber: {PatientPhoneNumber}";
        }
    }
}
