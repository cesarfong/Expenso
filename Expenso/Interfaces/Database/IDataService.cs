using System;
using System.Threading.Tasks;
using Expenso.Models.Database;
using System.Collections.Generic;

namespace Expenso.Interfaces.Database
{
	public interface IDataService
	{

		Task AddNewEntry (Entry entry);
		Task <IEnumerable<Entry>> GetEntries();

	}


}

