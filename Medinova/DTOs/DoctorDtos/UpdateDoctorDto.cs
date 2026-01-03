using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Medinova.DTOs.DoctorDtos
{
    public class UpdateDoctorDto
    {
        public int DoctorId { get; set; }
        public string FullName { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public int DepartmenId { get; set; }
    }
}