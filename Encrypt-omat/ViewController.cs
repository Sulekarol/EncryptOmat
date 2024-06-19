using System;

using AppKit;
using Foundation;

namespace Encryptomat
{
	public partial class ViewController : NSViewController
	{
       
        public ViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			// Do any additional setup after loading the view.
		}

		public override NSObject RepresentedObject {
			get {
				return base.RepresentedObject;
			}
			set {
				base.RepresentedObject = value;
				// Update the view, if already loaded.
			}
		}

        
        partial void Cezar(NSObject sender)
        {
            string inputText = InputTextField.StringValue;
            int key = KeyTextField.IntValue;

            if (!string.IsNullOrEmpty(inputText) && key != 0)
            {
                string encryptedText = CaesarCipher(inputText, key);
                OutputResult.StringValue = $"{encryptedText}";
            }
            else
            {
                OutputResult.StringValue = "Proszę wprowadzić prawidłowy klucz.";
            }
        }

        private string CaesarCipher(string text, int shift)
        {
            char[] buffer = text.ToCharArray();

            for (int i = 0; i < buffer.Length; i++)
            {
                char letter = buffer[i];

                if (char.IsLetter(letter))
                {
                    char offset = char.IsUpper(letter) ? 'A' : 'a';
                    letter = (char)((letter + shift - offset + 26) % 26 + offset);
                }

                buffer[i] = letter;
            }

            return new string(buffer);
        }

    }
}
