using System.IO;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace TestWcfService
{
	[ServiceContract]
	public interface ITestService
	{
		[OperationContract]
		[WebInvoke(Method = "GET", UriTemplate = "companies")]
		[ServiceKnownType(typeof(MemoryStream))]
		Stream GetCompanies();

		[OperationContract]
		[WebInvoke(Method = "GET", UriTemplate = "departments/{companyId=0}")]
		[ServiceKnownType(typeof(MemoryStream))]
		Stream GetDepartments(string companyId);

		[OperationContract]
		[WebInvoke(Method = "GET", UriTemplate = "users/companyId/{companyId=0}")]
		[ServiceKnownType(typeof(MemoryStream))]
		Stream GetCompanyUsers(string companyId);

		[OperationContract]
		[WebInvoke(Method = "GET", UriTemplate = "users/departmentId/{departmentId=0}")]
		[ServiceKnownType(typeof(MemoryStream))]
		Stream GetDepartmentUsers(string departmentId);

		[OperationContract]
		[WebInvoke(Method = "GET", UriTemplate = "{item}/{id=0}")]
		[ServiceKnownType(typeof(MemoryStream))]
		Stream Get(string item, string id);

		[OperationContract]
		[WebInvoke(Method = "POST",
			ResponseFormat = WebMessageFormat.Json,
			RequestFormat = WebMessageFormat.Json,
			BodyStyle = WebMessageBodyStyle.WrappedRequest,
			UriTemplate = "{item}/{id=0}")]
		[ServiceKnownType(typeof(MemoryStream))]
		Stream Post(string item, string id, Stream json);

		[OperationContract]
		[WebInvoke(Method = "PUT",
			ResponseFormat = WebMessageFormat.Json,
			RequestFormat = WebMessageFormat.Json,
			BodyStyle = WebMessageBodyStyle.WrappedRequest,
			UriTemplate = "{item}/{id=0}")]
		[ServiceKnownType(typeof(MemoryStream))]
		Stream Put(string item, string id, Stream json);

		[OperationContract]
		[WebInvoke(Method = "DELETE", UriTemplate = "{item}/{id=0}")]
		[ServiceKnownType(typeof(MemoryStream))]
		Stream Delete(string item, string id);
	}
}
