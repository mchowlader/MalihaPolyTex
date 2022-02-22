using Autofac;
using MalihaPolyTex.Web.Models.CourseModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace MalihaPolyTex.Web.Controllers
{
    public class CourseController : Controller
    {
        private readonly ILifetimeScope _scope;
        private readonly ILogger<CourseController> _logger;

        public CourseController(ILogger<CourseController> logger, ILifetimeScope scope)
        {
            _scope = scope;
            _logger = logger;
        }
        public IActionResult Create()
        {
            var model = _scope.Resolve<CreateCourseModel>();
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateCourseModel model)
        {
            if (ModelState.IsValid)
            {
                model.Resolve(_scope);

                try
                {
                    await model.CreateCourseAsync();
                }
                catch(Exception ex)
                {
                    _logger.LogError(ex, "Course dosen't create.");
                }
            }
            return View(model);
        }
    }
}
