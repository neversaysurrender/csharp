namespace lockscreen
{
    partial class MainForm
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.adminNameBox = new System.Windows.Forms.TextBox();
            this.adminLabel = new System.Windows.Forms.Label();
            this.pwordLabel = new System.Windows.Forms.Label();
            this.passwdBox = new System.Windows.Forms.TextBox();
            this.restTimeLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.nameNotNullLabel = new System.Windows.Forms.Label();
            this.passwdNotNullLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // unlockBtn
            // 
            this.unlockBtn.BackColor = System.Drawing.Color.Transparent;
            this.unlockBtn.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.unlockBtn.Location = new System.Drawing.Point(304, 290);
            this.unlockBtn.Margin = new System.Windows.Forms.Padding(4);
            this.unlockBtn.Name = "unlockBtn";
            this.unlockBtn.Size = new System.Drawing.Size(98, 44);
            this.unlockBtn.TabIndex = 0;
            this.unlockBtn.Text = "解锁";
            this.unlockBtn.UseVisualStyleBackColor = false;
            this.unlockBtn.Click += new System.EventHandler(this.unlockBtn_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // adminNameBox
            // 
            this.adminNameBox.Location = new System.Drawing.Point(291, 120);
            this.adminNameBox.Name = "adminNameBox";
            this.adminNameBox.Size = new System.Drawing.Size(211, 25);
            this.adminNameBox.TabIndex = 2;
            // 
            // adminLabel
            // 
            this.adminLabel.AutoSize = true;
            this.adminLabel.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.adminLabel.Location = new System.Drawing.Point(170, 120);
            this.adminLabel.Name = "adminLabel";
            this.adminLabel.Size = new System.Drawing.Size(82, 24);
            this.adminLabel.TabIndex = 3;
            this.adminLabel.Text = "管理员";
            // 
            // pwordLabel
            // 
            this.pwordLabel.AutoSize = true;
            this.pwordLabel.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pwordLabel.Location = new System.Drawing.Point(170, 213);
            this.pwordLabel.Name = "pwordLabel";
            this.pwordLabel.Size = new System.Drawing.Size(58, 24);
            this.pwordLabel.TabIndex = 5;
            this.pwordLabel.Text = "密码";
            // 
            // passwdBox
            // 
            this.passwdBox.Location = new System.Drawing.Point(291, 212);
            this.passwdBox.Name = "passwdBox";
            this.passwdBox.PasswordChar = '*';
            this.passwdBox.Size = new System.Drawing.Size(211, 25);
            this.passwdBox.TabIndex = 4;
            // 
            // restTimeLabel
            // 
            this.restTimeLabel.AutoSize = true;
            this.restTimeLabel.Font = new System.Drawing.Font("楷体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.restTimeLabel.Location = new System.Drawing.Point(233, 386);
            this.restTimeLabel.Name = "restTimeLabel";
            this.restTimeLabel.Size = new System.Drawing.Size(259, 19);
            this.restTimeLabel.TabIndex = 6;
            this.restTimeLabel.Text = "用户名或密码错误，剩余5次";
            this.restTimeLabel.Visible = false;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(555, 35);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 40);
            this.button1.TabIndex = 8;
            this.button1.Text = "取消关机";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // nameNotNullLabel
            // 
            this.nameNotNullLabel.AutoSize = true;
            this.nameNotNullLabel.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nameNotNullLabel.ForeColor = System.Drawing.Color.Red;
            this.nameNotNullLabel.Location = new System.Drawing.Point(526, 121);
            this.nameNotNullLabel.Name = "nameNotNullLabel";
            this.nameNotNullLabel.Size = new System.Drawing.Size(152, 19);
            this.nameNotNullLabel.TabIndex = 9;
            this.nameNotNullLabel.Text = "*用户名不能为空";
            this.nameNotNullLabel.Visible = false;
            // 
            // passwdNotNullLabel
            // 
            this.passwdNotNullLabel.AutoSize = true;
            this.passwdNotNullLabel.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.passwdNotNullLabel.ForeColor = System.Drawing.Color.Red;
            this.passwdNotNullLabel.Location = new System.Drawing.Point(526, 213);
            this.passwdNotNullLabel.Name = "passwdNotNullLabel";
            this.passwdNotNullLabel.Size = new System.Drawing.Size(133, 19);
            this.passwdNotNullLabel.TabIndex = 10;
            this.passwdNotNullLabel.Text = "*密码不能为空";
            this.passwdNotNullLabel.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(707, 438);
            this.Controls.Add(this.passwdNotNullLabel);
            this.Controls.Add(this.nameNotNullLabel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.restTimeLabel);
            this.Controls.Add(this.pwordLabel);
            this.Controls.Add(this.passwdBox);
            this.Controls.Add(this.adminLabel);
            this.Controls.Add(this.adminNameBox);
            this.Controls.Add(this.unlockBtn);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LockScreen";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button unlockBtn;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox adminNameBox;
        private System.Windows.Forms.Label adminLabel;
        private System.Windows.Forms.Label pwordLabel;
        private System.Windows.Forms.TextBox passwdBox;
        private System.Windows.Forms.Label restTimeLabel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label nameNotNullLabel;
        private System.Windows.Forms.Label passwdNotNullLabel;
    }
}

