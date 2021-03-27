using System.ComponentModel.DataAnnotations;

namespace TestProject.DataAccess.Entities
{
    public class EmployeeTask : BaseEntity
    {
        [StringLength(200)]
        public string Name { get; set; }
        [StringLength(500)]
        public string Description { get; set; }
        [StringLength(200)]
        public string Employee { get; set; }
        public bool Finished { get; set; }
    }
}
