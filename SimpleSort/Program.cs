using SimpleSort;
using System.Diagnostics;

public static class Program
{
    public static void Main()
    {
        Debag();
    }

    static void Debag()
    {
        GetMassForTests();
        List<string> reports1 = new List<string>();
        List<string> reports2 = new List<string>();

        int count = 0;
        while (count < massForTests.Length)
        {
            string report = "";

            Stopwatch sw = new Stopwatch();
            Bubble bubble = new Bubble(GetCopyMass(count));
            sw.Start();
            bubble.Basic();
            sw.Stop();
            report += FormatTimer(sw.Elapsed.TotalMilliseconds) + $"|{Format(bubble.AsgCounter)}|{Format(bubble.CmpCounter)}||";

            sw = new Stopwatch();
            bubble = new Bubble(GetCopyMass(count));
            sw.Start();
            bubble.Modern();
            sw.Stop();
            report += FormatTimer(sw.Elapsed.TotalMilliseconds) + $"|{Format(bubble.AsgCounter)}|{Format(bubble.CmpCounter)}||";

            sw = new Stopwatch();
            Insertion insertion = new Insertion(GetCopyMass(count));
            sw.Start();
            insertion.Basic();
            sw.Stop();
            report += FormatTimer(sw.Elapsed.TotalMilliseconds) + $"|{Format(insertion.AsgCounter)}|{Format(insertion.CMPCounter)}||";

            sw = new Stopwatch();
            insertion = new Insertion(GetCopyMass(count));
            sw.Start();
            insertion.Shift();
            sw.Stop();
            report += FormatTimer(sw.Elapsed.TotalMilliseconds) + $"|{Format(insertion.AsgCounter)}|{Format(insertion.CMPCounter)}||";

            sw = new Stopwatch();
            insertion = new Insertion(GetCopyMass(count));
            sw.Start();
            insertion.Dichotomy();
            sw.Stop();
            report += FormatTimer(sw.Elapsed.TotalMilliseconds) + $"|{Format(insertion.AsgCounter)}|{Format(insertion.CMPCounter)}||";

            reports1.Add(report);
            report = "";

            sw = new Stopwatch();
            Shell shell = new Shell(GetCopyMass(count));
            sw.Start();
            shell.Basic();
            sw.Stop();
            report += FormatTimer(sw.Elapsed.TotalMilliseconds) + $"|{Format(shell.AsgCounter)}|{Format(shell.CMPCounter)}||";

            sw = new Stopwatch();
            shell = new Shell(GetCopyMass(count));
            sw.Start();
            shell.Hibbard();
            sw.Stop();
            report += FormatTimer(sw.Elapsed.TotalMilliseconds) + $"|{Format(shell.AsgCounter)}|{Format(shell.CMPCounter)}||";

            sw = new Stopwatch();
            shell = new Shell(GetCopyMass(count));
            sw.Start();
            shell.Pratt();
            sw.Stop();
            report += FormatTimer(sw.Elapsed.TotalMilliseconds) + $"|{Format(shell.AsgCounter)}|{Format(shell.CMPCounter)}||";

            sw = new Stopwatch();
            shell = new Shell(GetCopyMass(count));
            sw.Start();
            shell.Tsiur();
            sw.Stop();
            report += FormatTimer(sw.Elapsed.TotalMilliseconds) + $"|{Format(shell.AsgCounter)}|{Format(shell.CMPCounter)}||";

            reports2.Add(report);
            report = "";

            count++;
        }

        int temp = 30;
        string hat =
            "Size".PadRight(10) +
            "||" + "Basic Bubble".PadRight(temp) +
            "||" + "Modern Bubble".PadRight(temp) +
            "||" + "Basic Insertion".PadRight(temp) +
            "||" + "Shift Insertion".PadRight(temp) +
            "||" + "Binary Insertion".PadRight(temp) +
            "||";
        Console.WriteLine(hat);
        Console.WriteLine(
            "".PadLeft(10) + "||" +
            "time, ms".PadLeft(8) + "|" + "assig.".PadLeft(10) + "|" + "cmp.".PadLeft(10) + "||" +
            "time, ms".PadLeft(8) + "|" + "assig.".PadLeft(10) + "|" + "cmp.".PadLeft(10) + "||" +
            "time, ms".PadLeft(8) + "|" + "assig.".PadLeft(10) + "|" + "cmp.".PadLeft(10) + "||" +
            "time, ms".PadLeft(8) + "|" + "assig.".PadLeft(10) + "|" + "cmp.".PadLeft(10) + "||" +
            "time, ms".PadLeft(8) + "|" + "assig.".PadLeft(10) + "|" + "cmp.".PadLeft(10) +
            "||"
            );
        Console.WriteLine("-".PadRight(hat.Length, '-'));
        for (int i = 0; i < reports1.Count; i++)
        {
            Console.WriteLine(Format(sizes[i]) + "||" + reports1[i]);
        }
        Console.WriteLine();

        hat = "Size".PadRight(10) +
            "||" + "Shell Basic".PadRight(temp) +
            "||" + "Shell - Hibbard".PadRight(temp) +
            "||" + "Shell - Pratt".PadRight(temp) +
            "||" + "Shell - Tsiur".PadRight(temp) +
            "||";
        Console.WriteLine(hat);
        Console.WriteLine(
            "".PadLeft(10) + "||" +
            "time, ms".PadLeft(8) + "|" + "assig.".PadLeft(10) + "|" + "cmp.".PadLeft(10) + "||" +
            "time, ms".PadLeft(8) + "|" + "assig.".PadLeft(10) + "|" + "cmp.".PadLeft(10) + "||" +
            "time, ms".PadLeft(8) + "|" + "assig.".PadLeft(10) + "|" + "cmp.".PadLeft(10) + "||" +
            "time, ms".PadLeft(8) + "|" + "assig.".PadLeft(10) + "|" + "cmp.".PadLeft(10) + "||"
            );
        Console.WriteLine("-".PadRight(hat.Length, '-'));
        for (int i = 0; i < reports2.Count; i++)
        {
            Console.WriteLine(Format(sizes[i]) + "||" + reports2[i]);
        }
    }

    static long[][] massForTests;
    static long[] sizes;
    static void GetMassForTests()
    {
        sizes = new long[] { (long)Math.Pow(10, 2), (long)Math.Pow(10, 3), (long)Math.Pow(10, 4), (long)Math.Pow(10, 4)};
        massForTests = new long[sizes.Length][];

        for (int i = 0; i < sizes.Length; i++)
        {
            massForTests[i] = GetMass(sizes[i]);
        }
    }
    static long[] GetCopyMass(int index)
    {
        var mass = massForTests[index];
        long[] copyMass = new long[mass.Length];
        mass.CopyTo(copyMass, 0);
        return copyMass;
    }

    static Random random = new Random();
    static long[] GetMass(long size)
    {
        long[] mass = new long[size];
        long count = 0;

        while (count++ < size - 1)
        {
            mass[count] = random.Next(0, int.MaxValue);
        }
        return mass;
    }

    static string Format(double d)
    {
        return Math.Round(d, 0).ToString().PadLeft(10);
    }
    static string Format(long l)
    {
        return l.ToString().PadLeft(10);
    }
    static string FormatTimer(double d)
    {
        if (d == 0)
        {
            return "-".PadLeft(8);
        }

        if (d > 100)
        {
            return Math.Round(d, 0).ToString().PadLeft(8);
        }
        else
        {
            return Math.Round(d, 2).ToString().PadLeft(8);
        }
    }

}
