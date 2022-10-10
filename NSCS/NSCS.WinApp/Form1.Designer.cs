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
            this.chkBosMachine.Location = new System.Drawing.Point(153, 129);
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
            this.chkPosMachine.Location = new System.Drawing.Point(295, 129);
            this.chkPosMachine.Name = "chkPosMachine";
            this.chkPosMachine.Size = new System.Drawing.Size(97, 19);
            this.chkPosMachine.TabIndex = 5;
            this.chkPosMachine.Text = "POS Machine";
            this.chkPosMachine.UseVisualStyleBackColor = true;
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(295, 235);
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
            this.lbResult.Items.AddRange(new object[] {
            "ibrahim",
            "arafeh"});
            this.lbResult.Location = new System.Drawing.Point(153, 342);
            this.lbResult.Name = "lbResult";
            this.lbResult.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lbResult.Size = new System.Drawing.Size(491, 199);
            this.lbResult.TabIndex = 7;
            this.lbResult.SelectedIndexChanged += new System.EventHandler(this.lbResult_SelectedIndexChanged);
            // 
            // chkGetDateInFile
            // 
            this.chkGetDateInFile.AutoSize = true;
            this.chkGetDateInFile.Location = new System.Drawing.Point(153, 167);
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
            this.lblProgress.Location = new System.Drawing.Point(348, 298);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(64, 20);
            this.lblProgress.TabIndex = 9;
            this.lblProgress.Text = "File Path";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 562);
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
    }
}