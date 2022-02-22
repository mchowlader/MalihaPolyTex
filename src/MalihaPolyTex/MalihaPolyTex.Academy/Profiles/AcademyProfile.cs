using AutoMapper;
using BO = MalihaPolyTex.Academy.BusinessObjects;
using EO = MalihaPolyTex.Academy.Entities;

namespace MalihaPolyTex.Academy.Profiles
{
    public class AcademyProfile : Profile
    {
        public AcademyProfile()
        {
            CreateMap<EO.Student, BO.Student>().ReverseMap();
            CreateMap<EO.Course, BO.Course>().ReverseMap();
            CreateMap<EO.Department, BO.Department>().ReverseMap();
            CreateMap<EO.StudentRegistration, BO.StudentRegistration>().ReverseMap();
        }
    }
}