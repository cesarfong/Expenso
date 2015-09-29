using System;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using Expenso.Helpers;

namespace Expenso.ViewModels
{
	public class EntriesViewModel:BaseViewModel
	{

		string monthId;
		string yearId;

		public EntriesViewModel (Page page,string @year, string @month) : base(page)
		{

			monthId = month.ToString();
			yearId = month.ToString ();

		}

		public ObservableCollection<Grouping<string, Entry>> EntriesGrouped { get; set; }

		public ObservableCollection<Entry> Entries {get;set;}

		protected override async System.Threading.Tasks.Task ExecuteLoadMoreCommand ()
		{
			throw  new NotImplementedException ();
		}
	}
}

	