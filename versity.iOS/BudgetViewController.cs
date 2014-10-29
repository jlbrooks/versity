
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime;

using Foundation;
using UIKit;

using versity.data.Models;
using Newtonsoft.Json;

namespace versity.ios
{
	public partial class BudgetViewController : UIViewController
	{
		public BudgetViewController (IntPtr handle) : base (handle)
		{
			requester = new VersityRequest (); 
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();

			// Release any cached data, images, etc that aren't in use.
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			SearchButton.TouchUpInside += SearchBudgetEvent;
		}

		private void SearchBudgetEvent (object sender, EventArgs e)
		{
			var text = BudgetText.Text;
			var budget = Decimal.Parse (text);

			//Dismiss the keyboard
			BudgetText.ResignFirstResponder ();

			var restaurants = requester.GetRestaurantsBudget (budget);

			ResultsViewController results = this.Storyboard.InstantiateViewController ("ResultsViewController") as ResultsViewController;

			if (results != null) {
				results.Restaurants = restaurants;
				this.NavigationController.PushViewController (results, true);
			}
		}

		private static VersityRequest requester;
	}
}

