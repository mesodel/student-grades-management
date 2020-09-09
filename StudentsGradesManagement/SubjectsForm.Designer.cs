namespace StudentsGradesManagement
{
    partial class SubjectsForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SubjectsForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnUpdateSj = new System.Windows.Forms.Button();
            this.btnAddSubject = new System.Windows.Forms.Button();
            this.tbGrade = new System.Windows.Forms.TextBox();
            this.tbSjName = new System.Windows.Forms.TextBox();
            this.tbSjCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lvSubjects = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.epCode = new System.Windows.Forms.ErrorProvider(this.components);
            this.epGrade = new System.Windows.Forms.ErrorProvider(this.components);
            this.epSjName = new System.Windows.Forms.ErrorProvider(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printPreviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.btnStrat = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epGrade)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epSjName)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnStrat);
            this.groupBox1.Controls.Add(this.btnExport);
            this.groupBox1.Controls.Add(this.btnUpdateSj);
            this.groupBox1.Controls.Add(this.btnAddSubject);
            this.groupBox1.Controls.Add(this.tbGrade);
            this.groupBox1.Controls.Add(this.tbSjName);
            this.groupBox1.Controls.Add(this.tbSjCode);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(34, 37);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(706, 156);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "New Subject";
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(608, 118);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 8;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnUpdateSj
            // 
            this.btnUpdateSj.Location = new System.Drawing.Point(501, 118);
            this.btnUpdateSj.Name = "btnUpdateSj";
            this.btnUpdateSj.Size = new System.Drawing.Size(75, 23);
            this.btnUpdateSj.TabIndex = 7;
            this.btnUpdateSj.Text = "Update";
            this.btnUpdateSj.UseVisualStyleBackColor = true;
            this.btnUpdateSj.Click += new System.EventHandler(this.btnUpdateSj_Click);
            // 
            // btnAddSubject
            // 
            this.btnAddSubject.Location = new System.Drawing.Point(386, 118);
            this.btnAddSubject.Name = "btnAddSubject";
            this.btnAddSubject.Size = new System.Drawing.Size(75, 23);
            this.btnAddSubject.TabIndex = 6;
            this.btnAddSubject.Text = "Add ";
            this.btnAddSubject.UseVisualStyleBackColor = true;
            this.btnAddSubject.Click += new System.EventHandler(this.btnAddSubject_Click);
            // 
            // tbGrade
            // 
            this.tbGrade.Location = new System.Drawing.Point(508, 74);
            this.tbGrade.Name = "tbGrade";
            this.tbGrade.Size = new System.Drawing.Size(100, 22);
            this.tbGrade.TabIndex = 5;
            this.tbGrade.Validating += new System.ComponentModel.CancelEventHandler(this.tbGrade_Validating);
            this.tbGrade.Validated += new System.EventHandler(this.tbGrade_Validated);
            // 
            // tbSjName
            // 
            this.tbSjName.Location = new System.Drawing.Point(278, 74);
            this.tbSjName.Name = "tbSjName";
            this.tbSjName.Size = new System.Drawing.Size(100, 22);
            this.tbSjName.TabIndex = 4;
            this.tbSjName.Validating += new System.ComponentModel.CancelEventHandler(this.tbSjName_Validating);
            this.tbSjName.Validated += new System.EventHandler(this.tbSjName_Validated);
            // 
            // tbSjCode
            // 
            this.tbSjCode.Location = new System.Drawing.Point(52, 74);
            this.tbSjCode.Name = "tbSjCode";
            this.tbSjCode.Size = new System.Drawing.Size(100, 22);
            this.tbSjCode.TabIndex = 3;
            this.tbSjCode.Validating += new System.ComponentModel.CancelEventHandler(this.tbSjCode_Validating);
            this.tbSjCode.Validated += new System.EventHandler(this.tbSjCode_Validated);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(528, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Grade";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(282, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Subject Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = " Subject Code";
            // 
            // lvSubjects
            // 
            this.lvSubjects.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvSubjects.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lvSubjects.FullRowSelect = true;
            this.lvSubjects.GridLines = true;
            this.lvSubjects.Location = new System.Drawing.Point(34, 199);
            this.lvSubjects.Name = "lvSubjects";
            this.lvSubjects.Size = new System.Drawing.Size(706, 239);
            this.lvSubjects.TabIndex = 1;
            this.lvSubjects.UseCompatibleStateImageBehavior = false;
            this.lvSubjects.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Subject Code";
            this.columnHeader1.Width = 209;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Subject Name";
            this.columnHeader2.Width = 259;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Grade";
            this.columnHeader3.Width = 231;
            // 
            // epCode
            // 
            this.epCode.ContainerControl = this;
            // 
            // epGrade
            // 
            this.epGrade.ContainerControl = this;
            // 
            // epSjName
            // 
            this.epSjName.ContainerControl = this;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(756, 28);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.printToolStripMenuItem,
            this.printPreviewToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.Size = new System.Drawing.Size(169, 26);
            this.printToolStripMenuItem.Text = "Print";
            this.printToolStripMenuItem.Click += new System.EventHandler(this.printToolStripMenuItem_Click);
            // 
            // printPreviewToolStripMenuItem
            // 
            this.printPreviewToolStripMenuItem.Name = "printPreviewToolStripMenuItem";
            this.printPreviewToolStripMenuItem.Size = new System.Drawing.Size(169, 26);
            this.printPreviewToolStripMenuItem.Text = "Print Preview";
            this.printPreviewToolStripMenuItem.Click += new System.EventHandler(this.printPreviewToolStripMenuItem_Click);
            // 
            // printDocument1
            // 
            this.printDocument1.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.printDocument1_BeginPrint);
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // btnStrat
            // 
            this.btnStrat.Location = new System.Drawing.Point(285, 118);
            this.btnStrat.Name = "btnStrat";
            this.btnStrat.Size = new System.Drawing.Size(79, 23);
            this.btnStrat.TabIndex = 9;
            this.btnStrat.Text = "Statistics";
            this.btnStrat.UseVisualStyleBackColor = true;
            this.btnStrat.Click += new System.EventHandler(this.btnStrat_Click);
            // 
            // SubjectsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(756, 450);
            this.Controls.Add(this.lvSubjects);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "SubjectsForm";
            this.Text = "SubjectsForm";
            this.Load += new System.EventHandler(this.SubjectsForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SubjectsForm_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epGrade)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epSjName)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lvSubjects;
        private System.Windows.Forms.Button btnAddSubject;
        private System.Windows.Forms.TextBox tbGrade;
        private System.Windows.Forms.TextBox tbSjName;
        private System.Windows.Forms.TextBox tbSjCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ErrorProvider epCode;
        private System.Windows.Forms.ErrorProvider epGrade;
        private System.Windows.Forms.ErrorProvider epSjName;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button btnUpdateSj;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printPreviewToolStripMenuItem;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.Button btnStrat;
    }
}