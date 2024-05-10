using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalDALLibrary
{
    public class EmptyDataBaseException : Exception
    {
        string message;

        public EmptyDataBaseException()
        {
            this.message = "No Data found in Data Base";
        }
        public EmptyDataBaseException(string name) 
        {
            this.message = $"No Data found in {name} Data Base";
        }
        public override string Message => message;
    }

    public class DoctorIdNotFoundException : Exception
    {
        string message;
        public DoctorIdNotFoundException()
        {
            this.message = "Doctor ID not found";
        }
        public DoctorIdNotFoundException(int id)
        {
            this.message = $"Doctor with ID {id} not found";
        }
        public override string Message => message;
    }

    public class DuplicateDoctorDetailsException : Exception
    {
        string message;
        public DuplicateDoctorDetailsException()
        {
            this.message = "Doctor Details already exists";
        }
        public override string Message => message;
    }

    public class DuplicatePatientDetailsException : Exception
    {
        string message;
        public DuplicatePatientDetailsException()
        {
            this.message = "Patient Details already exists";
        }
        public override string Message => message;
    }

    public class PatientIdNotFoundException : Exception
    {
        string message;
        public PatientIdNotFoundException()
        {
            this.message = "Patient ID not found";
        }
        public PatientIdNotFoundException(int id)
        {
            this.message = $"Patient with ID {id} not found";
        }
        public override string Message => message;
    }


    public class DuplicateAppointmentDetailsException : Exception
    {
        string message;
        public DuplicateAppointmentDetailsException()
        {
            this.message = "Appointment Details already exists";
        }
        public override string Message => message;
    }


    public class AppointmentIdNotFoundException : Exception
    {
        string message;
        public AppointmentIdNotFoundException()
        {
            this.message = "Appointment ID not found";
        }
        public AppointmentIdNotFoundException(int id)
        {
            this.message = $"Appointment with ID {id} not found";
        }
        public override string Message => message;
    }

}
