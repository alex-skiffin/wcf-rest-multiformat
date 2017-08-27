using System;
using System.Runtime.Serialization;

namespace TestWcfService.Models
{
	[DataContract]
	public class UserInfo
	{
		[DataMember]
		public int Id { get; set; }

		[DataMember]
		public int DepartmentId { get; set; }

		[DataMember]
		public string Name { get; set; }

		[DataMember]
		public string Login { get; set; }

		[DataMember]
		public DateTime Birthday { get; set; }
	}
}