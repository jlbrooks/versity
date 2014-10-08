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

		}

		public List<Item> Items { get; set; }
	}
}
