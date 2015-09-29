using System;
using SQLite;
using System.IO;
using System.Collections.Generic;
using Expenso.Interfaces;


namespace Expenso.Models.Database
{
	public class ExpensoDatabase
	{
		const string location = "expenso.db3";
		public static string Root {get;set;}
		private readonly SQLiteConnection Connection;

		public ExpensoDatabase ()
		{
			Connection = new SQLiteConnection(Path.Combine(Root,location));
			Connection.CreateTable<Entry>();
		}

		/// <summary>
		/// Gets all items of type T
		/// </summary>
		/// <typeparam name="T">Type of item to get</typeparam>
		/// <returns></returns>
		public IEnumerable<T> GetItems<T>() where T : IBusinessEntity, new()
		{

			return (from i in Connection.Table<T>()
				select i);

		}

		/// <summary>
		/// Save and update item of type T. If ID is set then will update the item, eelse creates new and returns the id.
		/// </summary>
		/// <typeparam name="T">Type of entity</typeparam>
		/// <param name="item">Item to save or update</param>
		/// <returns>ID of item</returns>
		public int SaveItem<T>(T item) where T : IBusinessEntity
		{

			if (item.Id != 0)
			{
				Connection.Update(item);
				return item.Id;
			}

			return Connection.Insert(item);

		}

		/// <summary>
		/// Saves a list of items calling SaveItems in 1 transaction
		/// </summary>
		/// <typeparam name="T">Type of entity to save</typeparam>
		/// <param name="items">List of items</param>
		public void SaveItems<T>(IEnumerable<T> items) where T : IBusinessEntity
		{

			Connection.BeginTransaction();

			foreach (T item in items)
			{
				SaveItem(item);
			}

			Connection.Commit();

		}

		/// <summary>
		/// Deletes a specific item with id specified
		/// </summary>
		/// <typeparam name="T">Type of item to delete</typeparam>																				
		/// <param name="item"></param>
		/// <returns></returns>
		public int DeleteItem<T>(T item) where T : IBusinessEntity, new()
		{

			return Connection.Delete(item);

		}
			
			
		/// <summary>
		/// Deletes a specific item with id specified
		/// </summary>
		/// <typeparam name="T">Type of item to delete</typeparam>
		/// <param name="id">Item to delete</param>
		/// <returns></returns>
		public int DeleteItem<T>(int id) where T : IBusinessEntity, new()
		{

			return this.Connection.Delete<T>(id);

		}

		/// <summary>
		/// Clear an entire table of specific type
		/// </summary>
		/// <typeparam name="T">Type to clear table</typeparam>
		public void ClearTable<T>() where T : IBusinessEntity, new()
		{

			Connection.Execute(string.Format("delete from \"{0}\"", typeof(T).Name));

		}	
	}
}

