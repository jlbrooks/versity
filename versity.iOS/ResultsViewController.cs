using System;
using System.Collections.Generic;
using Foundation;
using UIKit;
using System.CodeDom.Compiler;

using versity.data.Models;

namespace versity.ios
{
	partial class ResultsViewController : UITableViewController
	{
		public ResultsViewController (IntPtr handle) : base (handle)
		{
			TableView.RegisterClassForCellReuse (typeof(UITableViewCell), resultsCellId);
			TableView.Source = new ResultsDataSource (this);
			Items = new List<Item> ();
		}

		public List<Item> Items { get; set; }
		static NSString resultsCellId = new NSString ("ItemCell");

		class ResultsDataSource : UITableViewSource
		{
			ResultsViewController controller;

			public ResultsDataSource (ResultsViewController controller) {
				this.controller = controller;
			}

			public override nint RowsInSection (UITableView tableview, nint section)
			{
				return controller.Items.Count;
			}

			public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
			{
				var cell = tableView.DequeueReusableCell (ResultsViewController.resultsCellId);

				int row = indexPath.Row;
				cell.TextLabel.Text = controller.Items [row].Name;
				return cell;
			}
		}
	}
}
