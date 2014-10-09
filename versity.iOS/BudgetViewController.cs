﻿
using System;
using System.Collections.Generic;
using System.Drawing;

using Foundation;
using UIKit;

using versity.data.Models;
using versity.mobile.core.External;

namespace versity.ios
{
	public partial class BudgetViewController : UIViewController
	{
		public BudgetViewController () : base ("BudgetViewController", null)
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

			var items = requester.GetItems (budget);

			ResultsViewController results = this.Storyboard.InstantiateViewController ("ResultsViewController") as ResultsViewController;

			if (results != null) {
				results.Items = items;
				this.NavigationController.PushViewController (results, true);
			}
		}

		private static VersityRequest requester;
	}
}
