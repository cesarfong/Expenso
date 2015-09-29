﻿using Expenso.Interfaces;
using SQLite;

namespace Expenso.Models.Database
{
	public class BusinessEntityBase:AuditEntityBase,IBusinessEntity
	{
		public BusinessEntityBase ()
		{
		}

		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }
	}
}

