using System;
using System.Collections.Generic;

namespace HospitalDALLibrary.Model
{
    public partial class Appointment
    {
        public Appointment()
        {
        }
        public Appointment(int? patientId, int? doctorId, DateTime? appointmentDate, DateTime? appointmentBookDateTime)
        {
            PatientId = patientId;
            DoctorId = doctorId;
            AppointmentDate = appointmentDate;
            AppointmentBookDateTime = appointmentBookDateTime;
        }
        public int AppointmentId { get; set; }
        public int? PatientId { get; set; }
        public int? DoctorId { get; set; }
        public DateTime? AppointmentDate { get; set; }
        public DateTime? AppointmentBookDateTime { get; set; }

        public virtual Doctor? Doctor { get; set; }
        public virtual Patient? Patient { get; set; }

        public override string ToString()
        {
            return $"AppointmentId: {AppointmentId}, PatientId: {PatientId}, DoctorId: {DoctorId}, AppointmentDate: {AppointmentDate}, AppointmentBookDateTime: {AppointmentBookDateTime}";
        }
    }
}
