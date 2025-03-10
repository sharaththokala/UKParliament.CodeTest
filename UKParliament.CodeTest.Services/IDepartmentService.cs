using UKParliament.CodeTest.Services.Models;

namespace UKParliament.CodeTest.Services;

public interface IDepartmentService
{
   public Task<ICollection<DepartmentModel>> GetDepartments();
}
