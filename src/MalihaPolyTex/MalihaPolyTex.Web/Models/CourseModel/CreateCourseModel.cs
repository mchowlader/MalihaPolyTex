using Autofac;
using MalihaPolyTex.Academy.Services;
using System;
using System.Threading.Tasks;

namespace MalihaPolyTex.Web.Models.CourseModel
{
    public class CreateCourseModel
    {
        private ICourseService _courseService;
        private ILifetimeScope _scope;

        public CreateCourseModel()
        {

        }
        public CreateCourseModel(ICourseService courseService, ILifetimeScope scope)
        {
            _scope = scope;
            _courseService = courseService;
        }

        public void Resolve(ILifetimeScope scope)
        {
            _scope = scope;
            _courseService = _scope.Resolve<ICourseService>();
        }

        internal Task CreateCourseAsync()
        {
            throw new NotImplementedException();
        }
    }
}
