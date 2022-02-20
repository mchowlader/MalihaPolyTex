using DevSkill.Data;

namespace MalihaPolyTex.Academy.Entities
{
    public class Department : IEntity<int>
    {
        public int Id { get; set; }
        public string DeptName { get; set; }
    }
}