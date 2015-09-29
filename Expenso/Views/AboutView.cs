using System;

using Xamarin.Forms;

namespace Expenso.Views
{
	public class AboutView : ContentPage
	{
		public AboutView ()
		{
			Content = new StackLayout { 
				Children = {
					new Label { Text = "Hello ContentPage" }
				}
			};
		}
	}
}


