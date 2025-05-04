using AutoMapper;
using SchoolUser.Application.DTOs;
using SchoolUser.Domain.Models;

namespace SchoolUser.Domain.Mappings
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            // User Mappings
            CreateMap<User, UserAddRequestDto>().ReverseMap();
            CreateMap<User, UserUpdateRequestDto>().ReverseMap();
            CreateMap<User, LoginResponseDto>().ReverseMap();

            // Corrected User -> UserResponseDto Mapping
            CreateMap<User, UserResponseDto>()
                .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.BirthDate))
                .ForMember(dest => dest.Roles, opt => opt.MapFrom(src => src.Roles ?? new List<string>()))
                .ForMember(dest => dest.Student, opt => opt.MapFrom(src => src.Student))
                .ForMember(dest => dest.Teacher, opt => opt.MapFrom(src => src.Teacher))
                .ReverseMap(); // Allows bidirectional mapping if needed

            // Corrected Student & Teacher Mappings
            CreateMap<Student, StudentDto>().ReverseMap();
            CreateMap<Teacher, TeacherDto>().ReverseMap();
        }
    }
}
