using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Media;


namespace MouseClicker
{
    partial class Form1 : Form
    {
        //사용할 API함수를 임포트 한다.
        [DllImport("USER32.DLL")]
        public static extern uint FindWindow(string lpClassName,
            string lpWindowName);

        [DllImport("user32.dll")]
        static extern bool GetWindowRect(int hWnd, out RECT lpRect);

        [DllImport("user32.dll")]
        public static extern uint FindWindowEx(uint hWnd1, uint hWnd2, string lpsz1, string lpsz2);

        [DllImport("user32.dll")]
        public static extern uint SendMessage(uint hwnd, uint wMsg, uint wParam, uint lParam);

        [DllImport("user32.dll")]
        public static extern uint PostMessage(uint hwnd, uint wMsg, uint wParam, uint lParam);

        [DllImport("user32.dll")]
        static extern bool GetCursorPos(ref Point lpPoint);

        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
        public static extern int BitBlt(IntPtr hDC, int x, int y, int nWidth, int nHeight, IntPtr hSrcDC, int xSrc, int ySrc, int dwRop);


        uint handle;

      public struct RECT
        {
            public int Left;        // x position of upper-left corner
            public int Top;         // y position of upper-left corner
            public int Right;       // x position of lower-right corner
            public int Bottom;      // y position of lower-right corner

            public override string ToString()
            {
                return Left.ToString() + " , " + Top.ToString() + " , " + Left.ToString() + " , " + Bottom.ToString();
            }
        }

        public void Initialize_HandleOtherWindow()
        {
            return;

            RECT rect;
            int hwnd = ((IntPtr)FindWindow(null, "Nox")).ToInt32();
            GetWindowRect(hwnd, out rect);

        //    label5.Text = rect.ToString();
        }

        public void Update_HandleOtherWindow(TimeSpan deltaTime)
        {
            /*    
             *    윈도우 핸들 가져와서 크기 가져오기 
             *    RECT rect;
                int hwnd = ((IntPtr)FindWindow(null, "Nox")).ToInt32();
                GetWindowRect(hwnd, out rect);
                
                */

       //     var col = GetColorAt(Cursor.Position);

          //  label5.Text = "";// col.ToString();
        }

        Bitmap screenPixel = new Bitmap(1, 1, PixelFormat.Format32bppArgb);
        public Color GetColorAt(Point location)
        {
            using (Graphics gdest = Graphics.FromImage(screenPixel))
            {
                using (Graphics gsrc = Graphics.FromHwnd(IntPtr.Zero))
                {
                    IntPtr hSrcDC = gsrc.GetHdc();
                    IntPtr hDC = gdest.GetHdc();
                    int retval = BitBlt(hDC, 0, 0, 1, 1, hSrcDC, location.X, location.Y, (int)CopyPixelOperation.SourceCopy);
                    gdest.ReleaseHdc();
                    gsrc.ReleaseHdc();
                }
            }

            return screenPixel.GetPixel(0, 0);
        }

        //private void label5_Click(object sender, EventArgs e)
        //{
        //    //핸들을 찾는다. Spy+를 통해 찾은 클래스 이름과 캡션을 이용하면 된다. 둘 중 하나만 알경우에도 찾을 수 있다. 
        //    //그때는 하나의 인자를 null로 넘겨 주면된다.
        //    handle = FindWindow("SciCalc", "계산기");
        //    // 찾은 핸들에서 자식 윈도우 핸들을 찾기 위해서는 FindWindowEx를 이용한다.
        //    handle = FindWindowEx(handle, 0, "Shell DocObject View", null);
        //    label5.Text = handle.ToString();
        //}
    }
}
