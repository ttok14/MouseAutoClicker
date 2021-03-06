﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MouseClicker
{
    public class MouseCallBack
    {
        public static Action<int, int> onLeftMouseDown;
        public static Action<int, int> onRightMouseDown;
        public static Action<int, int> onWheelDown;
        public static Action<int, int> onWheelUp;
    }

    static class Program
    {
        private static LowLevelMouseProc _proc = HookCallback;
        private static IntPtr _hookID = IntPtr.Zero;

        static void OnLeftMouseDown(POINT cursorPos)
        {
            if (MouseCallBack.onLeftMouseDown != null)
            {
                MouseCallBack.onLeftMouseDown(Cursor.Position.X, Cursor.Position.Y);
            }
        }

        static void OnRightMouseDown(POINT cursorPos)
        {
            if (MouseCallBack.onRightMouseDown != null)
            {
                MouseCallBack.onRightMouseDown(Cursor.Position.X, Cursor.Position.Y);
            }
        }

        static void OnMouseWheelDown(POINT cursorPos)
        {
            if (MouseCallBack.onWheelDown != null)
            {
                MouseCallBack.onWheelDown(Cursor.Position.X, Cursor.Position.Y);
            }
        }

        static void OnMouseWheelUp(POINT cursorPos)
        {
            if (MouseCallBack.onWheelUp != null)
            {
                MouseCallBack.onWheelUp(Cursor.Position.X, Cursor.Position.Y);
            }
        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            _hookID = SetHook(_proc);
            Application.Run(new Form1());
            UnhookWindowsHookEx(_hookID);
        }

        private static IntPtr SetHook(LowLevelMouseProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_MOUSE_LL, proc,
                    GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        private delegate IntPtr LowLevelMouseProc(int nCode, IntPtr wParam, IntPtr lParam);

        private static IntPtr HookCallback(
            int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 &&
                MouseMessages.WM_LBUTTONDOWN == (MouseMessages)wParam)
            {
                OnLeftMouseDown(new POINT() { x = Cursor.Position.X, y = Cursor.Position.Y });
                MSLLHOOKSTRUCT hookStruct = (MSLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(MSLLHOOKSTRUCT));
                Console.WriteLine(hookStruct.pt.x + ", " + hookStruct.pt.y);
            }
            else if (nCode >= 0 &&
               MouseMessages.WM_RBUTTONDOWN == (MouseMessages)wParam)
            {
                OnRightMouseDown(new POINT() { x = Cursor.Position.X, y = Cursor.Position.Y });
            }
            else if (nCode >= 0 &&
               MouseMessages.WM_WHEELDOWN == (MouseMessages)wParam)
            {
                OnMouseWheelDown(new POINT() { x = Cursor.Position.X, y = Cursor.Position.Y });
            }
            else if (nCode >= 0 &&
                            MouseMessages.WM_WHEELUP == (MouseMessages)wParam)
            {
                OnMouseWheelUp(new POINT() { x = Cursor.Position.X, y = Cursor.Position.Y });
            }

            return CallNextHookEx(_hookID, nCode, wParam, lParam);
        }

        private const int WH_MOUSE_LL = 14;

        private enum MouseMessages
        {
            WM_LBUTTONDOWN = 0x0201,
            WM_LBUTTONUP = 0x0202,
            WM_MOUSEMOVE = 0x0200,
            WM_MOUSEWHEELMOVE = 0x020A,
            WM_RBUTTONDOWN = 0x0204,
            WM_RBUTTONUP = 0x0205,
            WM_WHEELDOWN = 0x207,
            WM_WHEELUP = 0x208,
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct POINT
        {
            public int x;
            public int y;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct MSLLHOOKSTRUCT
        {
            public POINT pt;
            public uint mouseData;
            public uint flags;
            public uint time;
            public IntPtr dwExtraInfo;
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook,
            LowLevelMouseProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode,
            IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);
    }
}
