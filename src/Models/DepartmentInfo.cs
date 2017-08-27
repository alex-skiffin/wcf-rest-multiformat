using System.Collections.Generic;
using System.Runtime.Serialization;

namespace TestWcfService.Models
{
	[DataContract]
	public class DepartmentInfo
	{
		[DataMember]
		public int Id { get; set; }

		[DataMember]
		public int CompanyId { get; set; }

		[DataMember]
		public string DepartmentName { get; set; }

		[DataMember]
		public string Description { get; set; }
	}
}