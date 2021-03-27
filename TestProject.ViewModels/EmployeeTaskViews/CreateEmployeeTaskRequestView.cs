using System.ComponentModel.DataAnnotations;

namespace TestProject.ViewModels.EmployeeTaskViews
{
    public class CreateEmployeeTaskRequestView
    {
        [Required]
        [StringLength(200)]
        public string Name { get; set; }
        [Required]
        [StringLength(500)]
        public string Description { get; set; }
        [Required]
        [StringLength(200)]
        public string Employee { get; set; }
    }
}
