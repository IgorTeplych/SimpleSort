using SimpleSort;
using System.Diagnostics;

public static class Program
{
    public static void Main()
    {
        //MergeSort mergeSort = new MergeSort(new long[] { 0, 2, 8, 5, 3, 4, 10, 25, 7, 1, 2, 7, 2, 4, 3 });
        //mergeSort.Sort();

        Files files = new Files();
        files.Generate(15, 100, "nums");
        files.Split(5, "nums");

        Shell shell = new Shell();
        files.SortContentSplitFiles(shell.Hibbard);
        files.Merge();
       // ExternalSort externalSort = new ExternalSort(10025, 16383);
       //   externalSort.Sort();

        // Debag();
    }

    static void Debag()
    {
        GetMassForTests();
        List<string> reports1 = new List<string>();
        List<string> reports2 = new List<string>();
        List<string> reports3 = new List<string>();

        int count = 0;
        while (count < massForTests.Length)
        {
            string report = "";

            Stopwatch sw = new Stopwatch();
            Bubble bubble = new Bubble(GetCopyMass(count));
            if (massForTests[count].Length <= 100000)
            {
                sw.Start();
                // bubble.Basic();
                sw.Stop();
                report += FormatTimer(sw.Elapsed.TotalMilliseconds) + $"|{Format(bubble.AsgCounter)}|{Format(bubble.CmpCounter)}||";
            }
            else
            {
                report += "не запускался".PadLeft(12 * 3 - 2) + "||";
            }

            sw = new Stopwatch();
            bubble = new Bubble(GetCopyMass(count));
            if (massForTests[count].Length <= 100000)
            {
                sw.Start();
                //bubble.Modern();
                sw.Stop();
                report += FormatTimer(sw.Elapsed.TotalMilliseconds) + $"|{Format(bubble.AsgCounter)}|{Format(bubble.CmpCounter)}||";
            }
            else
            {
                report += "не запускался".PadLeft(12 * 3 - 2) + "||";
            }

            sw = new Stopwatch();
            Insertion insertion = new Insertion(GetCopyMass(count));
            if (massForTests[count].Length <= 100000)
            {
                sw.Start();
                // insertion.Basic();
                sw.Stop();
                report += FormatTimer(sw.Elapsed.TotalMilliseconds) + $"|{Format(insertion.AsgCounter)}|{Format(insertion.CMPCounter)}||";
            }
            else
            {
                report += "не запускался".PadLeft(12 * 3 - 2) + "||";
            }

            sw = new Stopwatch();
            insertion = new Insertion(GetCopyMass(count));
            if (massForTests[count].Length <= 100000)
            {
                sw.Start();
                // insertion.Shift();
                sw.Stop();
                report += FormatTimer(sw.Elapsed.TotalMilliseconds) + $"|{Format(insertion.AsgCounter)}|{Format(insertion.CMPCounter)}||";
            }
            else
            {
                report += "не запускался".PadLeft(12 * 3 - 2) + "||";
            }

            sw = new Stopwatch();
            insertion = new Insertion(GetCopyMass(count));
            if (massForTests[count].Length <= 100000)
            {
                sw.Start();
                //insertion.Dichotomy();
                sw.Stop();
                report += FormatTimer(sw.Elapsed.TotalMilliseconds) + $"|{Format(insertion.AsgCounter)}|{Format(insertion.CMPCounter)}||";
            }
            else
            {
                report += "не запускался".PadLeft(12 * 3 - 2) + "||";
            }

            reports1.Add(report);
            report = "";

            sw = new Stopwatch();
            Shell shell = new Shell(GetCopyMass(count));
            sw.Start();
            // shell.Basic();
            sw.Stop();
            report += FormatTimer(sw.Elapsed.TotalMilliseconds) + $"|{Format(shell.AsgCounter)}|{Format(shell.CMPCounter)}||";

            sw = new Stopwatch();
            shell = new Shell(GetCopyMass(count));
            sw.Start();
            // shell.Hibbard();
            sw.Stop();
            report += FormatTimer(sw.Elapsed.TotalMilliseconds) + $"|{Format(shell.AsgCounter)}|{Format(shell.CMPCounter)}||";

            sw = new Stopwatch();
            shell = new Shell(GetCopyMass(count));
            sw.Start();
            //shell.Pratt();
            sw.Stop();
            report += FormatTimer(sw.Elapsed.TotalMilliseconds) + $"|{Format(shell.AsgCounter)}|{Format(shell.CMPCounter)}||";

            sw = new Stopwatch();
            shell = new Shell(GetCopyMass(count));
            sw.Start();
            //  shell.Tsiur();
            sw.Stop();
            report += FormatTimer(sw.Elapsed.TotalMilliseconds) + $"|{Format(shell.AsgCounter)}|{Format(shell.CMPCounter)}||";

            reports2.Add(report);
            report = "";

            sw = new Stopwatch();
            Selection selection = new Selection(GetCopyMass(count));
            if (massForTests[count].Length <= 100000)
            {
                sw.Start();
                //selection.Basic();
                sw.Stop();
                report += FormatTimer(sw.Elapsed.TotalMilliseconds) + $"|{Format(selection.AsgCounter)}|{Format(selection.CMPCounter)}||";
            }
            else
            {
                report += "не запускался".PadLeft(12 * 3 - 2) + "||";
            }

            sw = new Stopwatch();
            Heap heap = new Heap(GetCopyMass(count));
            sw.Start();
            heap.Basic();
            sw.Stop();
            report += FormatTimer(sw.Elapsed.TotalMilliseconds) + $"|{Format(heap.AsgCounter)}|{Format(heap.CMPCounter)}||";

            sw = new Stopwatch();
            QuickSort qs = new QuickSort(GetCopyMass(count));
            sw.Start();
            qs.Sort();
            sw.Stop();
            report += FormatTimer(sw.Elapsed.TotalMilliseconds) + $"|{Format(qs.AsgCounter)}|{Format(qs.CMPCounter)}||";


            sw = new Stopwatch();
            MergeSort ms = new MergeSort(GetCopyMass(count));
            sw.Start();
            ms.Sort();
            sw.Stop();
            report += FormatTimer(sw.Elapsed.TotalMilliseconds) + $"|{Format(ms.AsgCounter)}|{Format(ms.CMPCounter)}||";

            reports3.Add(report);
            count++;
        }

        int temp = 34;
        string hat =
            "Size".PadRight(12) +
            "||" + "Basic Bubble".PadRight(temp) +
            "||" + "Modern Bubble".PadRight(temp) +
            "||" + "Basic Insertion".PadRight(temp) +
            "||" + "Shift Insertion".PadRight(temp) +
            "||" + "Binary Insertion".PadRight(temp) +
            "||";
        Console.WriteLine(hat);
        Console.WriteLine(
            "".PadLeft(12) + "||" +
            "time, ms".PadLeft(8) + "|" + "assig.".PadLeft(12) + "|" + "cmp.".PadLeft(12) + "||" +
            "time, ms".PadLeft(8) + "|" + "assig.".PadLeft(12) + "|" + "cmp.".PadLeft(12) + "||" +
            "time, ms".PadLeft(8) + "|" + "assig.".PadLeft(12) + "|" + "cmp.".PadLeft(12) + "||" +
            "time, ms".PadLeft(8) + "|" + "assig.".PadLeft(12) + "|" + "cmp.".PadLeft(12) + "||" +
            "time, ms".PadLeft(8) + "|" + "assig.".PadLeft(12) + "|" + "cmp.".PadLeft(12) +
            "||"
            );
        Console.WriteLine("-".PadRight(hat.Length, '-'));
        for (int i = 0; i < reports1.Count; i++)
        {
            Console.WriteLine(Format(sizes[i]) + "||" + reports1[i]);
        }
        Console.WriteLine();

        hat = "Size".PadRight(12) +
            "||" + "Shell Basic".PadRight(temp) +
            "||" + "Shell - Hibbard".PadRight(temp) +
            "||" + "Shell - Pratt".PadRight(temp) +
            "||" + "Shell - Tsiur".PadRight(temp) +
            "||";
        Console.WriteLine(hat);
        Console.WriteLine(
            "".PadLeft(12) + "||" +
            "time, ms".PadLeft(8) + "|" + "assig.".PadLeft(12) + "|" + "cmp.".PadLeft(12) + "||" +
            "time, ms".PadLeft(8) + "|" + "assig.".PadLeft(12) + "|" + "cmp.".PadLeft(12) + "||" +
            "time, ms".PadLeft(8) + "|" + "assig.".PadLeft(12) + "|" + "cmp.".PadLeft(12) + "||" +
            "time, ms".PadLeft(8) + "|" + "assig.".PadLeft(12) + "|" + "cmp.".PadLeft(12) + "||"
            );
        Console.WriteLine("-".PadRight(hat.Length, '-'));
        for (int i = 0; i < reports2.Count; i++)
        {
            Console.WriteLine(Format(sizes[i]) + "||" + reports2[i]);
        }

        Console.WriteLine();

        hat = "Size".PadRight(12) +
            "||" + "Selection".PadRight(temp) +
            "||" + "HeapSort".PadRight(temp) +
            "||" + "QuickSort".PadRight(temp) +
            "||" + "MergeSort".PadRight(temp);
        Console.WriteLine(hat);
        Console.WriteLine(
            "".PadLeft(12) + "||" +
            "time, ms".PadLeft(8) + "|" + "assig.".PadLeft(12) + "|" + "cmp.".PadLeft(12) + "||" +
            "time, ms".PadLeft(8) + "|" + "assig.".PadLeft(12) + "|" + "cmp.".PadLeft(12) + "||" +
            "time, ms".PadLeft(8) + "|" + "assig.".PadLeft(12) + "|" + "cmp.".PadLeft(12) + "||" +
            "time, ms".PadLeft(8) + "|" + "assig.".PadLeft(12) + "|" + "cmp.".PadLeft(12) + "||"
            );
        Console.WriteLine("-".PadRight(hat.Length, '-'));
        for (int i = 0; i < reports3.Count; i++)
        {
            Console.WriteLine(Format(sizes[i]) + "||" + reports3[i]);
        }
    }

    static long[][] massForTests;
    static long[] sizes;
    static void GetMassForTests()
    {
        sizes = new long[] { (long)Math.Pow(10, 2), (long)Math.Pow(10, 3), (long)Math.Pow(10, 4), (long)Math.Pow(10, 5), (long)Math.Pow(10, 6) };
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
    static string Format(long l)
    {
        return l.ToString().PadLeft(12);
    }
    static string FormatTimer(double d)
    {
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
