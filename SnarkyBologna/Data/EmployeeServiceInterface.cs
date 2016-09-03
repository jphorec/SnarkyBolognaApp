using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SnarkyBologna
{
	public interface EmployeeServiceInterface
	{
		Task<List<Employee>> RefreshDataAsync();

		Task SaveEmployeeAsync(Employee employee, bool isNewEmployee);

		Task DeleteEmployeeAsync(String id);
	}
}

