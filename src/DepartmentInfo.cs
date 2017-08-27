using System.Collections.Generic;
using System.Runtime.Serialization;

namespace TestWcfService
{
	[DataContract]
	public class DepartmentInfo
	{
		[DataMember]
		public int Id { get; set; }

		[DataMember]
		public string DepartmentName { get; set; }

		[DataMember]
		public string Description { get; set; }

		[DataMember]
		public List<UserInfo> Users{ get; set; }
	}
}