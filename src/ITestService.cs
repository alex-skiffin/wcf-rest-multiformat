using System.Collections.Generic;
using System.IO;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace TestWcfService
{
	[ServiceContract]
	public interface ITestService
	{
		[OperationContract]
		[WebInvoke(Method = "GET", UriTemplate = "{item}/{id=0}/{format=json}")]
		[ServiceKnownType(typeof(MemoryStream))]
		Stream Get(string item, string id, string format);

		[OperationContract]
		[WebInvoke(Method = "POST",
			ResponseFormat = WebMessageFormat.Json,
			RequestFormat = WebMessageFormat.Json,
			BodyStyle = WebMessageBodyStyle.WrappedRequest,
			UriTemplate = "{item}/{id=0}/{format=json}")]
		[ServiceKnownType(typeof(MemoryStream))]
		Stream Post(string item, string id, string format, Stream json);

		[OperationContract]
		[WebInvoke(Method = "PUT",
			ResponseFormat = WebMessageFormat.Json,
			RequestFormat = WebMessageFormat.Json,
			BodyStyle = WebMessageBodyStyle.WrappedRequest,
			UriTemplate = "{item}/{id=0}/{format=json}")]
		[ServiceKnownType(typeof(MemoryStream))]
		Stream Put(string item, string id, string format, Stream json);

		[OperationContract]
		[WebInvoke(Method = "DELETE", UriTemplate = "{item}/{id=0}/{format=json}")]
		[ServiceKnownType(typeof(MemoryStream))]
		Stream Delete(string item, string id, string format);
	}
}
