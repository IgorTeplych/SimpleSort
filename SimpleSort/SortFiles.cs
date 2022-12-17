using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSort
{
    internal class SortFiles
    {
        int N;
        string pathSplit = Environment.CurrentDirectory + @"\Directory\Split\";
        string pathMerge = Environment.CurrentDirectory + @"\Directory\Merge\";
        string path = Environment.CurrentDirectory + @"\Directory\";
        public SortFiles()
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
            File.WriteAllLines(path + name + ".txt", GetMass(N, T));
        }
        public void Split(int size, string name = "name1")
        {
            int countA = 0;
            var mainTask = Task.Factory.StartNew(() =>
            {
                while (countA < (N - (N % size)))
                {
                    int _size = size;
                    int _countA = countA;
                    string pathTarget = pathSplit + name + countA + ".txt";
                    var task = Task.Factory.StartNew(() =>
                    {
                        string pathSource = path + name + ".txt";
                        string[] numbers = new string[size];
                        int countB = 0;
                        while (countB < _size)
                        {
                            numbers[countB] = File.ReadLines(pathSource).ElementAtOrDefault(_countA + countB);
                            countB++;
                        }
                        File.WriteAllLines(pathTarget, numbers);
                    }, TaskCreationOptions.AttachedToParent);
                    countA += size;
                }
            });
            mainTask.Wait();

            if (countA == N)
                return;
            string[] numbers = new string[size];
            int countB = 0;
            string pathTarget = pathSplit + name + countA + ".txt";
            numbers = new string[N % size];
            while (countB < ((N % size)))
            {
                numbers[countB] = File.ReadLines(path + name + ".txt").ElementAtOrDefault(countA + countB);
                countB++;
            }
            File.WriteAllLines(pathTarget, numbers);
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

        public void Sort()
        {
            SortAndMerge(Directory.GetFiles(pathSplit), 1);
        }

        public void SortAndMerge(string[] pathInputFiles, int countMergeLayer)
        {
            if (pathInputFiles.Length == 1)
                return;

            string newPathMerge = pathMerge + @"" + countMergeLayer + @"\";
            Directory.CreateDirectory(newPathMerge);

            int countMerge = 0;
            var mainTask = Task.Factory.StartNew(() =>
            {
                while (countMerge + 1 < pathInputFiles.Length)
                {
                    string pathFile1 = pathInputFiles[countMerge];
                    string pathFile2 = pathInputFiles[countMerge + 1];
                    string pathTarget = newPathMerge + $"merge{countMerge}.txt";
                    var task = Task.Factory.StartNew(() =>
                    {
                        Merge(pathFile1, pathFile2, pathTarget);
                    }, TaskCreationOptions.AttachedToParent);
                    countMerge += 2;
                }
            });
            mainTask.Wait();


            if (pathInputFiles.Length % 2 != 0)
            {
                string[] newPathFiles = Directory.GetFiles(newPathMerge);
                var _pathInputFiles = new string[newPathFiles.Length + 1];

                int i = 0;
                for (i = 0; i < newPathFiles.Length; i++)
                {
                    _pathInputFiles[i] = newPathFiles[i];
                }
                _pathInputFiles[i] = pathInputFiles[countMerge];
                SortAndMerge(_pathInputFiles, ++countMergeLayer);
            }
            else
            {
                pathInputFiles = Directory.GetFiles(newPathMerge);
                SortAndMerge(pathInputFiles, ++countMergeLayer);
            }
        }
        public void Merge(string pathFile1, string pathFile2, string pathMerge)
        {
            int count1 = 0;
            int count2 = 0;
            string? num1 = File.ReadLines(pathFile1).ElementAtOrDefault(count1);
            string? num2 = File.ReadLines(pathFile2).ElementAtOrDefault(count2);
            long num1l = long.Parse(num1);
            long num2l = long.Parse(num2);

            while (num1 != null && num2 != null)
            {
                if (long.Parse(num1) < long.Parse(num2))
                {
                    File.AppendAllText(pathMerge, num1 + Environment.NewLine);
                    num1 = File.ReadLines(pathFile1).ElementAtOrDefault(++count1);
                }
                else
                {
                    File.AppendAllText(pathMerge, num2 + Environment.NewLine);
                    num2 = File.ReadLines(pathFile2).ElementAtOrDefault(++count2);
                }
            }
            while (num1 != null)
            {
                File.AppendAllText(pathMerge, num1 + Environment.NewLine);
                num1 = File.ReadLines(pathFile1).ElementAtOrDefault(++count1);
            }
            while (num2 != null)
            {
                File.AppendAllText(pathMerge, num2 + Environment.NewLine);
                num2 = File.ReadLines(pathFile2).ElementAtOrDefault(++count2);
            }
        }


        static Random random = new Random();
        string[] GetMass(long N, int T)
        {
            string[] mass = new string[N];
            long count = 0;

            while (count < N)
                mass[count++] = random.Next(1, T).ToString();

            return mass;
        }
    }
}
