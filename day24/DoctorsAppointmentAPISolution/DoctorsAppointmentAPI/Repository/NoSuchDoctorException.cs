using System.Runtime.Serialization;

namespace DoctorsAppointmentAPI.Repository
{
    [Serializable]
    internal class NoSuchDoctorException : Exception
    {
        public NoSuchDoctorException()
        {
        }

        public NoSuchDoctorException(string? message) : base(message)
        {
        }

        public NoSuchDoctorException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected NoSuchDoctorException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}