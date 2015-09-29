using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using Xamarin.Forms;
using Expenso.Interfaces.Database;
using System.Windows.Input;
using Expenso.Views;
using System.Threading.Tasks;

namespace Expenso.ViewModels
{
	public abstract class BaseViewModel:INotifyPropertyChanged
	{

		internal readonly IDataService dataService;
		internal readonly Page page;
		internal readonly Random random;

		public BaseViewModel (Page page)
		{
			this.page = page;
			dataService = DependencyService.Get<IDataService>();
			random = new Random();

		}	


		bool isBusy = false;
		public bool IsBusy
		{ 
			get { return isBusy; }
			set { 
				SetProperty(ref isBusy, value);
				if (IsBusyChanged != null)
					IsBusyChanged (isBusy);
			}
		}

		bool canLoadMore = false;

		public bool CanLoadMore
		{
			get { return canLoadMore; }
			set { SetProperty(ref canLoadMore, value); }
		}

		public Action<bool> IsBusyChanged { get; set; }

		protected void SetProperty<T>(
			ref T backingStore, T value,
			[CallerMemberName]string propertyName = "",
			Action onChanged = null) 
		{


			if (EqualityComparer<T>.Default.Equals(backingStore, value)) 
				return;

			backingStore = value;

			if (onChanged != null) 
				onChanged();

			OnPropertyChanged(propertyName);
		}


		Command loadMoreCommand;

		public ICommand LoadMoreCommand
		{
			get { 
				return loadMoreCommand ?? 
					(
						loadMoreCommand = new Command(async () => await ExecuteLoadMoreCommand())
					);
			}
		}

		protected virtual async Task ExecuteLoadMoreCommand()
		{
			
		}

		public Action<int> FinishedFirstLoad { get; set; }


		public ICommand GoToAboutCommand
		{

			get {
				return new Command(async () => 
					{
						if(IsBusy)
							return;
						await page.Navigation.PushAsync(new AboutView());
					});
			}

		}

		#region INotifyPropertyChanged implementation
		public event PropertyChangedEventHandler PropertyChanged;
		#endregion

		public void OnPropertyChanged(string propertyName)
		{
			if (PropertyChanged == null)
				return;

			PropertyChanged (this, new PropertyChangedEventArgs (propertyName));
		}	
	}
}

