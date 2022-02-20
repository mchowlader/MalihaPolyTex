using AutoMapper;
using MalihaPolyTex.Academy.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalihaPolyTex.Academy.Services
{
    public class CourseService : ICourseService
    {
        private readonly AcademyUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CourseService(AcademyUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
    }
}