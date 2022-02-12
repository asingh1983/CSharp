using System.Globalization;

Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");

var date = new DateTime(2018, 9, 1);
Console.WriteLine(date.ToString("d"));

var slCulture = CultureInfo.GetCultureInfo("sl-SI");
Console.WriteLine(date.ToString("d", slCulture));

var pi = 3.14;
Console.WriteLine(pi.ToString());
Console.WriteLine(pi.ToString(slCulture));

var temperature = 21.5;
var timestamp = new DateTime(2018, 9, 1, 16, 15, 30);
var formatString = "Temperature: {0} °C at {1}";
Console.WriteLine(string.Format(formatString, temperature, timestamp));
Console.WriteLine(string.Format(slCulture, formatString, temperature, timestamp));

var stringNumber = "3,14";
Double.TryParse(stringNumber, out var enNumber); // = 314
Double.TryParse(stringNumber, NumberStyles.Any, slCulture, out var slNumber); // = 3.14

var doubleS = "ss";
var eszett = "ß";

var equalOrdinal = string.Equals(doubleS, eszett);
var equalCulture = string.Equals(doubleS, eszett, StringComparison.CurrentCulture); // Should be true Need to re-verify

Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("sl-SI");

var piInvarientCulture = "3.14";
var piSICulture = "3.14";

var equalOrdinal2 = string.Equals(piInvarientCulture, piSICulture);
var equalCulture2 = string.Equals(piInvarientCulture, piSICulture, StringComparison.CurrentCulture);

var czCulture = CultureInfo.GetCultureInfo("cs-CZ");
var words = new[] { "channel", "double" };
var ordinalSortedSet = new SortedSet<string>(words); // = { "channel", "double" }
var cultureSortedSet = new SortedSet<string>(words, StringComparer.Create(czCulture, ignoreCase: true)); // = { "double", "channel" }

var trCulture = CultureInfo.GetCultureInfo("tr-TR");
var lowerCaseI = "i";
var upperCaseIen = lowerCaseI.ToUpper(); // = "I"
var upperCaseItr = lowerCaseI.ToUpper(trCulture); // = "İ"

Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
Console.WriteLine("Culture = {0}",
   Thread.CurrentThread.CurrentCulture.DisplayName);
Console.WriteLine("(file == FILE) = {0}",
   (String.Compare("file", "FILE", true) == 0));

Thread.CurrentThread.CurrentCulture = new CultureInfo("tr-TR");
Console.WriteLine("Culture = {0}",
   Thread.CurrentThread.CurrentCulture.DisplayName);
Console.WriteLine("(file == FILE) = {0}",
   (String.Compare("file", "FILE", true) == 0));


Console.ReadKey();

//Ordinal Comparision: Byte reperestation of Characters
