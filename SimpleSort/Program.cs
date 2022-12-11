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
        long[] inputVal = new long[] { (long)Math.Pow(10, 2), (long)Math.Pow(10, 3), (long)Math.Pow(10, 4), (long)Math.Pow(10, 5), (long)Math.Pow(10, 6), (long)Math.Pow(10, 7) / 2 };

        int temp = 30;
        string hat = "Size".PadRight(8) + "||" + "Basic Bubble".PadRight(temp) + "||" + "Modern Bubble".PadRight(temp) + "||" +
            "Basic Insertion".PadRight(temp) + "||" + "Shift Insertion".PadRight(temp) + "||" + "Binary Insertion".PadRight(temp) + "||" + "Shell Basic".PadRight(temp) + "||"
            + "Shell - Hibbard".PadRight(temp) + "||" + "Shell - Pratt".PadRight(temp) + "||" + "Shell - Tsiur".PadRight(temp) + "||";

        string hat2 = "".PadLeft(8) + "||" +
            "time".PadLeft(8) + "|" + "assig.".PadLeft(10) + "|" + "cmp.".PadLeft(10) + "||" +
            "time".PadLeft(8) + "|" + "assig.".PadLeft(10) + "|" + "cmp.".PadLeft(10) + "||" +
            "time".PadLeft(8) + "|" + "assig.".PadLeft(10) + "|" + "cmp.".PadLeft(10) + "||" +
            "time".PadLeft(8) + "|" + "assig.".PadLeft(10) + "|" + "cmp.".PadLeft(10) + "||" +
            "time".PadLeft(8) + "|" + "assig.".PadLeft(10) + "|" + "cmp.".PadLeft(10) + "||" +
            "time".PadLeft(8) + "|" + "assig.".PadLeft(10) + "|" + "cmp.".PadLeft(10) + "||" +
            "time".PadLeft(8) + "|" + "assig.".PadLeft(10) + "|" + "cmp.".PadLeft(10) + "||" +
            "time".PadLeft(8) + "|" + "assig.".PadLeft(10) + "|" + "cmp.".PadLeft(10) + "||" +
            "time".PadLeft(8) + "|" + "assig.".PadLeft(10) + "|" + "cmp.".PadLeft(10) + "||";

        string line = "".PadLeft(hat.Length, '-');

        Console.WriteLine(hat);
        Console.WriteLine(hat2);
        Console.WriteLine(line);

        int count = 0;
        while (count < inputVal.Length)
        {
            long[] mass = GetMass(inputVal[count]);

            long[] massForBubbleSimple = new long[mass.Length];
            mass.CopyTo(massForBubbleSimple, 0);

            long[] massForBubbleModern = new long[mass.Length];
            mass.CopyTo(massForBubbleModern, 0);

            long[] massForIntersertSimple = new long[mass.Length];
            mass.CopyTo(massForIntersertSimple, 0);

            long[] massForIntersertShift = new long[mass.Length];
            mass.CopyTo(massForIntersertShift, 0);

            long[] massForIntersertDichotomy = new long[mass.Length];
            mass.CopyTo(massForIntersertDichotomy, 0);

            long[] massForShellBasic = new long[mass.Length];
            mass.CopyTo(massForShellBasic, 0);

            long[] massForShellHibbard = new long[mass.Length];
            mass.CopyTo(massForShellHibbard, 0);

            long[] massForShellPratt = new long[mass.Length];
            mass.CopyTo(massForShellPratt, 0);

            long[] massForShellTsiur = new long[mass.Length];
            mass.CopyTo(massForShellTsiur, 0);

            string report = "";

            Stopwatch sw = new Stopwatch();
            Bubble bubble = new Bubble(massForBubbleSimple);
            sw.Start();
            if (mass.Length <= inputVal[2])
            {
                bubble.Basic();
            }
            sw.Stop();
            report += FormatTimer(sw.Elapsed.TotalMilliseconds) + $"|{Format(bubble.AsgCounter)}|{Format(bubble.CmpCounter)}||";

            sw = new Stopwatch();
            bubble = new Bubble(massForBubbleModern);
            sw.Start();
            if (mass.Length <= inputVal[2])
            {
                bubble.Modern();
            }
            sw.Stop();
            report += FormatTimer(sw.Elapsed.TotalMilliseconds) + $"|{Format(bubble.AsgCounter)}|{Format(bubble.CmpCounter)}||";

            sw = new Stopwatch();
            Insertion insertion = new Insertion(massForIntersertSimple);
            sw.Start();
            if (mass.Length <= inputVal[3])
            {
                insertion.Basic();
            }
            sw.Stop();
            report += FormatTimer(sw.Elapsed.TotalMilliseconds) + $"|{Format(insertion.AsgCounter)}|{Format(insertion.CMPCounter)}||";

            sw = new Stopwatch();
            insertion = new Insertion(massForIntersertShift);
            sw.Start();
            if (mass.Length <= inputVal[3])
            {
                insertion.Shift();
            }
            sw.Stop();
            report += FormatTimer(sw.Elapsed.TotalMilliseconds) + $"|{Format(insertion.AsgCounter)}|{Format(insertion.CMPCounter)}||";

            sw = new Stopwatch();
            insertion = new Insertion(massForIntersertDichotomy);
            sw.Start();
            if (mass.Length <= inputVal[3])
            {
                insertion.Dichotomy();
            }
            sw.Stop();
            report += FormatTimer(sw.Elapsed.TotalMilliseconds) + $"|{Format(insertion.AsgCounter)}|{Format(insertion.CMPCounter)}||";

            sw = new Stopwatch();
            Shell shell = new Shell(massForShellBasic);
            sw.Start();
            shell.Basic();
            sw.Stop();
            report += FormatTimer(sw.Elapsed.TotalMilliseconds) + $"|{Format(shell.AsgCounter)}|{Format(shell.CMPCounter)}||";

            sw = new Stopwatch();
            shell = new Shell(massForShellHibbard);
            sw.Start();
            shell.Hibbard();
            sw.Stop();
            report += FormatTimer(sw.Elapsed.TotalMilliseconds) + $"|{Format(shell.AsgCounter)}|{Format(shell.CMPCounter)}||";

            sw = new Stopwatch();
            shell = new Shell(massForShellPratt);
            sw.Start();
            shell.Pratt();
            sw.Stop();
            report += FormatTimer(sw.Elapsed.TotalMilliseconds) + $"|{Format(shell.AsgCounter)}|{Format(shell.CMPCounter)}||";

            sw = new Stopwatch();
            shell = new Shell(massForShellTsiur);
            sw.Start();
            shell.Tsiur();
            sw.Stop();
            report += FormatTimer(sw.Elapsed.TotalMilliseconds) + $"|{Format(shell.AsgCounter)}|{Format(shell.CMPCounter)}||";

            Console.WriteLine($"{inputVal[count].ToString().PadRight(8)}||{report}");
            count++;
        }


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
