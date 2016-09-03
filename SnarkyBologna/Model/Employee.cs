using System;
namespace SnarkyBologna
{
	public class Employee
	{
		public String _id { get; set; }
		public String first_name { get; set; }
		public String last_name { get; set; }
		public String address_one { get; set; }
		public String address_two { get; set; }
		public String city { get; set; }
		public String state { get; set; }
		public String zip_code { get; set; }
		public String phone { get; set; }

		public String FullName
		{
			get
			{
				return first_name + " " + last_name;
			}
		}
	}
}

