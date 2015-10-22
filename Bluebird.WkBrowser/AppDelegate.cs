using System;

using Foundation;
using AppKit;
using CoreGraphics;

namespace Bluebird.WkBrowser
{
	public partial class AppDelegate : NSApplicationDelegate
	{
		NSWindow m_window;

		public AppDelegate ()
		{
		}

		public override bool ApplicationShouldHandleReopen(NSApplication sender, bool hasVisibleWindows)
		{
			if (hasVisibleWindows == false)
				m_window.MakeKeyAndOrderFront (null);
			return true;
		}

		public override void DidFinishLaunching (NSNotification notification)
		{
			var menu = new NSMenu ();

			var menuItem = new NSMenuItem ();
			menu.AddItem (menuItem);

			var appMenu = new NSMenu ();
			var quitItem = new NSMenuItem ("Quit", "q", (s, e) => NSApplication.SharedApplication.Terminate (menu));
			appMenu.AddItem (quitItem);

			menuItem.Submenu = appMenu;
			NSApplication.SharedApplication.MainMenu = menu;

			m_window = new NSWindow (
				new CGRect (0, 0, 1024, 720),
				NSWindowStyle.Closable | NSWindowStyle.Miniaturizable | NSWindowStyle.Titled | NSWindowStyle.Resizable | NSWindowStyle.TexturedBackground,
				NSBackingStore.Buffered,
				false) {
				Title = "Bluebird WkBrowser",
				ReleasedWhenClosed = false,
				ContentMinSize = new CGSize (1024, 600),
				CollectionBehavior = NSWindowCollectionBehavior.FullScreenPrimary
			};
			m_window.Center ();
			m_window.MakeKeyAndOrderFront (null);

			var viewController = new ViewController ();
			m_window.ContentView = viewController.View;
			m_window.ContentViewController = viewController;
			viewController.View.Frame = m_window.ContentView.Bounds;
		}
	}
}