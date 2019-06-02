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
            this.button1 = new System.Windows.Forms.Button();
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
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(519, 275);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // domain_host_txt
            // 
            this.domain_host_txt.Location = new System.Drawing.Point(54, 34);
            this.domain_host_txt.Name = "domain_host_txt";
            this.domain_host_txt.Size = new System.Drawing.Size(171, 25);
            this.domain_host_txt.TabIndex = 1;
            this.domain_host_txt.Text = "192.168.88.10";
            // 
            // user_txt
            // 
            this.user_txt.Location = new System.Drawing.Point(253, 34);
            this.user_txt.Name = "user_txt";
            this.user_txt.Size = new System.Drawing.Size(142, 25);
            this.user_txt.TabIndex = 2;
            this.user_txt.Text = "administrator";
            // 
            // passwd_txt
            // 
            this.passwd_txt.Location = new System.Drawing.Point(401, 34);
            this.passwd_txt.Name = "passwd_txt";
            this.passwd_txt.PasswordChar = '*';
            this.passwd_txt.Size = new System.Drawing.Size(148, 25);
            this.passwd_txt.TabIndex = 3;
            this.passwd_txt.Text = "!qaz2wsx";
            // 
            // ou_txt
            // 
            this.ou_txt.Location = new System.Drawing.Point(54, 116);
            this.ou_txt.Name = "ou_txt";
            this.ou_txt.Size = new System.Drawing.Size(100, 25);
            this.ou_txt.TabIndex = 4;
            this.ou_txt.Text = "OU";
            // 
            // addStart_txt
            // 
            this.addStart_txt.Location = new System.Drawing.Point(372, 116);
            this.addStart_txt.Name = "addStart_txt";
            this.addStart_txt.Size = new System.Drawing.Size(100, 25);
            this.addStart_txt.TabIndex = 5;
            // 
            // addUser_txt
            // 
            this.addUser_txt.Location = new System.Drawing.Point(231, 116);
            this.addUser_txt.Name = "addUser_txt";
            this.addUser_txt.Size = new System.Drawing.Size(100, 25);
            this.addUser_txt.TabIndex = 6;
            // 
            // addEnd_txt
            // 
            this.addEnd_txt.Location = new System.Drawing.Point(519, 116);
            this.addEnd_txt.Name = "addEnd_txt";
            this.addEnd_txt.Size = new System.Drawing.Size(100, 25);
            this.addEnd_txt.TabIndex = 7;
            // 
            // conn_btn
            // 
            this.conn_btn.Location = new System.Drawing.Point(577, 35);
            this.conn_btn.Name = "conn_btn";
            this.conn_btn.Size = new System.Drawing.Size(78, 24);
            this.conn_btn.TabIndex = 8;
            this.conn_btn.Text = "连接";
            this.conn_btn.UseVisualStyleBackColor = true;
            this.conn_btn.Click += new System.EventHandler(this.conn_btn_Click);
            // 
            // createUser_btn
            // 
            this.createUser_btn.Location = new System.Drawing.Point(503, 173);
            this.createUser_btn.Name = "createUser_btn";
            this.createUser_btn.Size = new System.Drawing.Size(75, 23);
            this.createUser_btn.TabIndex = 9;
            this.createUser_btn.Text = "创建用户";
            this.createUser_btn.UseVisualStyleBackColor = true;
            this.createUser_btn.Click += new System.EventHandler(this.createUser_btn_Click);
            // 
            // deafulePass_txt
            // 
            this.deafulePass_txt.Location = new System.Drawing.Point(69, 186);
            this.deafulePass_txt.Name = "deafulePass_txt";
            this.deafulePass_txt.Size = new System.Drawing.Size(100, 25);
            this.deafulePass_txt.TabIndex = 10;
            this.deafulePass_txt.Text = "Yhc1234..";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 419);
            this.Controls.Add(this.deafulePass_txt);
            this.Controls.Add(this.createUser_btn);
            this.Controls.Add(this.conn_btn);
            this.Controls.Add(this.addEnd_txt);
            this.Controls.Add(this.addUser_txt);
            this.Controls.Add(this.addStart_txt);
            this.Controls.Add(this.ou_txt);
            this.Controls.Add(this.passwd_txt);
            this.Controls.Add(this.user_txt);
            this.Controls.Add(this.domain_host_txt);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
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
    }
}

