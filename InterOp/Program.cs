using System.Runtime.InteropServices;
using System.Text;
using System.Diagnostics;
using System.Management;
using System.Reflection;
using InterOp.HomeWork;
using System.Reflection.Metadata;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.Data.Sqlite;
using Dapper;

namespace InterOp
{
    public class NativeMethods
    {
        [DllImport("kernel32.dll")]
        public static extern bool Beep(uint dwFreq, uint dwDuration);


        [DllImport("msvcrt.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int printf(string format, int i, string str);

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        public static extern int MessageBox(IntPtr nWnd, string text, string caption, uint type);
        [DllImport("user32.dll", EntryPoint = "MessageBox")]
        public static extern int MessageBoxbase(IntPtr nWnd, string text, string caption, uint type);
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

        public static async Task Main()
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
            #region ClassWork Async/ThreadPool
            //ThreadPool.QueueUserWorkItem(DoWork, "File 1");
            //ThreadPool.QueueUserWorkItem(DoWork, "File 2");

            //Console.ReadKey();


            //ThreadPool.QueueUserWorkItem(DoWork, "File 1");
            //ThreadPool.QueueUserWorkItem(DoWork, "File 2");
            //ThreadPool.QueueUserWorkItem(DoWork, "File 3");
            //ThreadPool.QueueUserWorkItem(DoWork, "File 4");

            //Console.WriteLine($"Thread pool count: {ThreadPool.ThreadCount}");
            //Console.WriteLine($"Thread pending pool count: {ThreadPool.PendingWorkItemCount}");
            //Console.WriteLine($"Thread completed count: {ThreadPool.CompletedWorkItemCount}");

            //Thread.Sleep(5000);

            //ThreadPool.QueueUserWorkItem(DoWork, "File 5");
            //ThreadPool.QueueUserWorkItem(DoWork, "File 6");
            //ThreadPool.QueueUserWorkItem(DoWork, "File 7");
            //ThreadPool.QueueUserWorkItem(DoWork, "File 8");

            //Console.WriteLine($"Thread pool count: {ThreadPool.ThreadCount}");
            //Console.WriteLine($"Thread pending pool count: {ThreadPool.PendingWorkItemCount}");
            //Console.WriteLine($"Thread completed count: {ThreadPool.CompletedWorkItemCount}");

            //Console.ReadKey();


            //Task task = SayHelloAsync();

            //Console.WriteLine($"thread {Thread.CurrentThread.ManagedThreadId}");

            //await task;

            //Console.WriteLine("Task finished");

            //Console.ReadKey();


            //var sw = Stopwatch.StartNew();

            //Console.WriteLine($"Main запущено на потоці {Thread.CurrentThread.ManagedThreadId}");

            //Task t1 = SimulateWorkAsync("Задача 1", 2000);
            //Task t2 = SimulateWorkAsync("Задача 2", 2000);
            //Task t3 = SimulateWorkAsync("Задача 3", 2000);

            //Console.WriteLine("Усі задачі запущено паралельно");

            //await Task.WhenAll(t1, t2, t3);

            //Console.WriteLine($"Час (асинхронно): {sw.Elapsed.TotalSeconds} сек");

            //Console.WriteLine("Усі задачі завершено");

            //sw = Stopwatch.StartNew();

            //await SimulateWorkAsync("Задача 1", 2000);
            //await SimulateWorkAsync("Задача 2", 2000);
            //await SimulateWorkAsync("Задача 3", 2000);

            //Console.WriteLine($"Час (по черзі): {sw.Elapsed.TotalSeconds} сек");


            //string connString = "Data Source=test.db";

            //using var connection = new SqliteConnection(connString);
            //await connection.OpenAsync();

            //await connection.ExecuteAsync("DROP TABLE IF EXISTS Users;");

            //await connection.ExecuteAsync("""
            //    CREATE TABLE IF NOT EXISTS Users (
            //        Id INTEGER PRIMARY KEY AUTOINCREMENT,
            //        Name TEXT NOT NULL,
            //        Role TEXT NOT NULL
            //    );
            //""");

            //// Якщо таблиця порожня — заповнюємо
            //int count = await connection.ExecuteScalarAsync<int>("SELECT COUNT(*) FROM Users");
            //if (count == 0)
            //{
            //    Console.WriteLine("Заповнюємо базу користувачами...");

            //    var roles = new[] { "admin", "guest", "mod" };
            //    var insertQuery = "INSERT INTO Users (Name, Role) VALUES (@Name, @Role)";

            //    for (int i = 1; i <= 100; i++)
            //    {
            //        await connection.ExecuteAsync(insertQuery, new
            //        {
            //            Name = $"User_{i}",
            //            Role = roles[i % roles.Length]
            //        });
            //    }

            //    Console.WriteLine("Користувачі додані.");
            //}

            //Console.WriteLine("Паралельно завантажуємо користувачів за ролями...");

            //var adminTask = connection.QueryAsync<User>("SELECT * FROM Users WHERE Role = 'admin'");
            //var guestTask = connection.QueryAsync<User>("SELECT * FROM Users WHERE Role = 'guest'");
            //var modTask = connection.QueryAsync<User>("SELECT * FROM Users WHERE Role = 'mod'");

            //await Task.WhenAll(adminTask, guestTask, modTask);

            //Console.WriteLine("\nАдміни:");
            //foreach (var user in adminTask.Result)
            //    Console.WriteLine($"- {user.Name}");

            //Console.WriteLine("\nГості:");
            //foreach (var user in guestTask.Result)
            //    Console.WriteLine($"- {user.Name}");

            //Console.WriteLine("\nМодератори:");
            //foreach (var user in modTask.Result)
            //    Console.WriteLine($"- {user.Name}");

            #endregion

           
        }

        

        static async Task SimulateWorkAsync(string name, int delayMs)
        {
            Console.WriteLine($"{name} почалась (потік {Thread.CurrentThread.ManagedThreadId})");
            await Task.Delay(delayMs);
            Console.WriteLine($"{name} завершена (потік {Thread.CurrentThread.ManagedThreadId})");
        }

        static async Task SayHelloAsync()
        {
            Console.WriteLine($"Start — thread {Thread.CurrentThread.ManagedThreadId}");
            await Task.Delay(2000);
            Console.WriteLine($"Hello after delay — thread {Thread.CurrentThread.ManagedThreadId}");
        }


        static void DoWork(object? data)
        {
            Console.WriteLine($"Working on: {data}. Id: {Thread.CurrentThread.ManagedThreadId}");
            Thread.Sleep(2000);
            Console.WriteLine($"Work on {data} is finished");
        }

        private static void MenuEcryption()
        {
            Console.WriteLine("Encrypting key: ");
            int key = int.Parse(Console.ReadLine());
            Dictionary<Thread, string> dict = new Dictionary<Thread, string>();

            while (true)
            {
                string Path = string.Empty;
                Console.WriteLine("Add file path - 1\n Start encryption - 2\n 0 - Quit");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Path: ");
                        Path = Console.ReadLine();
                        dict.Add(new Thread((p) => EncryptFile((string)p, key)), Path);
                        break;
                    case "2":
                        if (dict.Count == 0)
                        {
                            Console.WriteLine("Dict is empty");
                            break;
                        }
                        foreach (Thread trd in dict.Keys)
                        {
                            string path = dict[trd];
                            trd.Start(path);
                            Console.WriteLine($"{path} encrypting started. Thread hash-code: {trd.GetHashCode()}");
                        }
                        break;
                    default:
                        Console.WriteLine("incorrect input");
                        break;
                }
                if (choice == "0")
                    break;
            }
        }

        private static void EncryptFile(string path, int key)
        {
            StringBuilder sb = new StringBuilder();
            using (StreamReader sw = new StreamReader(path))
            {
                List<char> encryptedChars = sw.ReadToEnd().ToList<char>();
                encryptedChars.ForEach(ch => sb.Append((char)(ch + key)));
            }
            using(StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine(sb.ToString());
            }
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
