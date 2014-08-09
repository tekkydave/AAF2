namespace FocusTest
{
    partial class frmMain
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
            this.btnConnect = new System.Windows.Forms.Button();
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnClearLog = new System.Windows.Forms.Button();
            this.btnChoose = new System.Windows.Forms.Button();
            this.txtFocuser = new System.Windows.Forms.TextBox();
            this.txtPosition = new System.Windows.Forms.TextBox();
            this.btnDownN1 = new System.Windows.Forms.Button();
            this.btnUpN1 = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.txtStepsizeN1 = new System.Windows.Forms.TextBox();
            this.txtGoto = new System.Windows.Forms.TextBox();
            this.btnGoto = new System.Windows.Forms.Button();
            this.btnDownN2 = new System.Windows.Forms.Button();
            this.txtStepsizeN2 = new System.Windows.Forms.TextBox();
            this.btnUpN2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(13, 46);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(104, 23);
            this.btnConnect.TabIndex = 0;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // rtbLog
            // 
            this.rtbLog.HideSelection = false;
            this.rtbLog.Location = new System.Drawing.Point(13, 231);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.ReadOnly = true;
            this.rtbLog.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtbLog.Size = new System.Drawing.Size(485, 237);
            this.rtbLog.TabIndex = 1;
            this.rtbLog.Text = "";
            // 
            // btnDown
            // 
            this.btnDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnDown.Location = new System.Drawing.Point(171, 129);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(77, 27);
            this.btnDown.TabIndex = 2;
            this.btnDown.UseVisualStyleBackColor = false;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnUp
            // 
            this.btnUp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnUp.Location = new System.Drawing.Point(254, 129);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(77, 27);
            this.btnUp.TabIndex = 2;
            this.btnUp.UseVisualStyleBackColor = false;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnClearLog
            // 
            this.btnClearLog.Location = new System.Drawing.Point(427, 202);
            this.btnClearLog.Name = "btnClearLog";
            this.btnClearLog.Size = new System.Drawing.Size(75, 23);
            this.btnClearLog.TabIndex = 3;
            this.btnClearLog.Text = "Clear";
            this.btnClearLog.UseVisualStyleBackColor = true;
            this.btnClearLog.Click += new System.EventHandler(this.btnClearLog_Click);
            // 
            // btnChoose
            // 
            this.btnChoose.Location = new System.Drawing.Point(13, 13);
            this.btnChoose.Name = "btnChoose";
            this.btnChoose.Size = new System.Drawing.Size(104, 23);
            this.btnChoose.TabIndex = 4;
            this.btnChoose.Text = "Choose";
            this.btnChoose.UseVisualStyleBackColor = true;
            this.btnChoose.Click += new System.EventHandler(this.btnChoose_Click);
            // 
            // txtFocuser
            // 
            this.txtFocuser.Location = new System.Drawing.Point(134, 13);
            this.txtFocuser.Name = "txtFocuser";
            this.txtFocuser.ReadOnly = true;
            this.txtFocuser.Size = new System.Drawing.Size(317, 20);
            this.txtFocuser.TabIndex = 5;
            this.txtFocuser.TextChanged += new System.EventHandler(this.txtFocuser_TextChanged);
            // 
            // txtPosition
            // 
            this.txtPosition.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.txtPosition.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPosition.ForeColor = System.Drawing.Color.Blue;
            this.txtPosition.Location = new System.Drawing.Point(171, 46);
            this.txtPosition.Name = "txtPosition";
            this.txtPosition.ReadOnly = true;
            this.txtPosition.Size = new System.Drawing.Size(160, 29);
            this.txtPosition.TabIndex = 6;
            this.txtPosition.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPosition.TextChanged += new System.EventHandler(this.txtPosition_TextChanged);
            // 
            // btnDownN1
            // 
            this.btnDownN1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnDownN1.Location = new System.Drawing.Point(88, 129);
            this.btnDownN1.Name = "btnDownN1";
            this.btnDownN1.Size = new System.Drawing.Size(77, 27);
            this.btnDownN1.TabIndex = 2;
            this.btnDownN1.UseVisualStyleBackColor = false;
            this.btnDownN1.Click += new System.EventHandler(this.btnDownN1_Click);
            // 
            // btnUpN1
            // 
            this.btnUpN1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnUpN1.Location = new System.Drawing.Point(339, 129);
            this.btnUpN1.Name = "btnUpN1";
            this.btnUpN1.Size = new System.Drawing.Size(77, 27);
            this.btnUpN1.TabIndex = 7;
            this.btnUpN1.UseVisualStyleBackColor = false;
            this.btnUpN1.Click += new System.EventHandler(this.btnUpN1_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(13, 202);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(104, 23);
            this.btnExit.TabIndex = 8;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // txtStepsizeN1
            // 
            this.txtStepsizeN1.Location = new System.Drawing.Point(88, 162);
            this.txtStepsizeN1.Name = "txtStepsizeN1";
            this.txtStepsizeN1.Size = new System.Drawing.Size(77, 20);
            this.txtStepsizeN1.TabIndex = 9;
            this.txtStepsizeN1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtStepsizeN1.TextChanged += new System.EventHandler(this.txtStepsizeN1_TextChanged);
            // 
            // txtGoto
            // 
            this.txtGoto.Location = new System.Drawing.Point(203, 90);
            this.txtGoto.Name = "txtGoto";
            this.txtGoto.Size = new System.Drawing.Size(128, 20);
            this.txtGoto.TabIndex = 10;
            // 
            // btnGoto
            // 
            this.btnGoto.Location = new System.Drawing.Point(339, 90);
            this.btnGoto.Name = "btnGoto";
            this.btnGoto.Size = new System.Drawing.Size(49, 23);
            this.btnGoto.TabIndex = 11;
            this.btnGoto.Text = "Go To";
            this.btnGoto.UseVisualStyleBackColor = true;
            this.btnGoto.Click += new System.EventHandler(this.btnGoto_Click);
            // 
            // btnDownN2
            // 
            this.btnDownN2.BackColor = System.Drawing.Color.Red;
            this.btnDownN2.Location = new System.Drawing.Point(6, 129);
            this.btnDownN2.Name = "btnDownN2";
            this.btnDownN2.Size = new System.Drawing.Size(77, 27);
            this.btnDownN2.TabIndex = 12;
            this.btnDownN2.UseVisualStyleBackColor = false;
            this.btnDownN2.Click += new System.EventHandler(this.btnDownN2_Click);
            // 
            // txtStepsizeN2
            // 
            this.txtStepsizeN2.Location = new System.Drawing.Point(6, 162);
            this.txtStepsizeN2.Name = "txtStepsizeN2";
            this.txtStepsizeN2.Size = new System.Drawing.Size(75, 20);
            this.txtStepsizeN2.TabIndex = 13;
            this.txtStepsizeN2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtStepsizeN2.TextChanged += new System.EventHandler(this.txtStepsizeN2_TextChanged);
            // 
            // btnUpN2
            // 
            this.btnUpN2.BackColor = System.Drawing.Color.Lime;
            this.btnUpN2.Location = new System.Drawing.Point(425, 129);
            this.btnUpN2.Name = "btnUpN2";
            this.btnUpN2.Size = new System.Drawing.Size(77, 27);
            this.btnUpN2.TabIndex = 14;
            this.btnUpN2.UseVisualStyleBackColor = false;
            this.btnUpN2.Click += new System.EventHandler(this.btnUpN2_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 480);
            this.Controls.Add(this.btnUpN2);
            this.Controls.Add(this.txtStepsizeN2);
            this.Controls.Add(this.btnDownN2);
            this.Controls.Add(this.btnGoto);
            this.Controls.Add(this.txtGoto);
            this.Controls.Add(this.txtStepsizeN1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnUpN1);
            this.Controls.Add(this.txtPosition);
            this.Controls.Add(this.txtFocuser);
            this.Controls.Add(this.btnChoose);
            this.Controls.Add(this.btnClearLog);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.btnDownN1);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.rtbLog);
            this.Controls.Add(this.btnConnect);
            this.Name = "frmMain";
            this.Text = "FocusAAF2";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.RichTextBox rtbLog;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnClearLog;
        private System.Windows.Forms.Button btnChoose;
        private System.Windows.Forms.TextBox txtFocuser;
        private System.Windows.Forms.Button btnDownN1;
        private System.Windows.Forms.Button btnUpN1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.TextBox txtStepsizeN1;
        private System.Windows.Forms.TextBox txtGoto;
        private System.Windows.Forms.Button btnGoto;
        private System.Windows.Forms.Button btnDownN2;
        private System.Windows.Forms.TextBox txtStepsizeN2;
        private System.Windows.Forms.Button btnUpN2;
        private System.Windows.Forms.TextBox txtPosition;

    }
}

