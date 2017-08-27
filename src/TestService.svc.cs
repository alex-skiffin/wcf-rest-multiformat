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
			return ToStream(worker.Get(id));
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
			return ToStream(worker.Delete(id));
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
	}
}
