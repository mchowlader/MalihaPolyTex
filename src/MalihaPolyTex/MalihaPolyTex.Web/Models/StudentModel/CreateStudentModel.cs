using Autofac;
using MalihaPolyTex.Academy.BusinessObjects;
using MalihaPolyTex.Academy.Services;
using System;
using System.Threading.Tasks;

namespace MalihaPolyTex.Web.Models.StudentModel
{
    public class CreateStudentModel
    {
        public string Name { get; set; }
        public int DeptId { get; set; }
        public DateTime DateOfBirth { get; set; }

        private ILifetimeScope _scope;
        private IStudentService _studentService;

        public CreateStudentModel()
        {

        }
        public CreateStudentModel(IStudentService studentService, ILifetimeScope scope)
        {
            _scope = scope;
            _studentService = studentService;
        }
        public void Resolve(ILifetimeScope scope)
        {
            _scope = scope;
            _studentService = _scope.Resolve<IStudentService>();
        }

        public async Task CreateStudentAsync()
        {
            var student = new Student()
            {
                Name = Name,
                DeptId = DeptId,
                DateOfBirth = DateOfBirth
            };
            await _studentService.CreateStudentAsync(student);
        }
    }
}