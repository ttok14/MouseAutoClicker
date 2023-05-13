using System;
using System.Drawing;
using System.Windows.Forms;

namespace MouseClicker
{
    /// <summary>
    /// 영역 선택 후에
    /// <see cref="Output_ColorInfo"/> 프로퍼티를 이용해서 선택한 영역에 대한 값 리턴
    /// </summary>
    public partial class SelectArea : Form
    {
        public enum Type
        {
            None = 0,
            PickPixel,
            SelectArea
        }

        Bitmap screen_bmp;
        Graphics screen_gp;
        Brush brsBackground;
        Point screenWidHei;
        Rectangle area;
        Type type = Type.None;

        public Color[,] Output_ColorInfo { get; private set; }
        public Bitmap Output_BitmapImg { get; private set; }
        public int Output_Width { get; private set; }
        public int Output_Height { get; private set; }
        public Rectangle Output_Rectangle { get; private set; }
        // Rectangle clearArea;

        // Rectangle rect = new Rectangle(125, 125, 50, 50);

        public SelectArea(Type type = Type.SelectArea)
        {
            InitializeComponent();

            this.type = type;

            if (type == Type.SelectArea)
            {
                Cursor = Cursors.Cross;
            }
            else if (type == Type.PickPixel)
            {
                Cursor = Cursors.Default;
            }

            screenWidHei = new Point(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);

            /// 기본 설정 
            FormBorderStyle = FormBorderStyle.None;
            SetClientSizeCore(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            TopMost = true;
            this.SetStyle(ControlStyles.ResizeRedraw, true);

            if (type == Type.SelectArea)
                DoubleBuffered = true;

            /// back Color 설정 
            //          this.BackColor = Color.Fuchsia;
            /// 투명으로 만들 컬러 설정 
            //       TransparencyKey = Color.White;

            //////////////

            /// 지금 현재 스크린 기본 bitmap 으로 만든다음에 
            /// backGround Image 에 설정  
            screen_bmp = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            screen_gp = Graphics.FromImage(screen_bmp);
            screen_gp.CopyFromScreen(0, 0, 0, 0, screen_bmp.Size);

            if (type == Type.SelectArea)
                this.brsBackground = new TextureBrush(screen_bmp);

            BackgroundImage = screen_bmp;

            txtRect.Visible = false;
            txtRect.BackColor = System.Drawing.Color.Transparent;
            txtRect.ForeColor = Color.Red;
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);

            if (brsBackground != null)
            {
                brsBackground.Dispose();
                brsBackground = null;
            }

            if (screen_bmp != null)
            {
                screen_bmp.Dispose();
                screen_bmp = null;
            }

            if (screen_gp != null)
            {
                screen_gp.Dispose();
                screen_gp = null;
            }
        }

        bool isDragging;

        Point pos_dragStart;

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (type == Type.SelectArea)
            {
                isDragging = true;
                pos_dragStart = Cursor.Position;
                txtRect.Visible = true;
            }
            else if (type == Type.PickPixel)
            {
                this.DialogResult = DialogResult.OK;
                Output_ColorInfo = new Color[1, 1];
                Output_ColorInfo[0, 0] = this.screen_bmp.GetPixel(Cursor.Position.X, Cursor.Position.Y);
                Output_Width = 1;
                Output_Height = 1;
                Close();
            }

            // clearArea = new Rectangle(Cursor.Position.X, Cursor.Position.Y, 0, 0);
        }

        /// <summary>
        /// 마우스 뗌 
        /// </summary>
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            if (type == Type.PickPixel)
                return;

            isDragging = false;

            /// 선택 영역이 존재할떄만 
            if (area.Width > 0
                && area.Height > 0)
            {
                this.DialogResult = DialogResult.OK;

                Output_ColorInfo = new Color[area.Width, area.Height];
                Output_BitmapImg = new Bitmap(area.Width, area.Height);

                Output_Width = area.Width;
                Output_Height = area.Height;

                Output_Rectangle = area;

                for (int i = 0; i < area.Width; i++)
                {
                    for (int j = 0; j < area.Height; j++)
                    {
                        /// GetPixel 이 존나 빠름 
                        /// DC 로 복사하고 긁어오고 그거 존나느림 진짜 
                        var color = this.screen_bmp.GetPixel(area.X + i, area.Y + j);
                        Output_ColorInfo[i, j] = color;
                        Output_BitmapImg.SetPixel(i, j, color);
                    }
                }

                Close();
            }
            else
            {
                /// clear 처리 
                area = new Rectangle(0, 0, 0, 0);
                Invalidate();
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (isDragging == false)
                return;

            area = new Rectangle(
                Math.Min(Cursor.Position.X, pos_dragStart.X)
                , Math.Min(Cursor.Position.Y, pos_dragStart.Y)
                , Math.Abs(Cursor.Position.X - pos_dragStart.X)
                , Math.Abs(Cursor.Position.Y - pos_dragStart.Y));

            //clearArea = new Rectangle(
            //    Math.Min(clearArea.X, Cursor.Position.X)
            //    ,Math.Min(clearArea.Y, Cursor.Position.Y)
            //    , Math.Max(clearArea.Width, Math.Abs(Cursor.Position.X - area.X)) + 5
            //    , Math.Max(clearArea.Height, Math.Abs(Cursor.Position.Y -area.Y)) + 5);

            // Invalidate(clearArea);
            Invalidate();
            
            /// 커서쪽에 현재 드래깅 영역 표시 
            txtRect.SetBounds(Cursor.Position.X + 2, Cursor.Position.Y + 2, txtRect.DisplayRectangle.Width, txtRect.DisplayRectangle.Height);
            txtRect.Text = area.ToString();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            //            this.screen_gp.FillRectangle(brsBackground, rect);

            if (this.isDragging)
            {
                /// 실제 보이는거는 한 픽셀 더 넓게 보이게하자 .
                var drawRt = new Rectangle(area.X - 1, area.Y - 1, area.Width + 2, area.Height + 2);
                e.Graphics.DrawRectangle(Pens.Red, drawRt);
            }

            //using (Pen selPen = new Pen(Color.Red))
            //{
            //    e.Graphics.DrawRectangle(selPen, rect);
            //}
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
    }
}
