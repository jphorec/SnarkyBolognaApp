using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace SnarkyBologna
{
	public partial class EmployeesListPage : ContentPage
	{
		public EmployeesListPage()
		{
			InitializeComponent();
		}

		protected async override void OnAppearing()
		{
			base.OnAppearing();

			listView.ItemsSource = await App.EmployeeManager.GetEmployeesAsync();
		}
		void OnAddItemClicked(object sender, EventArgs e)
		{
			var employee = new Employee();
			var employeePage = new EmployeePage(true);
			employeePage.BindingContext = employee;
			Navigation.PushAsync(employeePage);
		}
		void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			var employee = e.SelectedItem as Employee;
			var employeePage = new EmployeePage();
			employeePage.BindingContext = employee;
			Navigation.PushAsync(employeePage);
		}
	}
}

