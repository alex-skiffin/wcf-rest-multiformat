using System;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;
using System.ServiceModel.Web;
using System.Text;

namespace TestWcfService
{
	public class TestService : ITestService
	{
		public Stream Get(string item, string id, string format)
		{
			throw new NotImplementedException();
		}

		public Stream Post(string item, string id, string format, Stream streamdata)
		{
			StreamReader reader = new StreamReader(streamdata);
			string res = reader.ReadToEnd();
			reader.Close();
			reader.Dispose();
			return ToStream("Received: " + res);
		}

		public Stream Put(string item, string id, string format, Stream streamdata)
		{
			StreamReader reader = new StreamReader(streamdata);
			string res = reader.ReadToEnd();
			reader.Close();
			reader.Dispose();
			return ToStream("Received: " + res);
		}

		public Stream Delete(string item, string id, string format)
		{
			throw new NotImplementedException();
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
