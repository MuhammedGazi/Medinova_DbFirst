using System;

namespace Medinova.DTOs.AppointmentDtos
{
    public class ResultUserAppointmentDto
    {
        public int AppointmentId { get; set; }
        public bool IsActive { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string AppointmentTime { get; set; }
        public string Departmen { get; set; }
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
    }
}