using DevSkill.Data;
using MalihaPolyTex.Academy.Contexts;
using MalihaPolyTex.Academy.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalihaPolyTex.Academy.Repositories
{
    internal class CourseRepository : Repository<Course, int, AcademyDbContext>, ICourseRepository
    {
        public CourseRepository(IAcademyDbContext academyDbContext)
            : base((AcademyDbContext)academyDbContext)
        {

        }
    }
}
