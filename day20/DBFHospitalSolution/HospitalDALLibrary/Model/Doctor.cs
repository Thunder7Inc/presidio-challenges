using System;
using System.Collections.Generic;

namespace HospitalDALLibrary.Model
{
    public partial class Doctor
    {
        public Doctor()
        {
            Appointments = new HashSet<Appointment>();
        }
        public Doctor(string? doctorName, string? doctorSpecialization)
        {
            DoctorName = doctorName;
            DoctorSpecialization = doctorSpecialization;
        }
        public int DoctorId { get; set; }
        public string? DoctorName { get; set; }
        public string? DoctorSpecialization { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }

        public override string ToString()
        {
            return $"DoctorId: {DoctorId}, DoctorName: {DoctorName}, DoctorSpecialization: {DoctorSpecialization}";
        }
    }
}
