using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.ServiceModel.Web;
using System.Text;
using TestWcfService.Cruds;

namespace TestWcfService
{
	public class TestService : ITestService
	{
		public Stream Get(string item, string id)
		{
			var worker = DataCrudFactory.Create(item);
			return ToStream(worker.Get(int.Parse(id)));
		}

		public Stream Post(string item, string id, Stream streamdata)
		{
			StreamReader reader = new StreamReader(streamdata);
			string res = reader.ReadToEnd();
			reader.Close();
			reader.Dispose();
			return ToStream("Received: " + res);
		}

		public Stream Put(string item, string id, Stream streamdata)
		{
			StreamReader reader = new StreamReader(streamdata);
			string res = reader.ReadToEnd();
			reader.Close();
			reader.Dispose();
			return ToStream("Received: " + res);
		}

		public Stream Delete(string item, string id)
		{
			var worker = DataCrudFactory.Create(item);
			return ToStream(worker.Delete(int.Parse(id)));
		}

		private static Stream ToStream(string data)
		{
			return new MemoryStream(Encoding.UTF8.GetBytes(data));
		}

		private static Stream BadRequest(string data)
		{
			var context = WebOperationContext.Current;
			if (context == null) throw new InvalidOperationException("context is null!");
			var response = context.OutgoingResponse;
			response.StatusCode = HttpStatusCode.BadRequest;
			response.StatusDescription = "Bad Request";
			response.ContentType = "text/plain; charset=utf-8";
			return ToStream(data);
		}

		public Stream GetCompanies()
		{
			var companies = DataImpl.Instance.GetAllCompanies();
			string output = JsonConvert.SerializeObject(companies);
			return ToStream(output);
		}

		public Stream GetDepartments(string companyId)
		{
			var departments = DataImpl.Instance.GetAllDepartmentByCompanyId(int.Parse(companyId));
			string output = JsonConvert.SerializeObject(departments);
			return ToStream(output);
		}

		public Stream GetCompanyUsers(string companyId)
		{
			var users = DataImpl.Instance.GetAllUsersByCompanyId(int.Parse(companyId));
			string output = JsonConvert.SerializeObject(users);
			return ToStream(output);
		}

		public Stream GetDepartmentUsers(string departmentId)
		{
			var users = DataImpl.Instance.GetAllUsersByDepartmentId(int.Parse(departmentId));
			string output = JsonConvert.SerializeObject(users);
			return ToStream(output);
		}
	}
}
