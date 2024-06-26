using System;



using System.IO;
using System.Security.Cryptography;
using System.Text;
using AppKit;
using CoreServices;
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

            ModeSegmentedControl.SegmentCount = 2;
            ModeSegmentedControl.SetLabel("Encryption" ,0);
            ModeSegmentedControl.SetLabel("Decryption" ,1);
           

            ModeSegmentedControl.Activated += (sender, e) =>
            {
                HandleSegmentChange();
            };
        }

        public override NSObject RepresentedObject
        {
            get
            {
                return base.RepresentedObject;
            }
            set
            {
                base.RepresentedObject = value;
                // Update the view, if already loaded.
            }
        }




        void HandleSegmentChange()
        {
            var selectedIndex = ModeSegmentedControl.SelectedSegment;          
            switch (selectedIndex)
            {
                case 0:
                    
                    
                    break;
                case 1:
                    
                    break;
               
            }
        }


        partial void Cezar(NSObject sender)
        {
            var selectedSegment = ModeSegmentedControl.SelectedSegment;
            string inputText = InputTextField.StringValue;
            int key = KeyTextField.IntValue;
            string result = string.Empty;

            if (!string.IsNullOrEmpty(inputText) && key != 0)
            {               
                switch (selectedSegment)
                {
                    case 0:
                        result = CezarCipher(inputText, key);
                        break;
                    case 1:
                        result = CezarDecipher(inputText, key);
                        break;
                    default:
                        break;
                }
                OutputResult.StringValue = result;
            }
            else
            {
                OutputResult.StringValue = "Proszę wprowadzić prawidłowy klucz.";
            }
        }

        public string CezarCipher(string text, int shift)
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

        public string CezarDecipher(string text, int shift)
        {
            char[] buffer = text.ToCharArray();

            for (int i = 0; i < buffer.Length; i++)
            {
                char letter = buffer[i];

                if (char.IsLetter(letter))
                {
                    char offset = char.IsUpper(letter) ? 'A' : 'a';
                    letter = (char)((letter - shift - offset + 26) % 26 + offset);
                }

                buffer[i] = letter;
            }

            return new string(buffer);
        }

        partial void Vigenere(NSObject sender)
        {
            var selectedSegment = ModeSegmentedControl.SelectedSegment;
            string inputText = InputTextField.StringValue;
            string key = KeyTextField.StringValue;
            string result = string.Empty;

            //if (!string.IsNullOrEmpty(inputText) && string.IsNullOrEmpty(key))
            //{
                switch (selectedSegment)
                {
                case 0:
                    result = VigenereCoder(inputText, key);  
                    break;
                case 1:
                     result = VigenereDecoder(inputText, key );  
                    break;
                default:
                    break;
                }
            //}
            //else
            //{
            //    OutputResult.StringValue = "Proszę wprowadzić prawidłowy klucz.";
            //}

            OutputResult.StringValue = result;

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

        private string VigenereDecoder(string inputText, string key)
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
                    letter = (char)((letter - shift - offset + 26) % 26 + offset); 
                }

                buffer[i] = letter;
            }
            return new string(buffer);
        }




        private static readonly string key = "b14ca5898a4e4133bbce2ea2315a1916"; 
        private static readonly string iv = "A-16-Byte-String";

        partial void AES(NSObject sender)
        {
            var selectedSegment = ModeSegmentedControl.SelectedSegment;
            string inputText = InputTextField.StringValue;
            
            string result = string.Empty;
            if (!string.IsNullOrEmpty(inputText))
            {
                switch (selectedSegment)
                {
                case 0:
                    result = EncryptStringAES(inputText); 
                    break;
                case 1:
                    result = DecryptStringAES(inputText);
                    break;
                default:
                    break;
                }
            }
            else
            {
                OutputResult.StringValue = "Proszę wprowadzić prawidłowy klucz.";
            }

            OutputResult.StringValue = result;
        }



        private static string EncryptStringAES(string plainText)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = Encoding.UTF8.GetBytes(iv);

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter sw = new StreamWriter(cs))
                        {
                            sw.Write(plainText);
                        }
                        return Convert.ToBase64String(ms.ToArray());
                    }
                }
            }
        }

        private static string DecryptStringAES(string encryptedText)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = Encoding.UTF8.GetBytes(iv);

                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream ms = new MemoryStream(Convert.FromBase64String(encryptedText)))
                {
                    using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader sr = new StreamReader(cs))
                        {
                            return sr.ReadToEnd();
                        }
                    }
                }
            }
        }

        partial void Copy(NSObject sender)
        {
            
             var textToCopy = OutputResult.StringValue;

           
             NSPasteboard.GeneralPasteboard.ClearContents();
             NSPasteboard.GeneralPasteboard.SetStringForType(textToCopy, NSPasteboard.NSStringType);
        }


    }
}
