using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace SnarkyBologna
{
	public class EmployeeManager
	{
		EmployeeServiceInterface employeeService;

		public EmployeeManager(EmployeeServiceInterface employeeService)
		{
				this.employeeService = employeeService;
		}

		public Task<List<Employee>> GetEmployeesAsync()
		{
			return employeeService.RefreshDataAsync();
		}
		public Task SaveEmployeeAsync(Employee employee, bool isNewEmployee = false)
		{
			return employeeService.SaveEmployeeAsync(employee, isNewEmployee);
		}

		public Task DeleteEmployeeAsync(String id)
		{
			return employeeService.DeleteEmployeeAsync(id);
		}
	}
}
