using System;

namespace TestWcfService.Cruds
{
	public abstract class DataCrudFactory
	{
		public static DataCrudFactory Create(string item)
		{
			switch(item)
			{
				case "user":
					break;
				case "department":
					break;
				case "company":
					break;
				default:
					break;
			}

			throw new ArgumentException("Некорректный запрос");
		}

		public abstract string Get(string id);
		public abstract string Post(string id, string json);
		public abstract string Put(string id, string json);
		public abstract string Delete(string id);
	}
}
