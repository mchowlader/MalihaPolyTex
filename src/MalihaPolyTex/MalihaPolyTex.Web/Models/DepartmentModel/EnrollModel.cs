using Autofac;
using MalihaPolyTex.Academy.BusinessObjects;
using MalihaPolyTex.Academy.Services;
using MalihaPolyTex.Academy.Utilities;
using System;
using System.Threading.Tasks;

namespace MalihaPolyTex.Web.Models.DepartmentModel
{
    public class EnrollModel
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public DateTime EnrollDate { get; set; }
        public bool IsPaymentComplete { get; set; }

        private ILifetimeScope _scope;
        private IDepartmentService _departmentService;
        private IDateTimeUtility _dateTimeUtility;
        public EnrollModel()
        {

        }

        public EnrollModel(IDepartmentService departmentService, IDateTimeUtility dateTimeUtility)
        {
            _dateTimeUtility = dateTimeUtility;
            _departmentService = departmentService;
        }
        public void Resolve(ILifetimeScope scope)
        {
            _scope = scope;
            _dateTimeUtility = _scope.Resolve<IDateTimeUtility>();
            _departmentService = _scope.Resolve<IDepartmentService>();
        }

        public async Task EnrollStudentAsync()
        {
            var enroll = new StudentRegistration()
            {
                StudentId = StudentId,
                CourseId = CourseId,
                EnrollDate = _dateTimeUtility.Now,
                IsPaymentComplete = IsPaymentComplete
            };

            await _departmentService.EnrollStudentAsync(enroll);
        }
    }
}
