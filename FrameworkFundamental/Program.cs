using System;
using System.Text;             
using System.Globalization;   
using System.IO;               

class Program
{
    static void Main()
    {
        // =========================================================
        // Strign and Text Handling: Working with Character Data
        // =========================================================

        // ---------------------------------------------------------
        // 1. char : Single Unicode Character (System.Char)
        // ---------------------------------------------------------
        char c = 'A';            // Simple character
        char newLine = '\n';     // Control character (newline)

        Console.WriteLine($"Char c = {c}");
        Console.WriteLine("New line char exists but not visible"+ newLine);

        // --- System.Char static methods ---
        Console.WriteLine(char.ToUpper('c'));              // Case conversion
        Console.WriteLine(char.IsWhiteSpace('\t'));        // Character check

        // Culture-sensitive case conversion
        Console.WriteLine(char.ToUpper('i'));              // Depends on current culture
        Console.WriteLine(char.ToUpperInvariant('i'));     // Culture-invariant (always 'I')

        // Character categorization
        Console.WriteLine(char.IsLetter('A'));             // True
        Console.WriteLine(char.IsDigit('1'));              // True
        Console.WriteLine(char.GetUnicodeCategory('A'));   // UppercaseLetter

        // ---------------------------------------------------------
        // 2. string : Immutable sequence of characters
        // ---------------------------------------------------------

        // --- Constructing strings ---
        string s1 = "Hello";                               // Literal
        string s2 = "First Line\r\nSecond Line";          // Escape sequence
        string s3 = @"C:\\Path\\File.txt";               // Verbatim string

        Console.WriteLine(s1);
        Console.WriteLine(s2);
        Console.WriteLine(s3);

        // Repeating characters using string constructor
        Console.WriteLine(new string('*', 10));             // **********

        // From char array
        char[] ca = "Hello".ToCharArray();
        string s4 = new string(ca);
        Console.WriteLine(s4);

        // --- NULL vs EMPTY STRING ---

        string empty = "";                                // Empty string
        string nullString = null;                          // Null reference

        Console.WriteLine(empty.Length == 0);              // True
        Console.WriteLine(empty == string.Empty);          // True
        Console.WriteLine(nullString == null);             // True
        Console.WriteLine(nullString == "");               // False

        // Safe null/empty check
        Console.WriteLine(string.IsNullOrEmpty(empty));    // True
        Console.WriteLine(string.IsNullOrEmpty(nullString)); // True

        // --- Accesing Characters ---
        string str = "abcde";
        char letter = str[1];            // Indexer access
        Console.WriteLine(letter);       // b

        // Iteration using foreach
        foreach (char ch in "123")
            Console.Write(ch + ",");
        Console.WriteLine();            // 1,2,3,

        // --- Searching within String ---
        string text = "Hello World";

        Console.WriteLine(text.StartsWith("Hello"));    // True
        Console.WriteLine(text.EndsWith("World"));      // True
        Console.WriteLine(text.Contains("lo Wo"));      // True

        Console.WriteLine(text.IndexOf("o"));             // First occurrence - 4
        Console.WriteLine(text.LastIndexOf("o"));         // Last occurrence - 7
        Console.WriteLine(text.IndexOfAny(new char[] { 'x', 'a' })); 
        // Because x doesn't exist, so W is seen, return -1 if there are no letters in the word

        // --- Manipulating strings (Returning new strings) ---

        string sample = "  C# Programming  ";

        Console.WriteLine(sample.Substring(2, 2));          // Extract substring
        Console.WriteLine(sample.Insert(2, "Awesome "));    // Insert text
        Console.WriteLine(sample.Remove(2, 3));             // Remove text
        Console.WriteLine(sample.Trim());                   // Trim whitespace
        Console.WriteLine(sample.Replace("C#", "DotNet"));
        Console.WriteLine(sample.ToUpperInvariant());

        Console.WriteLine("Hi".PadLeft(5, '*'));           // ***Hi
        Console.WriteLine("Hi".PadRight(5, '*'));          // Hi***

        // --- Splitting and Joining strings ---

        string csv = "red,green,blue";
        string[] parts = csv.Split(',');

        Console.WriteLine(string.Join(" | ", parts));     // Join with delimiter
        Console.WriteLine(string.Concat(parts));            // No delimiter

        // --- String.Format() and Interpolated Strings ---

        string composite = "It's {0} degrees in {1} on this {2} morning";
        string formatted = string.Format(composite, 23, "Bandung", DateTime.Now.DayOfWeek);
        Console.WriteLine(formatted);

        // Interpolated string
        Console.WriteLine($"It's hot this {DateTime.Now.DayOfWeek} morning");
        Console.WriteLine($"Name={"Mary",-20} Credit Limit={50000,15:C}");

        // ---------------------------------------------------------
        // 3. Comparing Strings
        // ---------------------------------------------------------

        // Equality comparison
        Console.WriteLine(string.Equals("foo", "FOO", StringComparison.OrdinalIgnoreCase));     // True

        // Order comparison
        Console.WriteLine(string.Compare("Atom", "atom", StringComparison.Ordinal));    // A=65, a=97 --> 65-97 = -32 
        Console.WriteLine(string.Compare("Atom", "atom", StringComparison.InvariantCultureIgnoreCase));
        Console.WriteLine(string.CompareOrdinal("Atom", "atom"));

        // ---------------------------------------------------------
        // 4. StringBuilder : Mutable String
        // ---------------------------------------------------------

        StringBuilder sb = new StringBuilder();     // Optional initial string and capacity

        for (int i = 0; i < 10; i++)
        {
            sb.Append(i).Append(",");   // Efficiently adds to the same StringBuilder object
        }

        sb.AppendLine();        // Appends a string and a newline sequence.
        sb.AppendFormat("Total items: {0}", 10);    // Accepts a composite format string, similar to String.Format()

        Console.WriteLine(sb.ToString());   // Convert to immutable string for final result

        sb.Length = 0;                      // Clear content (capacity remains)

        // ---------------------------------------------------------
        // 5. Text Encoding and Unicode
        // ---------------------------------------------------------

        string numbers = "0123456789";

        byte[] utf8Bytes = Encoding.UTF8.GetBytes(numbers); // UTF-8 encoding
        byte[] utf16Bytes = Encoding.Unicode.GetBytes(numbers); // UTF-16 encoding

        Console.WriteLine($"UTF-8 byte length : {utf8Bytes.Length}");
        Console.WriteLine($"UTF-16 byte length : {utf16Bytes.Length}");

        string decoded = Encoding.UTF8.GetString(utf8Bytes);
        Console.WriteLine(decoded);

        // File I/O with encoding (UTF-16)
        File.WriteAllText("data.txt", "Testing Unicode....", Encoding.Unicode);
        Console.WriteLine("File written with UTF-16 encoding");


        System.Console.WriteLine("=========================================================");
        // =========================================================
        // Date and Times
        // =========================================================

        // ---------------------------------------------------------
        // 1. TimeSpan: An Interval of Time
        // ---------------------------------------------------------
        
        // Constructing TimeSpan using constructors
        TimeSpan ts1 = new TimeSpan(2, 30, 0); // 2 hours, 30 minutes
        TimeSpan ts2 = new TimeSpan(1, 2, 30, 0, 0); // 1 day, 2:30:00
        TimeSpan tsTicks = new TimeSpan(10_000_000); // 1 second (10 million ticks)

        Console.WriteLine(ts1);         // 02:30:00
        Console.WriteLine(ts2);         // 1.02:30:00
        Console.WriteLine(tsTicks);     // 00:00:01

        // Constructing TimeSpan using From... methods
        TimeSpan tsFromHours = TimeSpan.FromHours(2.5); // 02:30:00
        TimeSpan tsNegative = TimeSpan.FromHours(-2.5); // -02:30:00

        Console.WriteLine(tsFromHours);
        Console.WriteLine(tsNegative);

        // TimeSpan arithmetic
        TimeSpan duration = TimeSpan.FromHours(2) + TimeSpan.FromMinutes(30);
        TimeSpan nearlyTenDays = TimeSpan.FromDays(10) - TimeSpan.FromSeconds(1);

        Console.WriteLine(duration);        // 02:30:00
        Console.WriteLine(nearlyTenDays);   // 9.23:59:59

        // Component vs Total properties
        Console.WriteLine(nearlyTenDays.Days);      // Component days
        Console.WriteLine(nearlyTenDays.TotalDays); // Total days (double)

        // Parsing and formatting TimeSpan
        TimeSpan parsedTs = TimeSpan.Parse("02:30:00");
        Console.WriteLine(parsedTs);

        if (TimeSpan.TryParse("invalid", out TimeSpan safeTs) == false)
        {
            Console.WriteLine("Failed to parse TimeSpan safely");
        }

        // Default value
        TimeSpan defaultTs = default; // TimeSpan.Zero
        Console.WriteLine(defaultTs);

        // Time of day from DateTime
        TimeSpan timeOfDay = DateTime.Now.TimeOfDay;
        Console.WriteLine(timeOfDay);

        // ---------------------------------------------------------
        // 2. DateTime and DateTimeOffset: Point in Time
        // ---------------------------------------------------------
        
        // 2.1 DateTime : Point in Time (with DateTimeKind)
        
        // Constructing DateTime
        DateTime dt1 = new DateTime(2025, 6, 19); // Date only
        DateTime dt2 = new DateTime(2025, 6, 19, 15, 0, 0); // Date + time

        Console.WriteLine(dt1);     // 19/06/2025 00:00:00
        Console.WriteLine(dt2);     // 19/06/2025 15:00:00

        // DateTime with Kind
        DateTime localDt = new DateTime(2025, 6, 19, 15, 0, 0, DateTimeKind.Local);
        DateTime utcDt = new DateTime(2025, 6, 19, 15, 0, 0, DateTimeKind.Utc);

        Console.WriteLine(localDt.Kind);
        Console.WriteLine(utcDt.Kind);

        // Equality ignores DateTimeKind
        Console.WriteLine(localDt == utcDt); // May be true if components equal

        // Current date and time
        Console.WriteLine(DateTime.Now);    // Local now        22/01/2026 10:49:59
        Console.WriteLine(DateTime.UtcNow); // UTC now          22/01/2026 03:49:59
        Console.WriteLine(DateTime.Today);  // Midnight today   22/01/2026 00:00:00

        // DateTime calculations
        DateTime nextWeek = DateTime.Now.AddDays(7);
        DateTime lastMonth = DateTime.Now.AddMonths(-1);

        Console.WriteLine(nextWeek);        // 29/01/2026 10:49:59
        Console.WriteLine(lastMonth);       // 22/12/2025 10:49:59

        // Subtracting DateTime gives TimeSpan
        TimeSpan diff = DateTime.Now - DateTime.Today;
        Console.WriteLine(diff);    // 10:49:59.1496196

        // Parsing DateTime
        DateTime parsedDate = DateTime.Parse("2025-06-19");
        DateTime exactDate = DateTime.ParseExact(
        "2025-06-19 15:00:00",
        "yyyy-MM-dd HH:mm:ss",
        CultureInfo.InvariantCulture);

        Console.WriteLine(parsedDate);
        Console.WriteLine(exactDate);


        // 2.2 DateTimeOffset : Point in Time with explicit UTC offset

        // Constructing DateTimeOffset
        DateTimeOffset dto1 = new DateTimeOffset(
        2025, 6, 19, 15, 0, 0, TimeSpan.FromHours(-7));

        Console.WriteLine(dto1);            // 19/06/2025 15:00:00 -07:00

        // From DateTime
        DateTimeOffset dtoFromLocal = new DateTimeOffset(localDt);
        DateTimeOffset dtoFromUtc = new DateTimeOffset(utcDt);

        Console.WriteLine(dtoFromLocal);    // 19/06/2025 15:00:00 +07:00
        Console.WriteLine(dtoFromUtc);      // 19/06/2025 15:00:00 +00:00

        // Equality compares absolute time
        Console.WriteLine(dtoFromLocal.Equals(dtoFromUtc)); // False

        // Converting DateTimeOffset
        Console.WriteLine(dto1.UtcDateTime);    // As UTC DateTime
        Console.WriteLine(dto1.LocalDateTime);  // Converted to local time
        Console.WriteLine(dto1.DateTime);       // Kind = Unspecified
        // 19/06/2025 22:00:00
        // 20/06/2025 05:00:00
        // 19/06/2025 15:00:00

        // Current DateTimeOffset
        Console.WriteLine(DateTimeOffset.Now);      // 22/01/2026 11:08:50 +07:00
        Console.WriteLine(DateTimeOffset.UtcNow);   // 22/01/2026 04:08:50 +00:00

        // DateTimeOffset calculations
        DateTimeOffset future = DateTimeOffset.Now.AddHours(5);
        TimeSpan spanBetween = future - DateTimeOffset.Now;

        Console.WriteLine(future);          // 22/01/2026 16:08:50 +07:00
        Console.WriteLine(spanBetween);     // 04:59:59.9999935

        // Formatting DateTimeOffset
        Console.WriteLine(dto1.ToString("o")); // Round-trip format         2025-06-19T15:00:00.0000000-07:00
        Console.WriteLine(dto1.ToString("yyyy-MM-dd HH:mm:ss zzz"));        // 2025-06-19 15:00:00 -07:00


        // 2.3 NULLABLE DATE/TIME

        DateTime? nullableDate = null; // Nullable DateTime
        DateTimeOffset? nullableOffset = null; // Nullable DateTimeOffset

        Console.WriteLine(nullableDate.HasValue); // False

        // Avoiding MinValue pitfalls
        DateTime min = DateTime.MinValue;
        Console.WriteLine(min);         // 01/01/0001 00:00:00

        // ---------------------------------------------------------
        // 3. DateOnly and TimeOnly
        // ---------------------------------------------------------

        // DateOnly : date without time
        DateOnly dateOnly = new DateOnly(2025, 6, 19);
        Console.WriteLine(dateOnly);    // 19/06/2025

        // TimeOnly : time without date
        TimeOnly timeOnly = new TimeOnly(9, 30, 0);
        Console.WriteLine(timeOnly);    // 09:30

        // Typical use cases
        DateOnly birthday = DateOnly.Parse("2003-08-11");
        TimeOnly openingTime = TimeOnly.Parse("08:00");

        Console.WriteLine(birthday);        // 11/08/2003
        Console.WriteLine(openingTime);     // 08:00


        System.Console.WriteLine("=========================================================");
        // =========================================================
        // Formatting and Parsing: Data Conversion in .NET
        // =========================================================

        // ---------------------------------------------------------
        // 1. Basic ToString() and Parse()/TryParse()
        // ---------------------------------------------------------

        // 1.1. BASIC 

        // Formatting: value -> string
        string s = true.ToString();              // "True"

        // Parsing: string -> value
        bool b = bool.Parse(s);                  // true

        // Numeric parsing dengan TryParse (aman, tanpa exception)
        bool failure = int.TryParse("qwerty", out int i1); // false, i1 = 0
        bool success = int.TryParse("123", out int i2);    // true, i2 = 123

        // Menggunakan discard (_) jika hanya peduli valid / tidak
        bool isValidInput = int.TryParse("789", out _);

        // 1.2. Parse() vs TryParse()

        // Parse() akan melempar exception jika gagal
        try
        {
            int x = int.Parse("ABC"); // FormatException
        }
        catch (FormatException)
        {
            Console.WriteLine("Parse gagal: format tidak valid");
        }

        // TryParse() mengembalikan bool, tanpa exception
        if (!int.TryParse("ABC", out int y))
        {
            Console.WriteLine("TryParse gagal tanpa exception");
        }

        // 1.3. Culture Sensitivity (Pengaruh Culture)

        // Bergantung pada culture OS
        // Di beberapa culture, '.' = pemisah ribuan, ',' = desimal
        // double.Parse("1.234") bisa berarti 1234 atau 1.234

        // CultureInfo.InvariantCulture (Direkomendasikan)

        double invariantParsed = double.Parse("1.234", CultureInfo.InvariantCulture);
        string invariantFormatted = 1.234.ToString(CultureInfo.InvariantCulture);

        Console.WriteLine(invariantParsed);       // 1.234
        Console.WriteLine(invariantFormatted);    // "1.234"


        // ---------------------------------------------------------
        // 2. Format Providers: Granular Control Over Formatting and Parsing
        // ---------------------------------------------------------

        // 2.1. NumberFormatInfo: kontrol detail format angka
        NumberFormatInfo numberFormat = new NumberFormatInfo();
        numberFormat.CurrencySymbol = "$$";
        Console.WriteLine(3.ToString("C", numberFormat)); // $$3.00
        numberFormat.CurrencySymbol = "Rp ";
        Console.WriteLine(3.ToString("C", numberFormat)); // $$3.00

        // 2.2. DateTimeFormatInfo
        DateTime dt = new DateTime(2025, 1, 15);
        DateTimeFormatInfo f = new DateTimeFormatInfo();
        f.ShortDatePattern = "yyyy/MM/dd";
        Console.WriteLine(dt.ToString(f));

        // 2.3. CultureInfo sebagai Format Provider
        CultureInfo ukCulture = CultureInfo.GetCultureInfo("en-GB");
        Console.WriteLine(3.ToString("C", ukCulture)); // £3.00

        CultureInfo invariant = CultureInfo.InvariantCulture;

        Console.WriteLine(dt.ToString(invariant));      // Invariant full format  01/15/2025 00:00:00
        Console.WriteLine(dt.ToString("d", invariant)); // Invariant short date   01/15/2025

        // 2.4. Customizing FormatInfo (Clone & Modify)

        NumberFormatInfo customFormat = (NumberFormatInfo)CultureInfo.CurrentCulture.NumberFormat.Clone();

        customFormat.NumberGroupSeparator = " "; // ganti pemisah ribuan

        Console.WriteLine(12345.6789.ToString("N3", customFormat)); // 12 345,679

        // 2.5. Composite Formatting

        // Menggunakan format string {}
        Console.WriteLine("Credit={0:C}", 500);

        // Composite formatting + InvariantCulture
        string composite1 = string.Format(
            CultureInfo.InvariantCulture,
            "Value={0}",
            12.34);
        Console.WriteLine(composite1);

        // 2.6. Parsing dengan Format Provider & Styles

        // Mengizinkan tanda kurung untuk angka negatif
        int minusTwo = int.Parse("(2)", NumberStyles.Integer | NumberStyles.AllowParentheses);

        Console.WriteLine(minusTwo); // -2

        // Parsing currency dengan culture tertentu
        decimal money = decimal.Parse(
            "£5.20",
            NumberStyles.Currency,
            CultureInfo.GetCultureInfo("en-GB"));

        Console.WriteLine(money); // 5.20

        // ---------------------------------------------------------
        // 3. IFormatProvider and ICustomFormatter: Creating Custom Formatting Logic
        // ---------------------------------------------------------

        double n = -123.45;
        IFormatProvider wordyProvider = new WordyFormatProvider(CultureInfo.InvariantCulture);

        string result = string.Format(
            wordyProvider,
            "{0:C} in words is {0:W}",
            n);

        Console.WriteLine(result);
        
    }

