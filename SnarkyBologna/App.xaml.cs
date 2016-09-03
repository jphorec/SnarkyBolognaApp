using Xamarin.Forms;
using System;

namespace SnarkyBologna
{
	public partial class App : Application
	{
		public static EmployeeManager EmployeeManager { get; private set; }

		public App()
		{
			EmployeeManager = new EmployeeManager(new EmployeeService());
			MainPage = new NavigationPage(new EmployeesListPage());
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}

