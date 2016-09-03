using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text;

namespace SnarkyBologna
{
	public class EmployeeService : EmployeeServiceInterface
	{
		HttpClient client;
		public List<Employee> Employees { get; private set; }

		public EmployeeService()
		{
			client = new HttpClient();
			client.MaxResponseContentBufferSize = 256000;
		}

		public async Task DeleteEmployeeAsync(String id)
		{
			var uri = new Uri(String.Format(Constants.BaseRestURL, id));
			Debug.WriteLine(uri);
			try
			{
				var response = await client.DeleteAsync(uri);

				if (response.IsSuccessStatusCode)
				{
					Debug.WriteLine(@"				Employee successfully removed.");
				}

			}
			catch (Exception ex)
			{
				Debug.WriteLine(@"				ERROR {0}", ex.Message);
			}

		}

		public async Task<List<Employee>> RefreshDataAsync()
		{
			Employees = new List<Employee>();

			var uri = new Uri(string.Format(Constants.BaseRestURL, string.Empty));

			try
			{

				var response = await client.GetAsync(uri);
				if (response.IsSuccessStatusCode)
				{
					var content = await response.Content.ReadAsStringAsync();
					Employees = JsonConvert.DeserializeObject<List<Employee>>(content);
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(@"				ERROR {0}", ex.Message);
			}

			return Employees;
		}

		public async Task SaveEmployeeAsync(Employee employee, bool isNewEmployee = false)
		{
			var uri = new Uri(string.Format(Constants.BaseRestURL, isNewEmployee ? String.Empty : employee._id));

			try
			{
				var json = JsonConvert.SerializeObject(employee);
				var content = new StringContent(json, Encoding.UTF8, "application/json");

				HttpResponseMessage response = null;
				if (isNewEmployee)
				{
					response = await client.PostAsync(uri, content);
				}
				else {
					response = await client.PutAsync(uri, content);
				}

				if (response.IsSuccessStatusCode)
				{
					Debug.WriteLine(@"				Employee successfully saved.");
				}

			}
			catch (Exception ex)
			{
				Debug.WriteLine(@"				ERROR {0}", ex.Message);
			}
		}
	}
}

