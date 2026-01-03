using AutoMapper;
using Medinova.DTOs.AboutDtos;
using Medinova.DTOs.AboutItemDtos;
using Medinova.DTOs.BannerDtos;
using Medinova.DTOs.DepartmenDtos;
using Medinova.DTOs.DoctorDtos;
using Medinova.DTOs.ServiceDtos;
using Medinova.DTOs.TestimonialDtos;
using Medinova.Models;

namespace Medinova.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Banner, ResultBannerDto>().ReverseMap();
            CreateMap<Banner, CreateBannerDto>().ReverseMap();
            CreateMap<Banner, UpdateBannerDto>().ReverseMap();


            CreateMap<About, ResultAboutDto>().ReverseMap();
            CreateMap<About, CreateAboutDto>().ReverseMap();
            CreateMap<About, UpdateAboutDto>().ReverseMap();

            CreateMap<AboutItem, ResultAboutItemDto>().ReverseMap();
            CreateMap<AboutItem, CreateAboutItemDto>().ReverseMap();
            CreateMap<AboutItem, UpdateAboutItemDto>().ReverseMap();

            CreateMap<Departmen, ResultDepartmenDto>().ReverseMap();
            CreateMap<Departmen, CreateDepartmenDto>().ReverseMap();
            CreateMap<Departmen, UpdateDepartmenDto>().ReverseMap();

            CreateMap<Doctor, ResultDoctorDto>().ReverseMap();
            CreateMap<Doctor, CreateDoctorDto>().ReverseMap();
            CreateMap<Doctor, UpdateDoctorDto>().ReverseMap();

            CreateMap<Service, ResultServiceDto>().ReverseMap();
            CreateMap<Service, CreateServiceDto>().ReverseMap();
            CreateMap<Service, UpdateServiceDto>().ReverseMap();

            CreateMap<Testimonial, ResultTestimonialDto>().
                ForMember(dest=>dest.UserFullName,
                          opt=>opt.MapFrom(src=> src.User.FirstName + " " + src.User.LastName));
            CreateMap<Testimonial, CreateTestimonialDto>().ReverseMap();
            CreateMap<Testimonial, UpdateTestimonialDto>().ReverseMap();
           
        }
    }
}