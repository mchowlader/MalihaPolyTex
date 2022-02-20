using AutoMapper;
using MalihaPolyTex.Academy.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalihaPolyTex.Academy.Services
{
    public class StudentService : IStudentService
    {
        private readonly AcademyUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public StudentService(AcademyUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
    }
}