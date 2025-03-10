using UKParliament.CodeTest.Data.Repositories;
using UKParliament.CodeTest.Services.Models;

namespace UKParliament.CodeTest.Services;

public class DepartmentService : IDepartmentService
{
    private readonly IDepartmentRepository _departmentRepository;

    public DepartmentService(IDepartmentRepository departmentRepository)
    {
        _departmentRepository = departmentRepository;
    }

    public async Task<ICollection<DepartmentModel>> GetDepartments()
    {
        var departments = await _departmentRepository.GetDepartmentsAsync();

        return departments.Select(d => new DepartmentModel(d.Id, d.Name)).ToList();
    }
}