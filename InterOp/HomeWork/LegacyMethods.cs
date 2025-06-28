using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterOp.HomeWork
{
    internal class LegacyMethods
    {

        public static void ShowPersonalData()
        {
            NativeMethods.MessageBox(0, "Matthew", "Name", 0);
            NativeMethods.MessageBox(0, "Tkachuk", "Lastname", 0);
            NativeMethods.MessageBox(0, "17", "Age", 0);
        }

        public static void NotepadActions()
        {

        }
    }
}
