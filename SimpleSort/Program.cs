using SimpleSort;
using System.Diagnostics;

public static class Program
{
    
    public static void Main()
    {
        var vr = new long[] { 5, 1, 0, 2, 3, 5, 8, 5, 2, 1, 0 };
        Shell shell = new Shell(vr);
        shell.ToSort();
        //Debag();
    }

    static void Debag()
    {
        long[] inputVal = new long[] { (long)Math.Pow(10, 2), (long)Math.Pow(10, 3), (long)Math.Pow(10, 4) , 20000, 30000};

        string hat = "Size".PadRight(8) + "||" + "Basic Bubble".PadRight(35) + "||" + "Modern Bubble".PadRight(35) + "||" + 
            "Basic Insertion".PadRight(35) + "||" + "Shift Insertion".PadRight(35) + "||" + "Binary Insertion".PadRight(35) + "||";

        string hat2 = "".PadLeft(8) + "||" + 
            "time".PadLeft(12) + "|" + "assig.".PadLeft(10) + "|" + "cmp.".PadLeft(11) + "||" +
            "time".PadLeft(12) + "|" + "assig.".PadLeft(10) + "|" + "cmp.".PadLeft(11) + "||" + 
            "time".PadLeft(12) + "|" + "assig.".PadLeft(10) + "|" + "cmp.".PadLeft(11) + "||" +
            "time".PadLeft(12) + "|" + "assig.".PadLeft(10) + "|" + "cmp.".PadLeft(11) + "||" +
            "time".PadLeft(12) + "|" + "assig.".PadLeft(10) + "|" + "cmp.".PadLeft(11) + "||";

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

            string report = "";

            Stopwatch sw = new Stopwatch();
            Bubble bubble = new Bubble(massForBubbleSimple);
            sw.Start();
            bubble.Basic();
            sw.Stop();
            report += Format(sw.Elapsed.TotalMilliseconds) + $"ms|{Format(bubble.AsgCounter)}| {Format(bubble.CmpCounter)}||";

            sw = new Stopwatch();
            bubble = new Bubble(massForBubbleModern);
            sw.Start();
            bubble.Modern();
            sw.Stop();
            report += Format(sw.Elapsed.TotalMilliseconds) + $"ms|{Format(bubble.AsgCounter)}| {Format(bubble.CmpCounter)}||";

            sw = new Stopwatch();
            Insertion insertion = new Insertion(massForIntersertSimple);
            sw.Start();
            insertion.Basic();
            sw.Stop();
            report += Format(sw.Elapsed.TotalMilliseconds) + $"ms|{Format(insertion.AsgCounter)}| {Format(insertion.CMPCounter)}||";

            sw = new Stopwatch();
            insertion = new Insertion(massForIntersertShift);
            sw.Start();
            insertion.Shift();
            sw.Stop();
            report += Format(sw.Elapsed.TotalMilliseconds) + $"ms|{Format(insertion.AsgCounter)}| {Format(insertion.CMPCounter)}||";

            sw = new Stopwatch();
            insertion = new Insertion(massForIntersertDichotomy);
            sw.Start();
            insertion.Dichotomy();
            sw.Stop();
            report += Format(sw.Elapsed.TotalMilliseconds) + $"ms|{Format(insertion.AsgCounter)}| {Format(insertion.CMPCounter)}||";

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
            mass[count] = random.Next(int.MinValue, int.MaxValue);
        }
        return mass;
    }

    static string Format(int num)
    {
        return num.ToString().PadLeft(10);
    }
    static string Format(double d)
    {
        return Math.Round(d, 2).ToString().PadLeft(10);
    }

}
