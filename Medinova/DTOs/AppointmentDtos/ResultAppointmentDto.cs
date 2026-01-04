using System;

namespace Medinova.DTOs.AppointmentDtos
{
    public class ResultAppointmentDto
    {
        public int AppointmentId { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string AppointmentTime { get; set; }
        public string Departmen { get; set; }
    }
}