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
using System.Media;

namespace MouseClicker
{
    public enum Mode
    {
        Idle,
        Recording,
        Activated,
    }

    public struct SingleAction
    {
        public Point pos;
        public double waitTime;
    }

    public partial class Form1 : Form
    {
        public Mode curMode = Mode.Idle;
        TimeSpan delay = TimeSpan.FromSeconds(0.1f);

        List<SingleAction> keys = new List<SingleAction>();
        int curIndex;
        double remainedTimeForNextClick;

        double recordIntervalTime;

        double remainedTimerSeconds;
        bool useTimer;

        public Form1()
        {
            MouseCallBack.onLeftMouseDown = OnLeftMouseClicked;
            MouseCallBack.onRightMouseDown = OnRightMouseClicked;

            InitializeComponent();
            SetMode(Mode.Idle);
            Loop();
        }

        private void OnLeftMouseClicked(int x, int y)
        {
            if (curMode != Mode.Recording)
                return;

            keys.Add(new SingleAction() { pos = new Point(x, y), waitTime = recordIntervalTime });
            recordIntervalTime = 0;
        }

        private void OnRightMouseClicked(int x, int y)
        {
            ProcessNextByContext();
        }

        void ProcessNextByContext(bool ableExecute = false)
        {
            switch (curMode)
            {
                case Mode.Idle:
                    if (ableExecute)
                        SetMode(Mode.Recording);
                    break;
                case Mode.Recording:
                    if (keys.Count > 0)
                    {
                        SetMode(Mode.Activated);
                    }
                    break;
                case Mode.Activated:
                    SetMode(Mode.Idle);
                    break;
            }
        }

        void SetMode(Mode mode)
        {
            var prevMode = curMode;
            curMode = mode;

            label4.Text = "CurrentMode : " + mode.ToString();

            switch (mode)
            {
                case Mode.Idle:
                    if(prevMode == Mode.Activated)
                    {
                        SystemSounds.Hand.Play();
                        MessageBox.Show("Stop");
                    }
                    break;
                case Mode.Recording:
                    keys.Clear();
                    SystemSounds.Hand.Play();
                    WindowState = FormWindowState.Minimized;
                    break;
                case Mode.Activated:
                    string str = "";

                    for (int i = 0; i < keys.Count; i++)
                    {
                        str += keys[i].waitTime + " ";
                    }

                    curIndex = 0;
                    remainedTimeForNextClick = keys[0].waitTime;

                    if (double.TryParse(textBox1.Text, out remainedTimerSeconds))
                    {
                        useTimer = remainedTimerSeconds > 0;
                    }
                    else
                    {
                        useTimer = false;
                    }

                    //                 MessageBox.Show("Start Play : " + keys.Count);
                    break;
                default:
                    break;
            }
        }

        async void Loop()
        {
            while (true)
            {
                switch (curMode)
                {
                    case Mode.Idle:
                        break;
                    case Mode.Recording:
                        recordIntervalTime += delay.TotalSeconds;
                        break;
                    case Mode.Activated:
                        {
                            remainedTimeForNextClick -= delay.TotalSeconds;
                            remainedTimerSeconds -= delay.TotalSeconds;

                            if (remainedTimeForNextClick <= 0)
                            {
                                DoAction(keys[curIndex]);
                                curIndex++;

                                if (curIndex >= keys.Count)
                                {
                                    curIndex = 0;
                                }

                                remainedTimeForNextClick = keys[curIndex].waitTime;
                            }

                            if (useTimer)
                            {
                                if (remainedTimerSeconds <= 0)
                                {
                                    SetMode(Mode.Idle);
                                    remainedTimerSeconds = 0;
                                }
                            }

                            label3.Text = useTimer ? "RemainedSeconds : " + remainedTimerSeconds.ToString() : "NoTimer";
                        }
                        break;
                    default:
                        break;
                }

                label1.Text = "CursorPos : " + Cursor.Position.ToString();

                await Task.Delay(delay);
                this.Text = DateTime.Now.ToString();
            }
        }

        private void DoAction(SingleAction singleAction)
        {
            var oriPos = Cursor.Position;
            DoMouseClick(singleAction.pos.X, singleAction.pos.Y);

            Cursor.Position = oriPos;
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);
        //Mouse actions
        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void OnClickRecordBtn(object sender, EventArgs e)
        {
            ProcessNextByContext(true);
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private const int MOUSEEVENTF_RIGHTUP = 0x10;

        public void DoMouseClick(int x, int y)
        {
            Cursor.Position = new Point() { X = x, Y = y };
            //Call the imported function with the cursor's current position
            uint X = (uint)x;
            uint Y = (uint)y;
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, X, Y, 0, 0);
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