    // ======================================================
    // Custom Format Provider: WordyFormatProvider
    // ======================================================

    // Mengubah angka menjadi kata per digit
    public class WordyFormatProvider : IFormatProvider, ICustomFormatter
    {
        private readonly IFormatProvider _parent;

        public WordyFormatProvider(IFormatProvider parent)
        {
            _parent = parent;
        }

        // Memberikan formatter kustom ke sistem formatting
        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
                return this;

            return null;
        }

        // Logic formatting kustom
        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            // Jika bukan format "W", gunakan formatter default
            if (arg == null || format != "W")
                return string.Format(_parent, "{0:" + format + "}", arg);

            StringBuilder result = new StringBuilder();

            // Gunakan invariant culture agar digit konsisten
            string text = string.Format(CultureInfo.InvariantCulture, "{0}", arg);

            foreach (char c in text)
            {
                result.Append(c switch
                {
                    '-' => "minus ",
                    '.' => "point ",
                    '0' => "zero ",
                    '1' => "one ",
                    '2' => "two ",
                    '3' => "three ",
                    '4' => "four ",
                    '5' => "five ",
                    '6' => "six ",
                    '7' => "seven ",
                    '8' => "eight ",
                    '9' => "nine ",
                    _ => ""
                });
            }

            return result.ToString().Trim();
        }
    }
}
