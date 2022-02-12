using InterpolatedStrings;
using InterpolatedStrings.Properties;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

CompositeFormatting();
InterpolatedStrings();
InterpolatedStringsWithExpressions();
InterpolatedStringsWithBraces();
InterpolatedStringsWithExcapeSequences();
VerbatimStringLiterals();
VerbatimInterpolatedStrings();
InterpolatedStringsWithAlignmentAndFormatting();
InterpolatedStringsWithCulture();
EfFromSql();
EfInterpolated();
EfInjection();
LocalizedCompositeFormatting();
LocalizedInterpolatedString();

void CompositeFormatting()
{
    var name = "Alok";
    var formatted = string.Format("Hello, {0}!", name);
    Console.WriteLine(formatted);
}

void InterpolatedStrings()
{
    var name = "Alok";
    var formatted = $"Hello, {name}";
    Console.WriteLine(formatted);
}

void InterpolatedStringsWithExpressions()
{
    var a = 4;
    var b = 2;
    var formatted = $"{a} + {b} = {a + b}";
    Console.WriteLine(formatted);
}

void InterpolatedStringsWithBraces()
{
    var a = new[] { 1, 2, 3, 4, 5 };
    var formatted = $"{nameof(a)} = {{ {string.Join(", ", a)} }}";
    Console.WriteLine(formatted);
}

void InterpolatedStringsWithExcapeSequences()
{
    var a = 3.5;
    var b = 12.25;
    var formatted = $"{a}\n+ {b}\n= {a + b}";
    Console.WriteLine(formatted);
}

void VerbatimStringLiterals()
{
    var regular = "File path:\r\n\"C:\\Temp\"";
    var verbatim = @"File path:
""C:\Temp""";
    Console.WriteLine(regular);
    Console.WriteLine(verbatim);
}

void VerbatimInterpolatedStrings()
{
    var a = 3.5;
    var b = 12.25;
    var formatted = $@"{a}
+ {b}
= {a + b}";
    Console.WriteLine(formatted);
}

void InterpolatedStringsWithAlignmentAndFormatting()
{
    var a = 3.5;
    var b = 12.25;
    var formatted = $" {a,6:0.00}\n+ {b,5:0.00}\n= {a + b,5:0.00}";
    Console.WriteLine(formatted);

    var n = 3.5;
    var alignmentAndFormatting = $"{n,5:0.00}";
    Console.WriteLine(alignmentAndFormatting);
    var alignmentOnly = $"{n,5}";
    Console.WriteLine(alignmentOnly);
    var formattingOnly = $"{n:0.00}";
    Console.WriteLine(formattingOnly);
    var neither = $"{n}";
    Console.WriteLine(neither);
}

void InterpolatedStringsWithCulture()
{
    var culture = CultureInfo.GetCultureInfo("sl-SI");
    var a = 3.5;
    var b = 12.25;
    FormattableString formattableString = $"  {a,5:0.00}\n+ {b,5:0.00}\n= {a + b,5:0.00}";
    var formatted = formattableString.ToString(culture);
    Console.WriteLine(formatted);
}

void EfFromSql()
{
    using (var context = new EFContext())
    {
        var param = "Singh";
        var query = context.Persons.FromSqlInterpolated($"SELECT * FROM Persons WHERE LastName = {param};");
    }
}

void EfInterpolated()
{
    using (var context = new EFContext())
    {
        var param = "Singh";
        var sql = $"SELECT * FROM Persons WHERE LastName = {param};";
        var query = context.Persons.FromSqlRaw(sql);
    }
}

void EfInjection()
{
    using (var context = new EFContext())
    {
        var param = "Doe'; DROP TABLE Persons; --";
        var sql = $"SELECT * FROM Persons WHERE LastName = '{param}';";
        var query = context.Persons.FromSqlRaw(sql);
    }
}

void LocalizedCompositeFormatting()
{
    var name = "John";
    // Strings.Localized = "Hello, {0}!"
    var formatted = string.Format(Strings.Localized, name);
    Console.WriteLine(formatted);
}

void LocalizedInterpolatedString()
{
    var name = "Alok";

    FormattableString formattableString = $"Hello, {name}!";

    // formattableString.Format = "Hello, {0}!"
    // formattableString.GetArguments() = [ name ]

    var formatted = string.Format(GetTranslation(formattableString.Format),
                formattableString.GetArguments());

    Console.WriteLine(formatted);

}

string GetTranslation(string original)
{
    // return the translation based on the content of the original string
    return original;
}