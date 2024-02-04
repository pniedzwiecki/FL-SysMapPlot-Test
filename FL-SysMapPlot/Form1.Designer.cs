namespace FL_SysMapPlot
{
    partial class Form1
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
            this.btnSelFolder = new System.Windows.Forms.Button();
            this.btnSelFiles = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnProcessFiles = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.revDatePick = new System.Windows.Forms.DateTimePicker();
            this.chkDefaultComment = new System.Windows.Forms.CheckBox();
            this.chkAddRev = new System.Windows.Forms.CheckBox();
            this.txtRevComment = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.rTxtInfo = new System.Windows.Forms.RichTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblFLC3DVersion = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSelFolder
            // 
            this.btnSelFolder.Location = new System.Drawing.Point(14, 19);
            this.btnSelFolder.Name = "btnSelFolder";
            this.btnSelFolder.Size = new System.Drawing.Size(91, 23);
            this.btnSelFolder.TabIndex = 0;
            this.btnSelFolder.Text = "Select Folder";
            this.btnSelFolder.UseVisualStyleBackColor = true;
            this.btnSelFolder.Click += new System.EventHandler(this.btnSelFolder_Click);
            // 
            // btnSelFiles
            // 
            this.btnSelFiles.Location = new System.Drawing.Point(260, 19);
            this.btnSelFiles.Name = "btnSelFiles";
            this.btnSelFiles.Size = new System.Drawing.Size(91, 23);
            this.btnSelFiles.TabIndex = 1;
            this.btnSelFiles.Text = "Select Files";
            this.btnSelFiles.UseVisualStyleBackColor = true;
            this.btnSelFiles.Click += new System.EventHandler(this.btnSelFiles_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(207, 217);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "E&xit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnProcessFiles
            // 
            this.btnProcessFiles.Location = new System.Drawing.Point(111, 217);
            this.btnProcessFiles.Name = "btnProcessFiles";
            this.btnProcessFiles.Size = new System.Drawing.Size(90, 23);
            this.btnProcessFiles.TabIndex = 3;
            this.btnProcessFiles.Text = "Process Files";
            this.btnProcessFiles.UseVisualStyleBackColor = true;
            this.btnProcessFiles.Click += new System.EventHandler(this.btnProcessFiles_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.revDatePick);
            this.groupBox1.Controls.Add(this.chkDefaultComment);
            this.groupBox1.Controls.Add(this.chkAddRev);
            this.groupBox1.Controls.Add(this.txtRevComment);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(17, 76);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(363, 135);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Revision Options";
            // 
            // revDatePick
            // 
            this.revDatePick.CustomFormat = "MM/dd/yyyy";
            this.revDatePick.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.revDatePick.Location = new System.Drawing.Point(112, 42);
            this.revDatePick.Name = "revDatePick";
            this.revDatePick.Size = new System.Drawing.Size(116, 20);
            this.revDatePick.TabIndex = 18;
            this.revDatePick.ValueChanged += new System.EventHandler(this.revDatePick_ValueChanged);
            // 
            // chkDefaultComment
            // 
            this.chkDefaultComment.AutoSize = true;
            this.chkDefaultComment.Location = new System.Drawing.Point(14, 82);
            this.chkDefaultComment.Name = "chkDefaultComment";
            this.chkDefaultComment.Size = new System.Drawing.Size(107, 17);
            this.chkDefaultComment.TabIndex = 17;
            this.chkDefaultComment.Text = "Default Comment";
            this.chkDefaultComment.UseVisualStyleBackColor = true;
            this.chkDefaultComment.CheckedChanged += new System.EventHandler(this.chkDefaultComment_CheckedChanged);
            // 
            // chkAddRev
            // 
            this.chkAddRev.AutoSize = true;
            this.chkAddRev.Location = new System.Drawing.Point(14, 19);
            this.chkAddRev.Name = "chkAddRev";
            this.chkAddRev.Size = new System.Drawing.Size(89, 17);
            this.chkAddRev.TabIndex = 15;
            this.chkAddRev.Text = "Add Revision";
            this.chkAddRev.UseVisualStyleBackColor = true;
            this.chkAddRev.CheckedChanged += new System.EventHandler(this.chkAddRev_CheckedChanged);
            // 
            // txtRevComment
            // 
            this.txtRevComment.Location = new System.Drawing.Point(112, 105);
            this.txtRevComment.Name = "txtRevComment";
            this.txtRevComment.Size = new System.Drawing.Size(239, 20);
            this.txtRevComment.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Revision Comment:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Revision Date:";
            // 
            // rTxtInfo
            // 
            this.rTxtInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rTxtInfo.Location = new System.Drawing.Point(12, 246);
            this.rTxtInfo.Name = "rTxtInfo";
            this.rTxtInfo.ReadOnly = true;
            this.rTxtInfo.Size = new System.Drawing.Size(368, 237);
            this.rTxtInfo.TabIndex = 7;
            this.rTxtInfo.Text = "";
            this.rTxtInfo.WordWrap = false;
            this.rTxtInfo.TextChanged += new System.EventHandler(this.rTxtInfo_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSelFiles);
            this.groupBox2.Controls.Add(this.btnSelFolder);
            this.groupBox2.Location = new System.Drawing.Point(17, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(363, 58);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Select Folder/Files";
            // 
            // lblFLC3DVersion
            // 
            this.lblFLC3DVersion.AutoSize = true;
            this.lblFLC3DVersion.Location = new System.Drawing.Point(14, 490);
            this.lblFLC3DVersion.Name = "lblFLC3DVersion";
            this.lblFLC3DVersion.Size = new System.Drawing.Size(56, 13);
            this.lblFLC3DVersion.TabIndex = 13;
            this.lblFLC3DVersion.Text = "WadeTrim";
            // 
            // lblVersion
            // 
            this.lblVersion.Location = new System.Drawing.Point(261, 490);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(119, 13);
            this.lblVersion.TabIndex = 14;
            this.lblVersion.Text = "Version 2.0";
            this.lblVersion.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(392, 510);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.lblFLC3DVersion);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.rTxtInfo);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnProcessFiles);
            this.Controls.Add(this.btnExit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Form1";
            this.Text = "Ford Land System Map Plot Utility";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSelFolder;
        private System.Windows.Forms.Button btnSelFiles;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnProcessFiles;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtRevComment;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.CheckBox chkAddRev;
        private System.Windows.Forms.CheckBox chkDefaultComment;
        private System.Windows.Forms.RichTextBox rTxtInfo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker revDatePick;
        private System.Windows.Forms.Label lblFLC3DVersion;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

