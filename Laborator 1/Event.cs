using System;
using System.ComponentModel;
using System.Threading;

namespace Lab1
{
    public delegate void MyEventHandler(object source, MyEventArgs e);

    public class MyEventArgs : EventArgs
    {
        private string ThreadName;
        private string TimeStamp;
        private int Number;
        private int Mode;
        private int CommonResource;

        public MyEventArgs(string ThreadName, string TimeStamp, int Number = -1, int Mode = 0, int CommonResource = 0)
        {
            this.ThreadName = ThreadName;
            this.TimeStamp = TimeStamp;
            this.Number = Number;
            this.Mode = Mode;
            this.CommonResource = CommonResource;
        }

        public string Start()
        {
            if (Mode == 1)
                return "Start fir: " + ThreadName + " " + TimeStamp + " Numar natural dat = " + Number + " Resursa comuna este = " + CommonResource;
            else if (Mode == 2)
                return "Iesire temporara fir " + ThreadName + " " + TimeStamp + " Resursa comuna este = " + CommonResource;
            else
                return "End fir: " + ThreadName + " " + TimeStamp + " Numar prim determinat = " + Number + " Resursa comuna este = " + CommonResource;
        }
    }

    public class MyClass
    {
        public event MyEventHandler ThreadHelper;
        public int CommonResource = 1;

        private bool IsPrime(int number)
        {
            bool flag = true;
            for (int i = 2; i <= number / 2 && flag; i++)
            {
                if (number % i == 0)
                {
                    flag = false;
                }
            }
            return flag;
        }

        public void Alg1(int number, string threadName)
        {
            ThreadHelper?.Invoke(this, new MyEventArgs(threadName, DateTime.Now.ToString("HH:mm:ss tt"), number, 1));
            for (int i = number - 1; i > 0; i--)
            {
                CommonResource++;
                if (IsPrime(i))
                {
                    ThreadHelper?.Invoke(this, new MyEventArgs(threadName, DateTime.Now.ToString("HH:mm:ss tt"), i, 3, CommonResource));
                    break;
                }
            }
        }
        
        public void Alg1_2(object sender, DoWorkEventArgs e)
        {
            ThreadHelper?.Invoke(this, new MyEventArgs(Thread.CurrentThread.Name, DateTime.Now.ToString("HH:mm:ss tt"), 3435, 1));
            for (int i = 3435 - 1; i > 0; i--)
            {
                CommonResource++;
                if (IsPrime(i))
                {
                    ThreadHelper?.Invoke(this, new MyEventArgs(Thread.CurrentThread.Name, DateTime.Now.ToString("HH:mm:ss tt"), i, 3, CommonResource));
                    break;
                }
            }
        }

        public void Alg2(int number, string threadName)
        {
            ThreadHelper?.Invoke(this, new MyEventArgs(threadName, DateTime.Now.ToString("HH:mm:ss tt"), number, 1, CommonResource));
            Thread.Sleep(1000);
            for (int i = number - 1; i > 0; i--)
            {
                CommonResource++;
                if (IsPrime(i))
                {
                    ThreadHelper?.Invoke(this, new MyEventArgs(threadName, DateTime.Now.ToString("HH:mm:ss tt"), i, 3, CommonResource));
                    break;
                }
            }
        }
    }

    class Program
    {
        public static void Start(object source, MyEventArgs e)
        {
            Console.WriteLine(e.Start());
        }

        static void Main(string[] args)
        {
            //ex2
            //MyClass myClass = new MyClass();
            //myClass.ThreadHelper += new MyEventHandler(Start);
            //Thread t1 = new Thread(() => myClass.Alg1(3435, "One"));
            //t1.Start();
            //Thread t2 = new Thread(() => myClass.Alg2(5231, "Two"));
            //t2.Start();
            //ex3
            BackgroundWorker _bw;
            MyClass myClass = new MyClass();
            _bw = new BackgroundWorker
            {
                WorkerReportsProgress = true,
                WorkerSupportsCancellation = true
            };
            _bw.DoWork += myClass.Alg1_2;
            _bw.ProgressChanged += 
        }
    }
}