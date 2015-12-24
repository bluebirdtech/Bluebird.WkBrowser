using Foundation;
using System;
using AppKit;
using WebKit;
using CoreGraphics;

namespace Bluebird.WkBrowser
{
	public class ViewController : NSViewController
	{
		WKWebView m_webView;

		public ViewController()
		{
			var split = new NSSplitView (new CGRect (0.0f, 0.0f, 400.0f, 400.0f)) { DividerStyle = NSSplitViewDividerStyle.Thin };
			var text = new NSTextField(new CGRect(0.0f, 0.0f, 64.0f, 16.0f));
			split.AddSubview (text);
			var button = new NSButton (new CGRect (0.0f, 0.0f, 64.0f, 16.0f)) {
				Title = "Go",
				StringValue = "https://www.google.com/" // TODO: This doesn't get set for some reason
			};
			button.Activated += (object sender, EventArgs e) => m_webView.LoadRequest (new NSUrlRequest (new NSUrl (text.StringValue)));
			split.AddSubview (button);

			var config = new WKWebViewConfiguration ();
			config.Preferences.SetValueForKey(NSNumber.FromBoolean(true), new NSString("developerExtrasEnabled"));
			m_webView = new WKWebView(new CGRect(0.0f, 0.0f, 400.0f, 400.0f), config);
			split.AddSubview (m_webView);
			View = split;
		}
	}
}

