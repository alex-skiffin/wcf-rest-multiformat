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
		[WebInvoke(Method = "GET", UriTemplate = "users?format={format}")]
		[ServiceKnownType(typeof(List<UserInfo>))]
		[ServiceKnownType(typeof(MemoryStream))]
		Stream GetUsers(string format);

		[OperationContract]
		[WebInvoke(Method = "GET", UriTemplate = "departments?format={format}")]
		[ServiceKnownType(typeof(List<DepartmentInfo>))]
		[ServiceKnownType(typeof(MemoryStream))]
		Stream GetDepartments(string format);

		[OperationContract]
		[WebInvoke(Method = "GET", UriTemplate = "companies?format={format}")]
		[ServiceKnownType(typeof(List<CompanyInfo>))]
		[ServiceKnownType(typeof(MemoryStream))]
		Stream GetCompanies(string format);

		[OperationContract]
		[WebInvoke(Method = "GET", UriTemplate = "user?format={format}&username={username}")]
		[ServiceKnownType(typeof(UserInfo))]
		[ServiceKnownType(typeof(MemoryStream))]
		Stream GetUser(string username, string format);

		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "user")]
		[ServiceKnownType(typeof(UserInfo))]
		[ServiceKnownType(typeof(MemoryStream))]
		Stream AddUser(UserInfo user);

		[OperationContract]
		[WebInvoke(Method = "PUT", RequestFormat = WebMessageFormat.Json, UriTemplate = "user")]
		[ServiceKnownType(typeof(UserInfo))]
		[ServiceKnownType(typeof(MemoryStream))]
		Stream ChangeUser(UserInfo user);

		[OperationContract]
		[WebInvoke(Method = "DELETE", UriTemplate = "user?username={username}")]
		[ServiceKnownType(typeof(UserInfo))]
		[ServiceKnownType(typeof(MemoryStream))]
		Stream DeleteUser(string username);
	}
}
