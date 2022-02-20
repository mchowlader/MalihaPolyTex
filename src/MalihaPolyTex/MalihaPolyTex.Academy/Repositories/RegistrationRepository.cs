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
    public class RegistrationRepository : Repository<StudentRegistration, int, AcademyDbContext>,
        IRegistrationRepository
    {
        public RegistrationRepository(IAcademyDbContext academyDbContext)
            : base((AcademyDbContext)academyDbContext)
        {

        }
    }
}
