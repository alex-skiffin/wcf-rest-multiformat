using System.Collections.Generic;

namespace TestWcfService
{
	public sealed class DataImpl
	{
		private static readonly DataImpl instance = new DataImpl();
		public readonly List<CompanyInfo> CompaniesInfo;

		// Explicit static constructor to tell C# compiler
		// not to mark type as beforefieldinit
		static DataImpl()
		{
		}

		private DataImpl()
		{
			CompaniesInfo = new List<CompanyInfo>
			{
				new CompanyInfo
				{
					CompanyName = "CompanyOne",
					Description = "First company",
					Departments = new List<DepartmentInfo>
					{
						new DepartmentInfo
						{
							DepartmentName = "IT depart",
							Description = "it",
							Users = new List<UserInfo>
							{
								new UserInfo {Name = "Vasya", Login = "vasya@CompanyOne.com"},
								new UserInfo {Name = "Petya", Login = "petya@CompanyOne.com"}
							}
						},
						new DepartmentInfo
						{
							DepartmentName = "HR depart",
							Description = "hr",
							Users = new List<UserInfo>
							{
								new UserInfo {Name = "Vova", Login = "vova@CompanyOne.com"},
								new UserInfo {Name = "Vanya", Login = "vanya@CompanyOne.com"}
							}
						}
					}
				},
				new CompanyInfo
				{
					CompanyName = "CompanyTwo",
					Description = "Second company",
					Departments = new List<DepartmentInfo>
					{
						new DepartmentInfo
						{
							DepartmentName = "IT depart",
							Description = "it",
							Users = new List<UserInfo>
							{
								new UserInfo {Name = "Vasya", Login = "vasya@CompanyTwo.com"},
								new UserInfo {Name = "Petya", Login = "petya@CompanyTwo.com"}
							}
						},
						new DepartmentInfo
						{
							DepartmentName = "HR depart",
							Description = "hr",
							Users = new List<UserInfo>
							{
								new UserInfo {Name = "Vova", Login = "vova@CompanyTwo.com"},
								new UserInfo {Name = "Vanya", Login = "vanya@CompanyTwo.com"}
							}
						}
					}
				},
			};
		}

		public static DataImpl Instance
		{
			get
			{
				return instance;
			}
		}
	}
}