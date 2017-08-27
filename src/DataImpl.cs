using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using TestWcfService.Models;

namespace TestWcfService
{
	public sealed class DataImpl
	{
		private static readonly DataImpl instance = new DataImpl();
		public static readonly DataTable _usersDataTable = new DataTable();
		public static readonly DataTable _departmentsDataTable = new DataTable();
		public static readonly DataTable _companiesDataTable = new DataTable();
		public readonly DataAdapter DataAdapter;

		static DataImpl()
		{
		}

		private DataImpl()
		{
			DataColumn idColumn = new DataColumn("Id", typeof(Int32));
			idColumn.AutoIncrement = true;
			idColumn.AutoIncrementSeed = 1;
			idColumn.AutoIncrementStep = 1;
			idColumn.ReadOnly = true;

			_usersDataTable.Columns.Add(idColumn);
			_usersDataTable.Columns.Add("DepartmentId", typeof(Int32));
			_usersDataTable.Columns.Add("Name", typeof(String));
			_usersDataTable.Columns.Add("Login", typeof(String));
			_usersDataTable.Columns.Add("Birthday", typeof(DateTime));

			_departmentsDataTable.Columns.Add(idColumn);
			_departmentsDataTable.Columns.Add("CompanyId", typeof(Int32));
			_departmentsDataTable.Columns.Add("DepartmentName", typeof(String));
			_departmentsDataTable.Columns.Add("Description", typeof(String));

			_companiesDataTable.Columns.Add(idColumn);
			_companiesDataTable.Columns.Add("CompanyName", typeof(String));
			_companiesDataTable.Columns.Add("Description", typeof(String));

			_companiesDataTable.Rows.Add(new CompanyInfo
			{
				CompanyName = "CompanyOne",
				Description = "First company"
			});


			_companiesDataTable.Rows.Add(new CompanyInfo
			{
				CompanyName = "CompanyTwo",
				Description = "Second company"
			});

			_departmentsDataTable.Rows.Add(
						new DepartmentInfo
						{
							CompanyId = 0,
							DepartmentName = "IT depart",
							Description = "it"
						});
			_departmentsDataTable.Rows.Add(
						new DepartmentInfo
						{
							CompanyId = 1,
							DepartmentName = "HR depart",
							Description = "hr",
						});

			_usersDataTable.Rows.Add(
				new UserInfo
				{
					DepartmentId = 0,
					Name = "Vasya",
					Login = "vasya@CompanyOne.com"
				});

			_usersDataTable.Rows.Add(
				new UserInfo
				{
					DepartmentId = 1,
					Name = "Petya",
					Login = "petya@CompanyTwo.com"
				});
		}

		public List<UserInfo> GetAllUsersByCompanyId(int companyId)
		{
			throw new NotImplementedException();
		}
		public List<UserInfo> GetAllUsersByDepartmentId(int departmentId)
		{
			throw new NotImplementedException();
		}
		public List<DepartmentInfo> GetAllDepartmentByCompanyId(int companyId)
		{
			throw new NotImplementedException();
		}
		public List<CompanyInfo> GetAllCompanies()
		{
			throw new NotImplementedException();
		}

		public UserInfo GetUser(int userId)
		{
			throw new NotImplementedException();
		}
		public DepartmentInfo GetDepartment(int departmentId)
		{
			throw new NotImplementedException();
		}
		public CompanyInfo GetCompany(int companyId)
		{
			throw new NotImplementedException();
		}

		public void AddUser(UserInfo user)
		{
			_usersDataTable.Rows.Add(
				new UserInfo
				{
					DepartmentId = user.DepartmentId,
					Name = user.Name,
					Login = user.Login,
					Birthday = user.Birthday
				});
		}
		public void AddDepartment(DepartmentInfo department)
		{
			_departmentsDataTable.Rows.Add(
						new DepartmentInfo
						{
							CompanyId = department.CompanyId,
							DepartmentName = department.DepartmentName,
							Description = department.Description
						});
		}
		public void AddCompany(CompanyInfo company)
		{
			_companiesDataTable.Rows.Add(new CompanyInfo
			{
				CompanyName = company.CompanyName,
				Description = company.Description
			});
		}

		public void ChangeUser(UserInfo user)
		{
			_usersDataTable.Rows[user.Id]["DepartmentId"] = user.DepartmentId;
			_usersDataTable.Rows[user.Id]["Name"] = user.Name;
			_usersDataTable.Rows[user.Id]["Login"] = user.Login;
			_usersDataTable.Rows[user.Id]["Birthday"] = user.Birthday;
		}
		public void ChangeDepartment(DepartmentInfo department)
		{
			_departmentsDataTable.Rows[department.Id]["CompanyId"] = department.CompanyId;
			_departmentsDataTable.Rows[department.Id]["Name"] = department.DepartmentName;
			_departmentsDataTable.Rows[department.Id]["Login"] = department.Description;
		}
		public void ChangeCompany(CompanyInfo company)
		{
			_companiesDataTable.Rows[company.Id]["CompanyName"] = company.CompanyName;
			_companiesDataTable.Rows[company.Id]["Description"] = company.Description;
		}

		public void DeleteUser(int userId)
		{
			_usersDataTable.Rows[userId].Delete();
		}
		public void DeleteDepartment(int departmentId)
		{
			_departmentsDataTable.Rows[departmentId].Delete();
		}
		public void DeleteCompany(int companyId)
		{
			_companiesDataTable.Rows[companyId].Delete();
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