using System;
using Expenso.Interfaces.Database;

namespace Expenso.Models.Database
{
	public class AuditEntityBase:IAuditEntity
	{
		public AuditEntityBase ()
		{
		}

		public string userCreation { get; set;}

		public DateTime userCreationDateTime { get; set;}

		public string userModified { get; set;}

		public DateTime userModifiedDateTime { get; set;}

	}
}

