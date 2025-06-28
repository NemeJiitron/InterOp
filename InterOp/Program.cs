using System.Runtime.InteropServices;
using System.Text;
using System.Diagnostics;
using System.Management;
using System.Reflection;
using InterOp.HomeWork;

namespace InterOp
{
    public class NativeMethods
    {
        [DllImport("kernel32.dll")]
        public static extern bool Beep(uint dwFreq, uint dwDuration);


        [DllImport("msvcrt.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int printf(string format, int i, string str);

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        public static extern int MessageBox(IntPtr nWnd, String text, string caption, uint type);
        [DllImport("user32.dll", EntryPoint = "MessageBox")]
        public static extern int MessageBoxbase(IntPtr nWnd, String text, string caption, uint type);
        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, string lParam);

    }


    internal class Program
    {
        public static int GetParentPID(int pid)
        {
            int parentId = 0;
            using (ManagementObject obj = new ManagementObject("win32_process.handle=" + pid.ToString()))
            {
                obj.Get();
                parentId = Convert.ToInt32(obj["ParentProcessId"]);
            }
            return parentId;
        }

        public static void SetTitleText(IntPtr handle, string text)
        {
            NativeMethods.SendMessage(handle, 0x000C, 0, text);
        }

        public static void Main()
        {
            #region ClassWork 2
            //using (Process process = new Process())
            //{
            //    process.StartInfo.FileName = "Notepad.exe";

            //    process.Start();
            //    Console.WriteLine($"Process with PID {process.Id} has started");

            //    if (Process.GetCurrentProcess().Id == GetParentPID(process.Id))
            //    {
            //        Console.WriteLine($"Process #{Process.GetCurrentProcess().Id} is parent for Process #{process.Id}");
            //    }

            //    SetTitleText(process.MainWindowHandle, "Parent text");

            //    //process.WaitForExit();
            //    Console.WriteLine($"Press enter to close");
            //    Console.ReadLine();

            //    if (!process.HasExited)
            //    {
            //        Console.WriteLine($"Process PID {process.Id} closed");
            //        process.CloseMainWindow();
            //        process.Close();

            //    }
            //}
            #endregion
            #region ClassWork Timer/Thread
            //// TIMER
            //Timer timer = new Timer(new TimerCallback(x => Console.WriteLine("TimerCallBack")));

            //timer.Change(2000, 500);

            //Console.ReadKey();

            //timer.Dispose();


            ////Thread

            //Thread thread = new Thread(new ThreadStart(() => { for (int i = 0; i < 1000; i++) Console.WriteLine("\t\t\tHELLO FROM THREAD"); }));

            //thread.Start();

            //for (int i = 0; i <= 1000; i++) Console.WriteLine("hello from main");

            //Thread thread2 = new Thread(new ParameterizedThreadStart(ThreadMethodWithParams));

            //thread2.Start("msg main");

            //Console.WriteLine("Thread sleeping");

            //Thread.Sleep(1000);

            //Console.WriteLine("Thread awake");

            //Thread thread3 = new Thread(() => MethodWithParams("main msg"));

            //thread3.Start();

            //for (int i = 0; i <= 1000; i++) Console.WriteLine("hello from main");

            //Thread thread = new Thread(new ThreadStart(() => 
            //{
            //    for (int i = 0; i < 1000; i++)
            //    {

            //        Console.WriteLine($"\t\t\t{Thread.CurrentThread.GetHashCode()}");
            //        Console.WriteLine("\t\t\tHELLO FROM THREAD");
            //        Thread.Sleep(300);
            //    }
            //}));

            //thread.IsBackground = true;
            //thread.Priority = ThreadPriority.Highest;
            //thread.Start();

            //for (int i = 0; i < 10; i++)
            //{
            //    Console.WriteLine($"Main thread hashcode: {Thread.CurrentThread.GetHashCode()}");
            //    Thread.Sleep(300);
            //}
            //while(Console.ReadKey().Key != ConsoleKey.Escape)
            //{
            //    Console.WriteLine("Press esc to close app");
            //}

            //Thread thread = new Thread(new ThreadStart(() =>
            //{
            //    for (int i = 0; i < 1000; i++)
            //    {

            //        Console.WriteLine($"\t\t\t{Thread.CurrentThread.GetHashCode()}");
            //        Console.WriteLine("\t\t\tHELLO FROM THREAD");
            //        Thread.Sleep(300);
            //    }
            //}));

            //thread.Start();
            //Console.ReadKey();
            //Console.WriteLine("Thread suspended");
            //Console.Beep();
            //Console.ReadKey();
            //Console.WriteLine("Thread resumed");
            #endregion
            

        }


        static void MethodWithParams(string msg)
        {
            Console.WriteLine("\t\t\tHELLO FROM THREAD. Message: " + msg);
        }


        static void ThreadMethodWithParams(object msg)
        {
            Console.WriteLine("\t\t\tHELLO FROM THREAD. Message: " + msg.ToString());
        }

    }
}
