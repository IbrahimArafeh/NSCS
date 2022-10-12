namespace NSCS.WinApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkBosMachine = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.chkPosMachine = new System.Windows.Forms.CheckBox();
            this.btnRun = new System.Windows.Forms.Button();
            this.lbResult = new System.Windows.Forms.ListBox();
            this.chkGetDateInFile = new System.Windows.Forms.CheckBox();
            this.lblProgress = new System.Windows.Forms.Label();
            this.pb = new System.Windows.Forms.ProgressBar();
            this.chkAnyFileLike = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFileNameLike = new System.Windows.Forms.TextBox();
            this.rtbStationID = new System.Windows.Forms.RichTextBox();
            this.btnUpdateSts = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(153, 25);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(483, 23);
            this.txtSearch.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(73, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Search On";
            // 
            // chkBosMachine
            // 
            this.chkBosMachine.AutoSize = true;
            this.chkBosMachine.Location = new System.Drawing.Point(153, 199);
            this.chkBosMachine.Name = "chkBosMachine";
            this.chkBosMachine.Size = new System.Drawing.Size(97, 19);
            this.chkBosMachine.TabIndex = 2;
            this.chkBosMachine.Text = "BOS Machine";
            this.chkBosMachine.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(73, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "File Path";
            // 
            // txtFilePath
            // 
            this.txtFilePath.Location = new System.Drawing.Point(153, 72);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(483, 23);
            this.txtFilePath.TabIndex = 3;
            // 
            // chkPosMachine
            // 
            this.chkPosMachine.AutoSize = true;
            this.chkPosMachine.Location = new System.Drawing.Point(295, 199);
            this.chkPosMachine.Name = "chkPosMachine";
            this.chkPosMachine.Size = new System.Drawing.Size(97, 19);
            this.chkPosMachine.TabIndex = 5;
            this.chkPosMachine.Text = "POS Machine";
            this.chkPosMachine.UseVisualStyleBackColor = true;
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(295, 275);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(185, 39);
            this.btnRun.TabIndex = 6;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // lbResult
            // 
            this.lbResult.FormattingEnabled = true;
            this.lbResult.ItemHeight = 15;
            this.lbResult.Location = new System.Drawing.Point(153, 412);
            this.lbResult.Name = "lbResult";
            this.lbResult.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lbResult.Size = new System.Drawing.Size(491, 199);
            this.lbResult.TabIndex = 7;
            this.lbResult.SelectedIndexChanged += new System.EventHandler(this.lbResult_SelectedIndexChanged);
            // 
            // chkGetDateInFile
            // 
            this.chkGetDateInFile.AutoSize = true;
            this.chkGetDateInFile.Location = new System.Drawing.Point(153, 237);
            this.chkGetDateInFile.Name = "chkGetDateInFile";
            this.chkGetDateInFile.Size = new System.Drawing.Size(71, 19);
            this.chkGetDateInFile.TabIndex = 8;
            this.chkGetDateInFile.Text = "Get Date";
            this.chkGetDateInFile.UseVisualStyleBackColor = true;
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblProgress.Location = new System.Drawing.Point(320, 330);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(64, 20);
            this.lblProgress.TabIndex = 9;
            this.lblProgress.Text = "File Path";
            this.lblProgress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pb
            // 
            this.pb.ForeColor = System.Drawing.Color.LimeGreen;
            this.pb.Location = new System.Drawing.Point(153, 370);
            this.pb.Name = "pb";
            this.pb.Size = new System.Drawing.Size(483, 23);
            this.pb.Step = 1;
            this.pb.TabIndex = 10;
            // 
            // chkAnyFileLike
            // 
            this.chkAnyFileLike.AutoSize = true;
            this.chkAnyFileLike.Location = new System.Drawing.Point(295, 237);
            this.chkAnyFileLike.Name = "chkAnyFileLike";
            this.chkAnyFileLike.Size = new System.Drawing.Size(92, 19);
            this.chkAnyFileLike.TabIndex = 11;
            this.chkAnyFileLike.Text = "Any File Like";
            this.chkAnyFileLike.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(50, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 15);
            this.label3.TabIndex = 13;
            this.label3.Text = "File Name Like";
            // 
            // txtFileNameLike
            // 
            this.txtFileNameLike.Location = new System.Drawing.Point(153, 120);
            this.txtFileNameLike.Name = "txtFileNameLike";
            this.txtFileNameLike.Size = new System.Drawing.Size(483, 23);
            this.txtFileNameLike.TabIndex = 12;
            // 
            // rtbStationID
            // 
            this.rtbStationID.Location = new System.Drawing.Point(684, 51);
            this.rtbStationID.Name = "rtbStationID";
            this.rtbStationID.Size = new System.Drawing.Size(152, 277);
            this.rtbStationID.TabIndex = 14;
            this.rtbStationID.Text = "";
            // 
            // btnUpdateSts
            // 
            this.btnUpdateSts.Location = new System.Drawing.Point(697, 334);
            this.btnUpdateSts.Name = "btnUpdateSts";
            this.btnUpdateSts.Size = new System.Drawing.Size(123, 39);
            this.btnUpdateSts.TabIndex = 15;
            this.btnUpdateSts.Text = "Update Stations";
            this.btnUpdateSts.UseVisualStyleBackColor = true;
            this.btnUpdateSts.Click += new System.EventHandler(this.btnUpdateSts_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 651);
            this.Controls.Add(this.btnUpdateSts);
            this.Controls.Add(this.rtbStationID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtFileNameLike);
            this.Controls.Add(this.chkAnyFileLike);
            this.Controls.Add(this.pb);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.chkGetDateInFile);
            this.Controls.Add(this.lbResult);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.chkPosMachine);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtFilePath);
            this.Controls.Add(this.chkBosMachine);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSearch);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox txtSearch;
        private Label label1;
        private CheckBox chkBosMachine;
        private Label label2;
        private TextBox txtFilePath;
        private CheckBox chkPosMachine;
        private Button btnRun;
        public ListBox lbResult;
        private CheckBox chkGetDateInFile;
        private Label lblProgress;
        private ProgressBar pb;
        private CheckBox chkAnyFileLike;
        private Label label3;
        private TextBox txtFileNameLike;
        private RichTextBox rtbStationID;
        private Button btnUpdateSts;
    }
}