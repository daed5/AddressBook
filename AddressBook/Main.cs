
using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace AddressBook
{
	public class Application
	{
		static void Main (string[] args)
		{
			UIApplication.Main (args);
		}
	}

	// The name AppDelegate is referenced in the MainWindow.xib file.
	public partial class AppDelegate : UIApplicationDelegate
	{
		
		protected List<NavItem> _navItems = new List<NavItem> ();
		
		// This method is invoked when the application has loaded its UI and its ready to run
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			// If you have defined a view, add it here:
		    window.AddSubview (this.navController.View);
			
			
			window.MakeKeyAndVisible ();
			
			
			//---- create our list of items in the nav 

			Contact contact1 = new Contact("Chase McCarthy", "843 Main St.", "(318)748-7832", "chase@chase.com");
			Contact contact2 = new Contact("Micah Woods", "843 Main St.", "(318)748-7832", "chase@chase.com");                               
			
			this._navItems.Add (new NavItem (contact1, typeof(ContactView))); 
			this._navItems.Add (new NavItem (contact2, typeof(ContactView))); 
			
			//---- configure our datasource 
			
			this.tableView.TableView.DataSource = new TableViewDataSource (this._navItems); 
			this.tableView.TableView.Delegate = new NavTableDelegate (this.navController, this._navItems); 

			return true;
		}

		// This method is required in iPhoneOS 3.0
		public override void OnActivated (UIApplication application)
		{
		}
	}
}

