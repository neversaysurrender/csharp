using System;
using System.Drawing;
using System.Windows.Forms;

namespace lockscreen
{
    public partial class Form1 : Form
    {
        #region 监听回车键
        private const int WM_HOTKEY = 0x312; //窗口消息-热键  
        private const int WM_CREATE = 0x1; //窗口消息-创建  
        private const int WM_DESTROY = 0x2; //窗口消息-销毁  
        private const int Space = 0x3572; //热键ID
        private const int Space2 = 0x1111; //热键ID  2
        private const int Space3 = 0x1112; //热键ID  2
        private const int WM_CLOSE = 0x0010;    //关闭窗口消息

        //private void Form1_FormClosing(object sender, FormClosingEventArgs e) //禁止关闭窗口的方法之一，将该方法加入到FormClosing事件中。
        //{
        //    e.Cancel = true;
        //}
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_CLOSE)  //禁止alt+f4和点击X关闭窗口
            {
                return;
            }
            if (m.Msg == 0x00A1 && m.WParam.ToInt32() == 2) //禁止窗体移动
                return;
            
            base.WndProc(ref m);
            switch (m.Msg)
            {
                case WM_HOTKEY: //窗口消息-热键ID  
                    switch (m.WParam.ToInt32())
                    {
                        case Space: //热键
                            Console.WriteLine("全局监听");
                            break;
                        case Space2: //热键
                            Console.WriteLine("全局监听最小化");
                            break;
                        case Space3:
                            Console.WriteLine("回来吧");
                            this.Show();
                            break;
                        default:
                            break;
                    }
                    break;
                case WM_CREATE: //窗口消息-创建  
                    AppHotKey.RegKey(Handle, Space, AppHotKey.KeyModifiers.None, Keys.Enter);
                    AppHotKey.RegKey(Handle, Space2, AppHotKey.KeyModifiers.Alt, Keys.F4);
                    AppHotKey.RegKey(Handle, Space3, AppHotKey.KeyModifiers.Alt | AppHotKey.KeyModifiers.Ctrl | AppHotKey.KeyModifiers.Shift, Keys.H);
                    break;
                case WM_DESTROY: //窗口消息-销毁  
                    AppHotKey.UnRegKey(Handle, Space); //销毁热键
                    AppHotKey.UnRegKey(Handle, Space2); //销毁热键
                    AppHotKey.UnRegKey(Handle, Space3);
                    break;
                default:
                    break;
            }
        }
        #endregion


        bool isLock = false;
        Rectangle rec_chuangkou;    //活动区域
        Rectangle rec_outBonus;     //判断边界的区域
        public Form1()
        {
            InitializeComponent();
            rec_chuangkou = new Rectangle(PointToScreen(new Point(3, -SystemInformation.CaptionHeight + 31)), new Size(this.ClientRectangle.Width-7, this.ClientRectangle.Height + SystemInformation.CaptionHeight - 32));
            rec_outBonus =new Rectangle(PointToScreen(new Point(0, -SystemInformation.CaptionHeight + 29)), new Size(this.ClientRectangle.Width, this.ClientRectangle.Height + SystemInformation.CaptionHeight - 25));
            //FormClosing +=Form1_FormClosing;
        }

        private void timer1_Tick(object sender, EventArgs e)//当锁定时，使锁屏窗口处于最前
        {
            if (!this.Focused && isLock)
            {
                this.Activate();
            }

            if (isLock)//窗体内移动
            {
                //Rectangle rectangle = new Rectangle(PointToScreen(new Point(0, -SystemInformation.CaptionHeight)), new Size(this.ClientRectangle.Width, this.ClientRectangle.Height + SystemInformation.CaptionHeight));
                if (!rec_outBonus.Contains(MousePosition))
                    Cursor.Position = new Point(Screen.PrimaryScreen.WorkingArea.Width / 2, Screen.PrimaryScreen.WorkingArea.Height / 2);
            }

            if (isLock)//窗体内移动
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void lockBtn_Click(object sender, EventArgs e)//加锁，禁用回车键
        {
            isLock = true;
            AppHotKey.RegKey(Handle, Space, AppHotKey.KeyModifiers.None, Keys.Enter);
            
        }

        private void unlockBtn_Click(object sender, EventArgs e)//解锁，启用回车键
        {
            isLock = false;
            AppHotKey.UnRegKey(Handle, Space);
            this.Hide();
        }

        protected override void OnMouseMove(MouseEventArgs e)//鼠标的活动范围
        {
            if (isLock)//窗体内移动
            {
                Cursor.Clip = rec_chuangkou;
            }
            else//在全屏范围内移动
            {
                Cursor.Clip = Rectangle.Empty; ;
            }
            base.OnMouseMove(e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine(SystemInformation.CaptionHeight);
        }
    }
}