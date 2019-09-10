namespace lockscreen
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.unlockBtn = new System.Windows.Forms.Button();
            this.lockBtn = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // unlockBtn
            // 
            this.unlockBtn.Location = new System.Drawing.Point(405, 244);
            this.unlockBtn.Margin = new System.Windows.Forms.Padding(4);
            this.unlockBtn.Name = "unlockBtn";
            this.unlockBtn.Size = new System.Drawing.Size(157, 79);
            this.unlockBtn.TabIndex = 0;
            this.unlockBtn.Text = "解锁";
            this.unlockBtn.UseVisualStyleBackColor = true;
            this.unlockBtn.Click += new System.EventHandler(this.unlockBtn_Click);
            // 
            // lockBtn
            // 
            this.lockBtn.Location = new System.Drawing.Point(135, 244);
            this.lockBtn.Margin = new System.Windows.Forms.Padding(4);
            this.lockBtn.Name = "lockBtn";
            this.lockBtn.Size = new System.Drawing.Size(164, 79);
            this.lockBtn.TabIndex = 1;
            this.lockBtn.Text = "加锁";
            this.lockBtn.UseVisualStyleBackColor = true;
            this.lockBtn.Click += new System.EventHandler(this.lockBtn_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(364, 45);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(707, 438);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lockBtn);
            this.Controls.Add(this.unlockBtn);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.MaximizeBox = false;		//去掉最大化和最小化的小按钮
            this.MinimizeBox = false;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button unlockBtn;
        private System.Windows.Forms.Button lockBtn;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button1;
    }
}

