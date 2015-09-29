using System;
using Expenso.Models.Database;
using Expenso.Interfaces.Database;
using System.Threading.Tasks;

namespace Expenso.Services
{
	public class DataService:IDataService
	{
		private readonly ExpensoDatabase database;

		public DataService ()
		{
			this.database = new ExpensoDatabase ();
		}

		#region IDataService implementation

		public Task AddNewEntry (Entry entry)
		{
			return Task.Factory.StartNew(() =>
				{
					database.SaveItem<Entry>(entry);
				});
		}


		public Task<System.Collections.Generic.IEnumerable<Entry>> GetEntries ()
		{
			return Task.Factory.StartNew (() => database.GetItems<Entry> ());
		}
		#endregion

		
	}
}

