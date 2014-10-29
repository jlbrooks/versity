using System;
using System.Collections.Generic;
using System.Drawing;
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
			Restaurants = new List<Restaurant> ();
		}

		public List<Restaurant> Restaurants { get; set; }
		static NSString resultsCellId = new NSString ("ItemCell");

		class ResultsDataSource : UITableViewSource
		{
			ResultsViewController controller;

			public ResultsDataSource (ResultsViewController c)
			{
				this.controller = c;
			}
//
//			protected override UITableViewCell GetOrCreateCellFor(UITableView tableView, NSIndexPath indexPath, object item)
//			{
//				var cell = tableView.DequeueReusableCell (ResultsViewController.resultsCellId);
//			}


			public override nint RowsInSection (UITableView tableview, nint section)
			{
				return controller.Restaurants.Count * 4;
			}

			public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
			{
				int row = indexPath.Row;
				var restaurant = controller.Restaurants [row / 4];

				var index = row % 4;

				if (index == 0) {
					var cell = tableView.DequeueReusableCell (ResultsViewController.resultsCellId) as RestaurantCell;
					if (cell == null) {
						cell = new RestaurantCell (ResultsViewController.resultsCellId);
					}
					cell.UpdateCell (restaurant.Name, "5 items");
					return cell;
				} else {
					var cell = tableView.DequeueReusableCell (ResultsViewController.resultsCellId) as ItemCell;
					if (cell == null) {
						cell = new ItemCell (ResultsViewController.resultsCellId);
					}
					var item = restaurant.Menus [0].Items [index];
					cell.UpdateCell (item.Name, item.Cost);
					return cell;
				}
			}
		}
	}

	public class RestaurantCell : UITableViewCell {
		UILabel nameLabel, subTitleLabel;

		public RestaurantCell (NSString cellId) : base (UITableViewCellStyle.Default, cellId)
		{
			SelectionStyle = UITableViewCellSelectionStyle.Gray;
			ContentView.BackgroundColor = UIColor.Red;

			nameLabel = new UILabel () {
				Font = UIFont.FromName("Marker Felt", 18f),
				TextColor = UIColor.Black
			};

			subTitleLabel = new UILabel () {
				Font = UIFont.FromName ("AmericanTypewriter", 12f),
				TextColor = UIColor.Gray
			};

			ContentView.AddSubviews (new UIView[] { nameLabel, subTitleLabel });
		}

		public void UpdateCell (string name, string subtitle)
		{
			nameLabel.Text = name;
			subTitleLabel.Text = subtitle;
		}

		public override void LayoutSubviews()
		{
			base.LayoutSubviews ();

			nameLabel.Frame = new RectangleF (5, 4, (float)ContentView.Bounds.Width - 63, 25);
			subTitleLabel.Frame = new RectangleF (100, 18, 100, 200);
		}
	}

	public class ItemCell : UITableViewCell {
		UILabel nameLabel, priceLabel;

		public ItemCell (NSString cellId) : base (UITableViewCellStyle.Default, cellId)
		{
			SelectionStyle = UITableViewCellSelectionStyle.Gray;
			ContentView.BackgroundColor = UIColor.Blue;

			nameLabel = new UILabel () {
				Font = UIFont.FromName("Cochin-BoldItalic", 18f),
				TextColor = UIColor.Yellow
			};

			priceLabel = new UILabel () {
				Font = UIFont.FromName ("AmericanTypewriter", 12f),
				TextColor = UIColor.Gray
			};

			ContentView.AddSubviews (new UIView[] { nameLabel, priceLabel });
		}

		public void UpdateCell (string name, decimal price)
		{
			nameLabel.Text = name;
			priceLabel.Text = "$" + price;
		}

		public override void LayoutSubviews()
		{
			base.LayoutSubviews ();

			nameLabel.Frame = new RectangleF (5, 4, (float)ContentView.Bounds.Width - 63, 25);
			priceLabel.Frame = new RectangleF (100, 18, 100, 200);
		}
	}
}
