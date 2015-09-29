using System;

using SQLite;

namespace Expenso.Models.Database
{
	[Table("Entry")]
	public class Entry:BusinessEntityBase	
	{	
		
		public DateTime Date {
			get;
			set;
		}


		public string Name { get; set; }

		[Indexed]
		public string Category { get; set; }


		public string SubCategory { get; set; }

		[Indexed]
		public string TypeEntry { get; set;}

		public double Amount {
			get;
			set;
		}		

		public string Currency{ get; set;}


	}
}

