using System.Collections.Generic;

namespace TestProject.ViewModels.EmployeeTaskViews
{
    public class GetAllEmployeeTaskResponseView
    {
        public List<EmployeeTaskGetAllEmployeeTaskResponseView> EmployeeTasks { get; set; }

        public GetAllEmployeeTaskResponseView()
        {
            EmployeeTasks = new List<EmployeeTaskGetAllEmployeeTaskResponseView>();
        }
    }

    public class EmployeeTaskGetAllEmployeeTaskResponseView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Employee { get; set; }
        public bool Finished { get; set; }
    }
}
