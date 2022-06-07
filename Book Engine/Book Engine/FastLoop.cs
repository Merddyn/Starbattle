using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Book_Engine
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Message
    {
        public IntPtr hWnd;
        public Int32 msg;
        public IntPtr wParam;
        public IntPtr lParam;
        public uint time;
        public System.Drawing.Point p;
    }

    public class FastLoop
    {
        PreciseTimer _timer = new PreciseTimer();
      
        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool PeekMessage(
            out Message msg,
            IntPtr hWnd,
            uint MessageFilterMin,
            uint MessageFilterMax,
            uint flags);

        public delegate void LoopCallback(double elapsedTime);
        LoopCallback _callback;

        public FastLoop(LoopCallback callback)
        {
            _callback = callback;
            Application.Idle += new EventHandler(OnApplicationEnterIdle);
        }
        void OnApplicationEnterIdle(object sender, EventArgs e)
        {
            while (IsAppStillIdle())
            {
                _callback(_timer.GetElapsedTime());
            }
        }
        private bool IsAppStillIdle()
        {
            Message msg;
            return !PeekMessage(out msg, IntPtr.Zero, 0, 0, 0);
        }
    
    }
}
