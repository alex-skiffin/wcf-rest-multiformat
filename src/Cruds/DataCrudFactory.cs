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
					return new UserCrud();
				case "department":
					return new DepartmentCrud();
				case "company":
					return new CompanyCrud();
				default:
					break;
			}

			throw new ArgumentException("Некорректный запрос");
		}

		public abstract string Get(int id);
		public abstract string Post(int id, string json);
		public abstract string Put(int id, string json);
		public abstract string Delete(int id);
	}
}
