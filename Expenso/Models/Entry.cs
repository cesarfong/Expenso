using System;

using SQLite;

namespace Expenso.Models
{
	[Table("Entry")]
	public class Entry
	{
		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }

		public DateTime Date {
			get;
			set;
		}

		[MaxLength(250)]
		public string Name { get; set; }

		[MaxLength(250)]
		public string Category { get; set; }

		[MaxLength(250)]
		public string SubCategory { get; set; }

		[MaxLength(1)]
		public string TypeEntry { get; set;}


		public double Amount {
			get;
			set;
		}

		public string Currency{ get; set;}

	}
}

