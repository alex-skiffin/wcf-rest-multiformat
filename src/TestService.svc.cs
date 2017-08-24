using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.ServiceModel.Web;
using System.Text;

namespace TestWcfService
{
	public class TestService : ITestService
	{
		public Stream GetUsers(string format)
		{
			if (format == null) format = "json";
			switch (format.ToLower())
			{
				case "json":
					return GetUsersJson();

				case "csv":
					return GetUsersCsv();

				default:
					return BadRequest("Invalid content format: " + format);
			}
		}

		public Stream GetDepartments(string format)
		{
			throw new NotImplementedException();
		}

		public Stream GetCompanies(string format)
		{
			throw new NotImplementedException();
		}

		public Stream GetUser(string username, string format)
		{
			throw new NotImplementedException();
		}

		public Stream AddUser(UserInfo user)
		{
			//DataImpl.Instance.CompaniesInfo.Add(user);
			return ToStream("user \"{user.Name}\" added");
		}

		public Stream ChangeUser(UserInfo user)
		{
			//var userIndex = DataImpl.Instance.UsersInfo.FindIndex(x => x.Name == user.Name);

			//if (userIndex == -1)
			//	return ToStream($"user \"{user.Name}\" does not exist!");

			//DataImpl.Instance.UsersInfo[userIndex] = user;

			return ToStream("user changed");
		}

		public Stream DeleteUser(string username)
		{
			//var deletingUser = DataImpl.Instance.UsersInfo.FirstOrDefault(x=>x.Name == username);

			//if (deletingUser == null)
			//	return ToStream($"user \"{username}\" does not exist!");

			//DataImpl.Instance.UsersInfo.Remove(deletingUser);
			return ToStream("user deleted");
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

		private Stream GetUsersJson()
		{
			var context = WebOperationContext.Current;
			if (context == null) throw new InvalidOperationException("context is null!");

			var serializer = new DataContractJsonSerializer(DataImpl.Instance.CompaniesInfo.GetType());
			var stream = new MemoryStream();
			serializer.WriteObject(stream, DataImpl.Instance.CompaniesInfo);
			stream.Seek(0, SeekOrigin.Begin);
			context.OutgoingResponse.ContentType = "application/json";
			return stream;
		}

		private Stream GetUsersCsv()
		{
			var context = WebOperationContext.Current;
			if (context == null) throw new InvalidOperationException("context is null!");

			var output = new MemoryStream();

			var text = new StreamWriter(output);
			text.WriteLine("Name,Login");
			//foreach (var user in DataImpl.Instance.UsersInfo)
			//{
			//	text.WriteLine("\"{0}\",\"{1}\"", user.Name, user.DepartmentName);
			//}
			text.Flush();

			context.OutgoingResponse.ContentType = "text/csv";
			context.OutgoingResponse.Headers.Add("Content-Disposition", "attachment; filename=users.csv");

			output.Seek(0, SeekOrigin.Begin);
			return output;
		}

	}
}
