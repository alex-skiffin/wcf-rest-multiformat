using System.Collections.Generic;
using System.Runtime.Serialization;

namespace TestWcfService.Models
{
	[DataContract]
	public class CompanyInfo
	{
		[DataMember]
		public int Id { get; set; }

		[DataMember]
		public string CompanyName { get; set; }

		[DataMember]
		public string Description { get; set; }
	}
}