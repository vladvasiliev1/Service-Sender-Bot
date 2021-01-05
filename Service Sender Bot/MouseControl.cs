using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;
using System.Runtime.CompilerServices;

namespace Service_Sender_Bot
{
    static class MouseControl
    {
        [DllImport("user32.dll")]
        static extern void mouse_event(uint dwFlags, int dx, int dy, uint dwData,
   UIntPtr dwExtraInfo);

        const uint MOUSEEVENTF_ABSOLUTE = 0x8000;
        const uint MOUSEEVENTF_LEFTDOWN = 0x0002;
        const uint MOUSEEVENTF_LEFTUP = 0x0004;

        static bool IsWork = false;

        public async static void Start()
        {
            await Task.Run(() => 
            {
                if (!IsWork)
                {
                    IsWork = true;

                    MouseClick(769, 132);

                    Thread.Sleep(5000);

                    MouseClick(675, 385);

                    Thread.Sleep(2000);

                    MouseClick(276, 541);

                    Thread.Sleep(10000);

                    MouseClick(769, 132);

                    //while (IsWork)
                    //{
                    //    MouseClick(574, 379);

                    //    MouseClick(435, 517);

                    //    Thread.Sleep(2000);

                    //    MouseClick(769, 132);

                    //    Thread.Sleep(2000);

                    //    MouseClick(675, 382);

                    //    MouseClick(435, 517);

                    //    Thread.Sleep(2000);

                    //    MouseClick(769, 132);

                    //    Thread.Sleep(2000);

                    //    MouseClick(772, 384);

                    //    MouseClick(435, 517);

                    //    Thread.Sleep(2000);

                    //    MouseClick(769, 132);

                    //    Thread.Sleep(2000);

                    //    MouseClick(623, 472);

                    //    MouseClick(435, 517);

                    //    Thread.Sleep(2000);

                    //    MouseClick(769, 132);

                    //    Thread.Sleep(2000);

                    //    MouseClick(729, 470);

                    //    MouseClick(435, 517);

                    //    Thread.Sleep(2000);

                    //    MouseClick(769, 132);

                    //    Thread.Sleep(2000);
                    //}
                }
            });
        }

        public static void Stop()
        {
            IsWork = false;
        }

        static void MouseClick(int x,int y)
        {
            Cursor.Position = new Point(x, y);

            Thread.Sleep(1000);

            mouse_event(MOUSEEVENTF_LEFTDOWN, x, y, 0, UIntPtr.Zero);
            mouse_event(MOUSEEVENTF_LEFTUP, x, y, 0, UIntPtr.Zero);
        }
    }
}
