using System;

using AppKit;
using Foundation;
using static System.Net.Mime.MediaTypeNames;

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
        partial void Vigenere(NSObject sender)
        {
            string inputText = InputTextField.StringValue;
            string key = KeyTextField.StringValue;

            string encryptedText = VigenereCoder(inputText, key);
            OutputResult.StringValue = encryptedText;

        }

        private string VigenereCoder(string inputText, string key)
        {
 
            char[] buffer = inputText.ToCharArray();
            int textLength = buffer.Length;
            int keyLength = key.Length;
            key = key.ToUpper(); 

            for (int i = 0; i < textLength; i++)
            {
                char letter = buffer[i];

                if (char.IsLetter(letter))
                {
                    char offset = char.IsUpper(letter) ? 'A' : 'a';
                    int keyIndex = i % keyLength;
                    int shift = key[keyIndex] - 'A'; 
                    letter = (char)((letter + shift - offset) % 26 + offset);
                }

                buffer[i] = letter;
            }
            return new string(buffer);
        }



    }
}
