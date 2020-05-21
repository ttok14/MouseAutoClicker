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
        Pause,
        Activated,
    }

    public enum ActionType
    {
        MouseClick,
        Typing
    }

    public struct SingleAction
    {
        public ActionType type;

        // click
        public Point pos;
        // typing
        public string str;

        public double waitTime;
    }

    public partial class Form1 : Form
    {
        private const int KEY_PRESSED = 0x80;

        public Mode curMode = Mode.Idle;
        TimeSpan delay = TimeSpan.FromSeconds(0.1f);

        List<SingleAction> keys = new List<SingleAction>();
        int curIndex;
        double remainedTimeForNextClick;

        double recordIntervalTime;

        double remainedTimerSeconds;
        bool useTimer;

        bool isInputBoxOpen;

        public Form1()
        {
            MouseCallBack.onLeftMouseDown = OnLeftMouseClicked;
            MouseCallBack.onRightMouseDown = OnRightMouseClicked;
            MouseCallBack.onWheelDown = OnWheelDown;

            InitializeComponent();
            SetMode(Mode.Idle);
            Initialize_HandleOtherWindow();
            Loop();
        }

        private void OnLeftMouseClicked(int x, int y)
        {
            if (isInputBoxOpen)
                return;

            if (curMode != Mode.Recording)
                return;

            keys.Add(new SingleAction() { type = ActionType.MouseClick, pos = new Point(x, y), waitTime = recordIntervalTime });
            recordIntervalTime = 0;
        }

        private void OnRightMouseClicked(int x, int y)
        {
            if (isInputBoxOpen)
                return;

            if (curMode == Mode.Recording)
            {
                SetMode(Mode.Activated);
            }
            else if (curMode == Mode.Activated || curMode == Mode.Pause)
            {
                SetMode(Mode.Idle);
            }
        }

        private void OnWheelDown(int x, int y)
        {
            if (isInputBoxOpen)
                return;

            if (curMode != Mode.Recording)
                return;

            isInputBoxOpen = true;

            using (var form = new Form_InputBox())
            {
                // form.WindowState = FormWindowState.Maximized;
                ///   form.BringToFront();

                if (form.ShowDialog() == DialogResult.OK)
                {
                    keys.Add(new SingleAction() { type = ActionType.MouseClick, pos = new Point(x, y), waitTime = recordIntervalTime });
                    recordIntervalTime = 0;
                    keys.Add(new SingleAction() { type = ActionType.Typing, str = form.typedTxt, waitTime = 0.05f });
                }

                isInputBoxOpen = false;
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
                    if (prevMode == Mode.Activated)
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
                if (isInputBoxOpen)
                {
                    await Task.Delay(delay);
                    continue;
                }

                ProcessKeyDown();
                Update_HandleOtherWindow(delay);

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

        private void ProcessKeyDown()
        {
            if (IsKeyDown(Keys.LShiftKey) && IsKeyDown(Keys.F9))
            {
                if (curMode == Mode.Activated)
                {
                    SetMode(Mode.Pause);
                }
                else
                {
                    SetMode(Mode.Activated);
                }
            }
        }

        bool IsKeyDown(Keys key)
        {
            return (GetKeyState(key) & KEY_PRESSED) == KEY_PRESSED;
        }

        private void DoAction(SingleAction singleAction)
        {
            if (singleAction.type == ActionType.MouseClick)
            {
                var oriPos = Cursor.Position;
                DoMouseClick(singleAction.pos.X, singleAction.pos.Y);
                Cursor.Position = oriPos;
            }
            else if (singleAction.type == ActionType.Typing)
            {
                SendKeys.SendWait(singleAction.str);
                SendKeys.Send("{ENTER}");
            }
        }

        [DllImport("USER32.dll")]
        public static extern short GetKeyState(Keys nVirtKey);

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
            SetMode(Mode.Recording);
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

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.Alt && e.Shift && e.KeyCode == Keys.F12)
                MessageBox.Show("My message");
        }
    }
}
