using System;
using System.Runtime.Serialization;

namespace TestWcfService
{
	[DataContract]
	public class UserInfo
	{
		[DataMember]
		public string Name { get; set; }

		[DataMember]
		public string Login { get; set; }

		[DataMember]
		public DateTime Birthday { get; set; }

		[DataMember]
		public int TimeStamp { get; set; }
	}
}