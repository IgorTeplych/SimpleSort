using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSort
{
    internal class Files
    {
        int N;
        string pathSplit = Environment.CurrentDirectory + @"\Directory\Split\";
        string pathMerge = Environment.CurrentDirectory + @"\Directory\Merge\";
        string path = Environment.CurrentDirectory + @"\Directory\";
        public Files()
        {
            if (Directory.Exists(path))
                Directory.Delete(path, true);

            if (!Directory.Exists(pathMerge))
                Directory.CreateDirectory(pathMerge);

            if (!Directory.Exists(pathSplit))
                Directory.CreateDirectory(pathSplit);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="N">Размер массива</param>
        /// <param name="T">Максимальное случайное число</param>
        /// <param name="name"></param>
        public void Generate(int N, int T, string name = "name1")
        {
            this.N = N;
            WriteToFile(GetMass(N, T), path, name);
        }
        public void Split(int size, string name = "name1")
        {
            int countA = 0;
            int countB = 0;
            string s = "";
            while (countA < (N - (N % size)))
            {
                countB = 0;
                while (countB < size - 1)
                {
                    s = ReadLine(path + name + ".txt", countA + countB);
                    WriteLineToFile(s + Environment.NewLine, pathSplit, name + countA.ToString());
                    countB++;
                }
                s = ReadLine(path + name + ".txt", countA + countB);
                WriteLineToFile(s, pathSplit, name + countA.ToString());
                countA += size;
            }

            if (countA == N)
                return;

            countB = 0;
            while (countB < ((N % size) - 1))
            {
                s = ReadLine(path + name + ".txt", countA + countB);
                WriteLineToFile(s + Environment.NewLine, pathSplit, name + countA.ToString());
                countB++;
            }
            s = ReadLine(path + name + ".txt", countA + countB);
            WriteLineToFile(s, pathSplit, name + countA.ToString());
        }


        public void SortContentSplitFiles(Func<long[], long[]> sortMethod)
        {
            var mainTask = Task.Factory.StartNew(() =>
            {
                var files = Directory.GetFiles(pathSplit);
                foreach (var item in files)
                {
                    var task = Task.Factory.StartNew(() =>
                    {
                        string[] arr = File.ReadAllLines(item);
                        long[] longs = sortMethod.Invoke(Array.ConvertAll(arr, long.Parse));
                        File.WriteAllLines(item, Array.ConvertAll(longs, Convert.ToString));
                    }, TaskCreationOptions.AttachedToParent);
                }
            });
            mainTask.Wait();
        }


        public void Merge()
        {
            Merge(Directory.GetFiles(pathSplit), pathMerge);
        }

        public void Merge(string[] pathFiles, string pathFilesMerge)
        {
            string nameMerge = "m1";
            string nameMergeDirectory = "";

            int countFile1 = 0;
            int countFile2 = 1;

            int count1 = 0;
            int count2 = 0;
            string? num1 = ReadLine(pathFiles[countFile1], count1);
            string? num2 = ReadLine(pathFiles[countFile2], count2);
            long num1l = long.Parse(num1);
            long num2l = long.Parse(num2);

            while (num1 != null && num2 != null)
            {
                if (long.Parse(num1) < long.Parse(num2))
                {
                    WriteLineToFile(num1 + Environment.NewLine, pathMerge, nameMerge);
                    num1 = ReadLine(pathFiles[countFile1], ++count1);
                }
                else
                {
                    WriteLineToFile(num2 + Environment.NewLine, pathMerge, nameMerge);
                    num2 = ReadLine(pathFiles[countFile2], ++count2);
                }
            }
            while (num1 != null)
            {
                WriteLineToFile(num2 + Environment.NewLine, pathMerge, nameMerge);
                num1 = ReadLine(pathFiles[countFile1], ++count1);
            }
            while (num2 != null)
            {
                WriteLineToFile(num2 + Environment.NewLine, pathMerge, nameMerge);
                num2 = ReadLine(pathFiles[countFile2], ++count2);
            }
        }


        //          Создаем параллельную задачу
        //    Читаем из первого файла первый элемент
        //    Читаем из второго файла первый элемент
        //    Сравниваем первые два элемента
        //    Помещаем наибольший элемент в файл Merge1.txt
        //          завершаем параллельную задачу


        //СОРТИРУЕМ МАССИВЫ






        void WriteLineToFile(string s, string path, string name = "name1")
        {
            File.AppendAllText(path + name + ".txt", s.ToString());
        }
        void WriteToFile(long[] mass, string path, string name = "name1")
        {
            for (long i = 0; i < mass.Length - 1; i++)
                File.AppendAllText(path + name + ".txt", mass[i].ToString() + Environment.NewLine);

            File.AppendAllText(path + name + ".txt", mass[mass.Length - 1].ToString());
        }
        string? ReadLine(string path, int line)
        {
            return File.ReadLines(path).ElementAtOrDefault(line);
        }
        static Random random = new Random();
        long[] GetMass(long N, int T)
        {
            long[] mass = new long[N];
            long count = 0;

            while (count < N)
                mass[count++] = random.Next(1, T);

            return mass;
        }
    }
}
