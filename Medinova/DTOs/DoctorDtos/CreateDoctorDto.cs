namespace Medinova.DTOs.DoctorDtos
{
    public class CreateDoctorDto
    {
        public string FullName { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public int DepartmenId { get; set; }
    }
}