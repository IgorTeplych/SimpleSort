using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Model;
using SimpleSort;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;
using Visualization.Model;

namespace Visualization.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        Dispatcher dispatcher = Dispatcher.CurrentDispatcher;
        Bubble bubble;
        Insertion insertion;
        AlgShell shell;
        Selection selection;
        Heap heap;
        public MainViewModel()
        {
            Rectangles = new ObservableCollection<Rectangle>();
            GenArrayCommand = new RelayCommand(GenArrayMethod);
            BubbleBasicCommand = new RelayCommand(BubbleBasicMethod);
            BubbleModernCommand = new RelayCommand(BubbleModernMethod);
            InsertBasicCommand = new RelayCommand(InsertBasicMethod);
            InsertShiftCommand = new RelayCommand(InsertShiftMethod);
            InsertBinaryCommand = new RelayCommand(InsertBinaryMethod);
            ShellBasicCommand = new RelayCommand(ShellBasicMethod);
            ShellHibbardCommand = new RelayCommand(ShellHibbardMethod);
            ShellPrattCommand = new RelayCommand(ShellPrattMethod);
            SelectionCommand = new RelayCommand(SelectionMethod);
            HeapCommand = new RelayCommand(HeapMethod);
            SizeArray = 50;
            Pause = 50;
            GenArrayMethod();
            CanExecute = true;

            bubble = new Bubble(Paused, () => CanExecute = true);
            insertion = new Insertion(Paused, () => CanExecute = true);
            shell = new AlgShell(Paused, () => CanExecute = true);
            selection = new Selection(Paused, () => CanExecute = true);
            heap = new Heap(Paused, () => CanExecute = true);
        }

        public ObservableCollection<Rectangle> Rectangles { get; set; }
        public RelayCommand GenArrayCommand { get; set; }
        public RelayCommand BubbleBasicCommand { get; set; }
        public RelayCommand BubbleModernCommand { get; set; }
        public RelayCommand InsertBasicCommand { get; set; }
        public RelayCommand InsertShiftCommand { get; set; }
        public RelayCommand InsertBinaryCommand { get; set; }
        public RelayCommand ShellBasicCommand { get; set; }
        public RelayCommand ShellHibbardCommand { get; set; }
        public RelayCommand ShellPrattCommand { get; set; }
        public RelayCommand SelectionCommand { get; set; }
        public RelayCommand HeapCommand { get; set; }
        int _SizeArray;
        public int SizeArray
        {
            get { return _SizeArray; }
            set
            {
                _SizeArray = value;
                RaisePropertyChanged(() => SizeArray);
            }
        }
        int _Pause;
        public int Pause
        {
            get { return _Pause; }
            set
            {
                _Pause = value;
                RaisePropertyChanged(() => Pause);
            }
        }

        bool _CanExecute;
        public bool CanExecute
        {
            get 
            {
                return _CanExecute;
            }
            set
            {
                _CanExecute = value;     
                RaisePropertyChanged(() => CanExecute);
            }
        }

        long[] arr;
        void GenArrayMethod()
        {
            NoSortArr noSortArr = new NoSortArr();
            arr = noSortArr.GetArray(SizeArray, 5, 400);
            RefreshRectangles();
        }
        Task task;
        void BubbleBasicMethod()
        {
            CanExecute = false;
            task = new Task(() =>
            {
                bubble.Basic(arr);
            });
            task.Start();
        }
        void BubbleModernMethod()
        {
            CanExecute = false;
            task = new Task(() =>
            {
                bubble.Modern(arr);
            });
            task.Start();
        }

        void InsertBasicMethod()
        {
            CanExecute = false;
            task = new Task(() =>
            {
                insertion.Basic(arr);
            });
            task.Start();
        }

        void InsertShiftMethod()
        {
            CanExecute = false;
            task = new Task(() =>
            {
                insertion.Shift(arr);
            });
            task.Start();
        }

        void InsertBinaryMethod()
        {
            CanExecute = false;
            task = new Task(() => insertion.Dichotomy(arr));
            task.Start();
        }

        void ShellBasicMethod()
        {
            CanExecute = false;
            task = new Task(() => shell.Basic(arr));
            task.Start();
        }
        void ShellHibbardMethod()
        {
            CanExecute = false;
            task = new Task(() => shell.Hibbard(arr));
            task.Start();
        }
        void ShellPrattMethod()
        {
            CanExecute = false;
            task = new Task(() => shell.Pratt(arr));
            task.Start();
        }
        void SelectionMethod()
        {
            CanExecute = false;
            task = new Task(() => selection.Basic(arr));
            task.Start();
        }
        void HeapMethod()
        {
            CanExecute = false;
            task = new Task(() => heap.Basic(arr));
            task.Start();
        }



        void RefreshRectangles()
        {
            Rectangles.Clear();
            foreach (var item in arr)
            {
                Rectangle rectangle = new Rectangle();
                rectangle.Height = item;
                rectangle.Width = 5;
                Rectangles.Add(rectangle);
            }
        }


        void Paused()
        {
            dispatcher.Invoke(() =>
            {
                RefreshRectangles();
            });
            Thread.Sleep(Pause);
        }
    }
}