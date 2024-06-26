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
                InformativeText = "Aplikacja ma na celu szyfrowanie i odszyfrowywanie zdań, \ntekstów oraz haseł.\n\n " +
                "Oto krótka instrukcja użytkowania:\n\n" +

                "1.Na górze znajduje się suwak, którym wybieramy, czy chcemy zaszyfrować, \nczy odszyfrować tekst lub ciąg liczb.\n" +
                "2.Poniżej znajduje się pole, w które wpisujemy tekst oraz, \n w zależności od metody szyfrowania, klucz.\n " +
                "**Uwaga:** Nie każda metoda szyfrowania wymaga klucza.\n" +
                "3.Na samym dole wyświetlany jest wynik - zaszyfrowany tekst. \nPoniżej znajduje się przycisk \"Kopiuj\", który umożliwia łatwe skopiowanie zaszyfrowanego tekstu.\n\n" +
                "**Ważna informacja:** Przycisk \"Kopiuj\" kopiuje tylko zaszyfrowany tekst. \nKlucz musimy zapamiętać osobno, \n ponieważ bez niego nie będziemy w stanie odszyfrować tekstu. "
            };
            alert.AddButton("OK");
            alert.RunModal();
        }

    }
}

