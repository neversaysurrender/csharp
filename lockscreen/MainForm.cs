using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace lockscreen
{
    public partial class MainForm : Form
    {
        #region 监听回车键
        private const int WM_HOTKEY = 0x312; //窗口消息-热键  
        private const int WM_CREATE = 0x1; //窗口消息-创建  
        private const int WM_DESTROY = 0x2; //窗口消息-销毁  
        private const int Space = 0x3572; //热键ID
        private const int Space2 = 0x1111; //热键ID  2
        private const int Space3 = 0x1112; //热键ID  3
        private const int Space4 = 0x1113; //热键ID  4
        private const int WM_CLOSE = 0x0010;    //关闭窗口消息
        private int restTime = 6; //剩余输入密码次数
        private bool isWaitShut = false;    //密码输错超过五次后等待关机，是否在等待状态。
        private const int shutTime = 30;    //登陆错误5次后，电脑30秒后关机
        private void Form1_FormClosing(object sender, FormClosingEventArgs e) //禁止关闭窗口的方法之一，将该方法加入到FormClosing事件中。
        {
            e.Cancel = true;
        }
        protected override void WndProc(ref Message m)
        {
            //if (m.Msg == WM_CLOSE)  //禁止alt+f4和点击X关闭窗口
            //{
            //    return;
            //}
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
                        case Space4:
                            Console.WriteLine("关闭吧");
                            FormClosing -= Form1_FormClosing;   //将监听事件去除，然后关闭
                            this.Close();
                            break;  
                        default:
                            break;
                    }
                    break;
                case WM_CREATE: //窗口消息-创建  
                    AppHotKey.RegKey(Handle, Space, AppHotKey.KeyModifiers.None, Keys.Enter);
                    AppHotKey.RegKey(Handle, Space2, AppHotKey.KeyModifiers.Alt, Keys.F4);
                    AppHotKey.RegKey(Handle, Space3, AppHotKey.KeyModifiers.Alt | AppHotKey.KeyModifiers.Ctrl | AppHotKey.KeyModifiers.Shift, Keys.H);
                    AppHotKey.RegKey(Handle, Space4, AppHotKey.KeyModifiers.Alt | AppHotKey.KeyModifiers.Ctrl,Keys.S);
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

        bool isLock = false;        //是否已锁
        Rectangle rec_chuangkou;    //活动区域
        Rectangle rec_outBonus;     //判断边界的区域
        public MainForm()
        {
            InitializeComponent();
            rec_chuangkou = new Rectangle(PointToScreen(new Point(1, -SystemInformation.CaptionHeight + 29)), new Size(this.ClientRectangle.Width-2, this.ClientRectangle.Height + SystemInformation.CaptionHeight - 31));
            rec_outBonus =new Rectangle(PointToScreen(new Point(0, -SystemInformation.CaptionHeight + 28)), new Size(this.ClientRectangle.Width, this.ClientRectangle.Height + SystemInformation.CaptionHeight - 24));
            FormClosing += Form1_FormClosing;   //监听关闭事件

            isLock = true;  //一运行就上锁
            AppHotKey.RegKey(Handle, Space, AppHotKey.KeyModifiers.None, Keys.Enter);
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

        /// <summary>
        /// 登陆管理员账号并解锁
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void unlockBtn_Click(object sender, EventArgs e)//解锁，启用回车键
        {
            if (isWaitShut) //如果已经输入错误超过6次，则处于等待关机状态，直接返回
            {
                return;
            }
            
            if (this.adminNameBox.Text.Equals("") || this.passwdBox.Equals("")) //如果密码和用户名为空，则提示
            {
                this.nameNotNullLabel.Visible = true;
                this.passwdNotNullLabel.Visible = true;
                ThreadPool.QueueUserWorkItem(new WaitCallback(visibleTime =>
                {
                    DateTime startTime = DateTime.Now;
                    while ((DateTime.Now - startTime).TotalSeconds < (int)visibleTime)
                    {
                    }
                    Action updateLabel = () =>
                    {
                        this.nameNotNullLabel.Visible = false;
                        this.passwdNotNullLabel.Visible = false;
                    };
                    this.Invoke(updateLabel);
                }), 5);
                return;
            }
            Console.WriteLine("name="+this.adminNameBox.Text+"pass="+this.passwdBox.Text);

            restTime--; //输入的剩余密码次数减去1；
            if (this.adminNameBox.Text.Equals("admin") && this.passwdBox.Text.Equals("123456"))
            {
                isLock = false;
                AppHotKey.UnRegKey(Handle, Space);
                this.Hide();
            }
            else
            {
                if (restTime == 0)  //剩余次数为0时，等待关机
                {
                    restTime = 6;
                    isWaitShut = true;
                    ThreadPool.QueueUserWorkItem(new WaitCallback(shutdownTime =>
                    {
                        DateTime nowTime = DateTime.Now;
                        while ((DateTime.Now - nowTime).TotalSeconds < (int)shutdownTime)
                        {
                            Action updateShutTipLabel = () =>
                            {
                                this.restTimeLabel.Text = "密码输入错误超过5次，距离关机还剩" + (30 - (int)(DateTime.Now - nowTime).TotalSeconds) + "秒";
                            };
                            this.restTimeLabel.Invoke(updateShutTipLabel);
                            if (!isWaitShut)    //如果点击取消关机，则进入取消关机方法
                            {
                                updateShutTipLabel = () =>
                                {
                                    this.restTimeLabel.Text = "关机已停止";
                                };
                                this.Invoke(updateShutTipLabel);
                                Thread.Sleep(5000);
                                updateShutTipLabel = () =>
                                {
                                    this.restTimeLabel.Visible = false;
                                };
                                this.Invoke(updateShutTipLabel);
                                return;
                            } 
                            Thread.Sleep(1000);
                        }
                        Process.Start("shutdown.exe", "-s -f");
                    }), shutTime);
                    return;
                }
                
                //int len = this.restTimeLabel.Text.Length;   //获取剩余输入次数label的长度
                //this.restTimeLabel.Text=this.restTimeLabel.Text.Remove(len - 2,1).Insert(len-2,restTime.ToString());    //修改剩余次数的数字

                this.restTimeLabel.Text = "用户名或密码错误，剩余" + restTime.ToString() + "次";
                if (!this.restTimeLabel.Visible)    //最开始剩余次数的label是不可见的，这时设置为可见
                {
                    this.restTimeLabel.Visible = true;
                }
                return;
            } 
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

        private void button1_Click_1(object sender, EventArgs e)
        {
            isWaitShut = false;
        }

     
    }
}