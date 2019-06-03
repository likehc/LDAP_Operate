namespace Main
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
            this.domain_host_txt = new System.Windows.Forms.TextBox();
            this.user_txt = new System.Windows.Forms.TextBox();
            this.passwd_txt = new System.Windows.Forms.TextBox();
            this.ou_txt = new System.Windows.Forms.TextBox();
            this.addStart_txt = new System.Windows.Forms.TextBox();
            this.addUser_txt = new System.Windows.Forms.TextBox();
            this.addEnd_txt = new System.Windows.Forms.TextBox();
            this.conn_btn = new System.Windows.Forms.Button();
            this.createUser_btn = new System.Windows.Forms.Button();
            this.deafulePass_txt = new System.Windows.Forms.TextBox();
            this.domain_host_lab = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.save_chk = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.log_richtxt = new System.Windows.Forms.RichTextBox();
            this.hideLog_btn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // domain_host_txt
            // 
            this.domain_host_txt.Location = new System.Drawing.Point(73, 53);
            this.domain_host_txt.Name = "domain_host_txt";
            this.domain_host_txt.Size = new System.Drawing.Size(137, 25);
            this.domain_host_txt.TabIndex = 0;
            // 
            // user_txt
            // 
            this.user_txt.Location = new System.Drawing.Point(289, 53);
            this.user_txt.Name = "user_txt";
            this.user_txt.Size = new System.Drawing.Size(142, 25);
            this.user_txt.TabIndex = 1;
            // 
            // passwd_txt
            // 
            this.passwd_txt.Location = new System.Drawing.Point(486, 53);
            this.passwd_txt.Name = "passwd_txt";
            this.passwd_txt.PasswordChar = '*';
            this.passwd_txt.Size = new System.Drawing.Size(148, 25);
            this.passwd_txt.TabIndex = 2;
            // 
            // ou_txt
            // 
            this.ou_txt.Location = new System.Drawing.Point(73, 120);
            this.ou_txt.Name = "ou_txt";
            this.ou_txt.Size = new System.Drawing.Size(100, 25);
            this.ou_txt.TabIndex = 3;
            this.ou_txt.Text = "OU";
            // 
            // addStart_txt
            // 
            this.addStart_txt.Location = new System.Drawing.Point(92, 99);
            this.addStart_txt.Name = "addStart_txt";
            this.addStart_txt.Size = new System.Drawing.Size(55, 25);
            this.addStart_txt.TabIndex = 8;
            this.addStart_txt.Text = "1";
            // 
            // addUser_txt
            // 
            this.addUser_txt.Location = new System.Drawing.Point(92, 35);
            this.addUser_txt.Name = "addUser_txt";
            this.addUser_txt.Size = new System.Drawing.Size(100, 25);
            this.addUser_txt.TabIndex = 6;
            this.addUser_txt.Text = "test";
            // 
            // addEnd_txt
            // 
            this.addEnd_txt.Location = new System.Drawing.Point(221, 99);
            this.addEnd_txt.Name = "addEnd_txt";
            this.addEnd_txt.Size = new System.Drawing.Size(55, 25);
            this.addEnd_txt.TabIndex = 9;
            this.addEnd_txt.Text = "5";
            // 
            // conn_btn
            // 
            this.conn_btn.Location = new System.Drawing.Point(336, 120);
            this.conn_btn.Name = "conn_btn";
            this.conn_btn.Size = new System.Drawing.Size(81, 28);
            this.conn_btn.TabIndex = 5;
            this.conn_btn.Text = "连接";
            this.conn_btn.UseVisualStyleBackColor = true;
            this.conn_btn.Click += new System.EventHandler(this.conn_btn_Click);
            // 
            // createUser_btn
            // 
            this.createUser_btn.Location = new System.Drawing.Point(330, 95);
            this.createUser_btn.Name = "createUser_btn";
            this.createUser_btn.Size = new System.Drawing.Size(82, 30);
            this.createUser_btn.TabIndex = 10;
            this.createUser_btn.Text = "创建用户";
            this.createUser_btn.UseVisualStyleBackColor = true;
            this.createUser_btn.Click += new System.EventHandler(this.createUser_btn_Click);
            // 
            // deafulePass_txt
            // 
            this.deafulePass_txt.Location = new System.Drawing.Point(256, 35);
            this.deafulePass_txt.Name = "deafulePass_txt";
            this.deafulePass_txt.Size = new System.Drawing.Size(126, 25);
            this.deafulePass_txt.TabIndex = 7;
            this.deafulePass_txt.Text = "HelloYhc123";
            // 
            // domain_host_lab
            // 
            this.domain_host_lab.AutoSize = true;
            this.domain_host_lab.Location = new System.Drawing.Point(36, 58);
            this.domain_host_lab.Name = "domain_host_lab";
            this.domain_host_lab.Size = new System.Drawing.Size(31, 15);
            this.domain_host_lab.TabIndex = 11;
            this.domain_host_lab.Text = "IP:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(222, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 15);
            this.label2.TabIndex = 11;
            this.label2.Text = "用户名:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(437, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 15);
            this.label3.TabIndex = 11;
            this.label3.Text = "密码:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 15);
            this.label1.TabIndex = 11;
            this.label1.Text = "OU:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 15);
            this.label4.TabIndex = 11;
            this.label4.Text = "新用户名:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(41, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 15);
            this.label5.TabIndex = 11;
            this.label5.Text = "开始:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(166, 104);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 15);
            this.label6.TabIndex = 11;
            this.label6.Text = "结束:";
            // 
            // save_chk
            // 
            this.save_chk.AutoSize = true;
            this.save_chk.Location = new System.Drawing.Point(236, 124);
            this.save_chk.Name = "save_chk";
            this.save_chk.Size = new System.Drawing.Size(89, 19);
            this.save_chk.TabIndex = 4;
            this.save_chk.Text = "保存密码";
            this.save_chk.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(205, 41);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 15);
            this.label7.TabIndex = 11;
            this.label7.Text = "密码:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.addUser_txt);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.deafulePass_txt);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.createUser_btn);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.addStart_txt);
            this.groupBox1.Controls.Add(this.addEnd_txt);
            this.groupBox1.Location = new System.Drawing.Point(49, 165);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(585, 235);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "新用户信息";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(70, 74);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(172, 15);
            this.label8.TabIndex = 11;
            this.label8.Text = "开始与结束只能输入数字";
            // 
            // log_richtxt
            // 
            this.log_richtxt.Location = new System.Drawing.Point(680, 12);
            this.log_richtxt.Name = "log_richtxt";
            this.log_richtxt.Size = new System.Drawing.Size(571, 388);
            this.log_richtxt.TabIndex = 15;
            this.log_richtxt.Text = "";
            // 
            // hideLog_btn
            // 
            this.hideLog_btn.Location = new System.Drawing.Point(644, 12);
            this.hideLog_btn.Name = "hideLog_btn";
            this.hideLog_btn.Size = new System.Drawing.Size(25, 388);
            this.hideLog_btn.TabIndex = 16;
            this.hideLog_btn.Text = ">>>>>";
            this.hideLog_btn.UseVisualStyleBackColor = true;
            this.hideLog_btn.Click += new System.EventHandler(this.hideLog_btn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1265, 417);
            this.Controls.Add(this.hideLog_btn);
            this.Controls.Add(this.log_richtxt);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.save_chk);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.domain_host_lab);
            this.Controls.Add(this.conn_btn);
            this.Controls.Add(this.ou_txt);
            this.Controls.Add(this.passwd_txt);
            this.Controls.Add(this.user_txt);
            this.Controls.Add(this.domain_host_txt);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox domain_host_txt;
        private System.Windows.Forms.TextBox user_txt;
        private System.Windows.Forms.TextBox passwd_txt;
        private System.Windows.Forms.TextBox ou_txt;
        private System.Windows.Forms.TextBox addStart_txt;
        private System.Windows.Forms.TextBox addUser_txt;
        private System.Windows.Forms.TextBox addEnd_txt;
        private System.Windows.Forms.Button conn_btn;
        private System.Windows.Forms.Button createUser_btn;
        private System.Windows.Forms.TextBox deafulePass_txt;
        private System.Windows.Forms.Label domain_host_lab;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox save_chk;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.RichTextBox log_richtxt;
        private System.Windows.Forms.Button hideLog_btn;
    }
}

