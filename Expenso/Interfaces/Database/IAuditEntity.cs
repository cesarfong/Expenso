using System;

namespace Expenso.Interfaces.Database
{
	public interface IAuditEntity
	{
		 string userCreation { get; set;}

		 DateTime userCreationDateTime { get; set;}

		 string userModified { get; set;}

		 DateTime userModifiedDateTime { get; set;}

	}
}

