// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace Encryptomat
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		AppKit.NSTextField InputTextField { get; set; }

		[Outlet]
		AppKit.NSTextField KeyTextField { get; set; }

		[Outlet]
		AppKit.NSTextFieldCell OutputResult { get; set; }

		[Action ("AES:")]
		partial void AES (Foundation.NSObject sender);

		[Action ("Cezar:")]
		partial void Cezar (Foundation.NSObject sender);

		[Action ("Copy:")]
		partial void Copy (Foundation.NSObject sender);

		[Action ("Vigenere:")]
		partial void Vigenere (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (OutputResult != null) {
				OutputResult.Dispose ();
				OutputResult = null;
			}

			if (InputTextField != null) {
				InputTextField.Dispose ();
				InputTextField = null;
			}

			if (KeyTextField != null) {
				KeyTextField.Dispose ();
				KeyTextField = null;
			}
		}
	}
}
