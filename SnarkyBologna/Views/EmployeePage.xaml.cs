using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace SnarkyBologna
{
	public partial class EmployeePage : ContentPage
	{
		bool isNewEmployee; 

		public EmployeePage(bool isNew = false)
		{
			InitializeComponent();
			isNewEmployee = isNew;
		}
		async void OnSaveActivated(object sender, EventArgs e)
		{
			var employee = (Employee)BindingContext;
			await App.EmployeeManager.SaveEmployeeAsync(employee, isNewEmployee);
			await Navigation.PopAsync();
		}

		async void OnDeleteActivated(object sender, EventArgs e)
		{
			var employee = (Employee)BindingContext;
			await App.EmployeeManager.DeleteEmployeeAsync(employee._id);
			await Navigation.PopAsync();
		}

		void OnCancelActivated(object sender, EventArgs e)
		{
			Navigation.PopAsync();
		}

	}
}

