using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterOp
{
    internal class User32Operations
    {
        private static void PrintTimeInNotepad()
        {
            IntPtr hwnd = NativeMethods.FindWindow("Notepad", null);
            if (hwnd != IntPtr.Zero)
            {
                int i = 0;
                while (true)
                {
                    NativeMethods.SendMessage(hwnd, 0x000C, IntPtr.Zero, TimeOnly.FromDateTime(DateTime.Now).ToString());

                    Thread.Sleep(1000);
                    Console.WriteLine($"{++i} seconds past");
                }

            }
            else
            {
                NativeMethods.MessageBoxbase(0, "Notepad isnt found", "Message", (uint)0x00000000L);
            }
        }

        private static void CloseNotepad()
        {
            IntPtr hwnd = NativeMethods.FindWindow("Notepad", null);
            if (hwnd != IntPtr.Zero)
            {
                NativeMethods.SendMessage(hwnd, 0x0010, 0, null);
                NativeMethods.MessageBoxbase(0, "Notepad is closed", "Message", (uint)0x00000000L);
            }
            else
            {
                NativeMethods.MessageBoxbase(0, "Notepad isnt found", "Message", (uint)0x00000000L);
            }
        }

        private static void RandomNumGuesser()
        {
            NativeMethods.MessageBoxbase(0, "Think of number 0 - 100", "Guesser", (uint)0x00000000L);
            Random random = new Random();
            while (true)
            {
                int res = 0;
                if (NativeMethods.MessageBoxbase(0, $"Is your number - {random.Next(0, 101)}", "Guesser", (uint)0x00000004L) == 6)
                {
                    res = NativeMethods.MessageBoxbase(0, "Computer Guessed! Wanna retry?", "Guesser", (uint)0x00000004L);
                }
                else
                {
                    res = NativeMethods.MessageBoxbase(0, "Computer didnt guess! Wanna retry?", "Guesser", (uint)0x00000004L);
                }
                if (res != 6)
                {
                    break;
                }
            }
        }
    }
}
