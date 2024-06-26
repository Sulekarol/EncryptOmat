using System;
using AppKit;
using Foundation;

namespace Encryptomat
{
	[Register ("AppDelegate")]
	public class AppDelegate : NSApplicationDelegate
	{
		public AppDelegate ()
		{
		}

		public override void DidFinishLaunching (NSNotification notification)
		{
            ShowWelcomeMessage();


        }

		public override void WillTerminate (NSNotification notification)
		{
            // Insert code here to tear down your application
		}

        private void ShowWelcomeMessage()
        {
            var alert = new NSAlert()
            {
                AlertStyle = NSAlertStyle.Informational,
                MessageText = "Witamy w naszej aplikacji!",
                InformativeText = "To jest informacja wyświetlana przy starcie aplikacji."
            };
            alert.AddButton("OK");
            alert.RunModal();
        }

    }
}

