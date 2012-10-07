namespace PSTAT
{
    partial class Main_Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main_Form));
            this.loginButton = new System.Windows.Forms.Button();
            this.setableUsername = new System.Windows.Forms.TextBox();
            this.setablePassword = new System.Windows.Forms.TextBox();
            this.Login = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.PrintGroup = new System.Windows.Forms.GroupBox();
            this.setableListBox = new System.Windows.Forms.ListBox();
            this.setableSearchUser = new System.Windows.Forms.TextBox();
            this.setableUpdated = new System.Windows.Forms.Label();
            this.refreshLogs = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Login.SuspendLayout();
            this.PrintGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // loginButton
            // 
            this.loginButton.Location = new System.Drawing.Point(199, 141);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(75, 23);
            this.loginButton.TabIndex = 0;
            this.loginButton.Text = "Login";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.loginbutton_click);
            // 
            // setableUsername
            // 
            this.setableUsername.Location = new System.Drawing.Point(123, 74);
            this.setableUsername.MaxLength = 20;
            this.setableUsername.Name = "setableUsername";
            this.setableUsername.Size = new System.Drawing.Size(151, 20);
            this.setableUsername.TabIndex = 0;
            // 
            // setablePassword
            // 
            this.setablePassword.Location = new System.Drawing.Point(123, 109);
            this.setablePassword.MaxLength = 10;
            this.setablePassword.Name = "setablePassword";
            this.setablePassword.Size = new System.Drawing.Size(151, 20);
            this.setablePassword.TabIndex = 1;
            this.setablePassword.UseSystemPasswordChar = true;
            this.setablePassword.KeyUp += new System.Windows.Forms.KeyEventHandler(this.setablePassword_KeyUp);
            // 
            // Login
            // 
            this.Login.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Login.Controls.Add(this.label2);
            this.Login.Controls.Add(this.label1);
            this.Login.Controls.Add(this.loginButton);
            this.Login.Controls.Add(this.setableUsername);
            this.Login.Controls.Add(this.setablePassword);
            this.Login.Location = new System.Drawing.Point(160, 115);
            this.Login.Name = "Login";
            this.Login.Size = new System.Drawing.Size(280, 170);
            this.Login.TabIndex = 3;
            this.Login.TabStop = false;
            this.Login.Text = "Login";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Username";
            // 
            // PrintGroup
            // 
            this.PrintGroup.Controls.Add(this.setableListBox);
            this.PrintGroup.Controls.Add(this.setableSearchUser);
            this.PrintGroup.Controls.Add(this.setableUpdated);
            this.PrintGroup.Controls.Add(this.refreshLogs);
            this.PrintGroup.Controls.Add(this.comboBox1);
            this.PrintGroup.Location = new System.Drawing.Point(12, 75);
            this.PrintGroup.Name = "PrintGroup";
            this.PrintGroup.Size = new System.Drawing.Size(560, 274);
            this.PrintGroup.TabIndex = 6;
            this.PrintGroup.TabStop = false;
            this.PrintGroup.Text = "Printers";
            // 
            // setableListBox
            // 
            this.setableListBox.FormattingEnabled = true;
            this.setableListBox.Location = new System.Drawing.Point(6, 52);
            this.setableListBox.Name = "setableListBox";
            this.setableListBox.Size = new System.Drawing.Size(548, 212);
            this.setableListBox.TabIndex = 4;
            // 
            // setableSearchUser
            // 
            this.setableSearchUser.Location = new System.Drawing.Point(191, 16);
            this.setableSearchUser.Name = "setableSearchUser";
            this.setableSearchUser.Size = new System.Drawing.Size(100, 20);
            this.setableSearchUser.TabIndex = 3;
            this.setableSearchUser.Text = "Enter Username";
            this.setableSearchUser.TextChanged += new System.EventHandler(this.setableSearchUser_TextChanged);
            this.setableSearchUser.Enter += new System.EventHandler(this.setableSearchUser_Enter);
            // 
            // setableUpdated
            // 
            this.setableUpdated.AutoSize = true;
            this.setableUpdated.Location = new System.Drawing.Point(314, 19);
            this.setableUpdated.Name = "setableUpdated";
            this.setableUpdated.Size = new System.Drawing.Size(74, 13);
            this.setableUpdated.TabIndex = 2;
            this.setableUpdated.Text = "Last Updated:";
            // 
            // refreshLogs
            // 
            this.refreshLogs.Image = global::PSTAT.Properties.Resources.refresh;
            this.refreshLogs.Location = new System.Drawing.Point(515, 10);
            this.refreshLogs.Name = "refreshLogs";
            this.refreshLogs.Size = new System.Drawing.Size(39, 37);
            this.refreshLogs.TabIndex = 1;
            this.refreshLogs.UseVisualStyleBackColor = true;
            this.refreshLogs.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "vcpalw"});
            this.comboBox1.Location = new System.Drawing.Point(6, 16);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(166, 21);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectionChangeCommitted);
            this.comboBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.comboBox1_KeyUp);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackgroundImage = global::PSTAT.Properties.Resources.art;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(81, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(422, 69);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 342);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(182, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Written by Dan Berkowitz 10/5/2012";
            // 
            // Main_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Login);
            this.Controls.Add(this.PrintGroup);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main_Form";
            this.Text = "RPI - PSTAT";
            this.Login.ResumeLayout(false);
            this.Login.PerformLayout();
            this.PrintGroup.ResumeLayout(false);
            this.PrintGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.TextBox setableUsername;
        private System.Windows.Forms.TextBox setablePassword;
        private System.Windows.Forms.GroupBox Login;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox PrintGroup;
        private System.Windows.Forms.Button refreshLogs;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label setableUpdated;
        private System.Windows.Forms.TextBox setableSearchUser;
        private System.Windows.Forms.ListBox setableListBox;
        private System.Windows.Forms.Label label4;
    }
}

