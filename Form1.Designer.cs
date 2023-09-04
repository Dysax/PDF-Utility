namespace PDF_Combiner
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
            btnCombinePDF = new Button();
            btnAddFiles = new Button();
            btnMoveUp = new Button();
            btnMoveDown = new Button();
            lstPDFFiles = new ListBox();
            label1 = new Label();
            btnAddPdfForSeparation = new Button();
            lstPages = new ListBox();
            btnSeparatePdf = new Button();
            label2 = new Label();
            SuspendLayout();
            // 
            // btnCombinePDF
            // 
            btnCombinePDF.Location = new Point(35, 317);
            btnCombinePDF.Name = "btnCombinePDF";
            btnCombinePDF.Size = new Size(128, 41);
            btnCombinePDF.TabIndex = 0;
            btnCombinePDF.Text = "Combine PDFs";
            btnCombinePDF.UseVisualStyleBackColor = true;
            btnCombinePDF.Click += btnCombinePDF_Click;
            // 
            // btnAddFiles
            // 
            btnAddFiles.Location = new Point(35, 60);
            btnAddFiles.Name = "btnAddFiles";
            btnAddFiles.Size = new Size(93, 32);
            btnAddFiles.TabIndex = 1;
            btnAddFiles.Text = "Add Files";
            btnAddFiles.UseVisualStyleBackColor = true;
            btnAddFiles.Click += btnAddFiles_Click;
            // 
            // btnMoveUp
            // 
            btnMoveUp.Location = new Point(306, 250);
            btnMoveUp.Name = "btnMoveUp";
            btnMoveUp.Size = new Size(85, 28);
            btnMoveUp.TabIndex = 2;
            btnMoveUp.Text = "Move Up";
            btnMoveUp.UseVisualStyleBackColor = true;
            btnMoveUp.Click += btnMoveUp_Click;
            // 
            // btnMoveDown
            // 
            btnMoveDown.Location = new Point(306, 284);
            btnMoveDown.Name = "btnMoveDown";
            btnMoveDown.Size = new Size(85, 28);
            btnMoveDown.TabIndex = 3;
            btnMoveDown.Text = "Move Down";
            btnMoveDown.UseVisualStyleBackColor = true;
            btnMoveDown.Click += btnMoveDown_Click;
            // 
            // lstPDFFiles
            // 
            lstPDFFiles.FormattingEnabled = true;
            lstPDFFiles.ItemHeight = 15;
            lstPDFFiles.Location = new Point(35, 97);
            lstPDFFiles.Name = "lstPDFFiles";
            lstPDFFiles.Size = new Size(265, 214);
            lstPDFFiles.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(35, 32);
            label1.Name = "label1";
            label1.Size = new Size(84, 15);
            label1.TabIndex = 5;
            label1.Text = "PDF Combiner";
            label1.Click += label1_Click;
            // 
            // btnAddPdfForSeparation
            // 
            btnAddPdfForSeparation.Location = new Point(476, 59);
            btnAddPdfForSeparation.Name = "btnAddPdfForSeparation";
            btnAddPdfForSeparation.Size = new Size(93, 32);
            btnAddPdfForSeparation.TabIndex = 6;
            btnAddPdfForSeparation.Text = "Add Files";
            btnAddPdfForSeparation.UseVisualStyleBackColor = true;
            btnAddPdfForSeparation.Click += btnAddPDFForSeparation_Click;
            // 
            // lstPages
            // 
            lstPages.FormattingEnabled = true;
            lstPages.ItemHeight = 15;
            lstPages.Location = new Point(476, 97);
            lstPages.Name = "lstPages";
            lstPages.Size = new Size(250, 214);
            lstPages.TabIndex = 7;
            // 
            // btnSeparatePdf
            // 
            btnSeparatePdf.Location = new Point(476, 317);
            btnSeparatePdf.Name = "btnSeparatePdf";
            btnSeparatePdf.Size = new Size(128, 41);
            btnSeparatePdf.TabIndex = 8;
            btnSeparatePdf.Text = "Separate PDF";
            btnSeparatePdf.UseVisualStyleBackColor = true;
            btnSeparatePdf.Click += btnSeparatePDF_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(476, 32);
            label2.Name = "label2";
            label2.Size = new Size(81, 15);
            label2.TabIndex = 9;
            label2.Text = "PDF Separator";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label2);
            Controls.Add(btnSeparatePdf);
            Controls.Add(lstPages);
            Controls.Add(btnAddPdfForSeparation);
            Controls.Add(label1);
            Controls.Add(lstPDFFiles);
            Controls.Add(btnMoveDown);
            Controls.Add(btnMoveUp);
            Controls.Add(btnAddFiles);
            Controls.Add(btnCombinePDF);
            Name = "Form1";
            Text = "PDF Utility";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCombinePDF;
        private Button btnAddFiles;
        private Button btnMoveUp;
        private Button btnMoveDown;
        private ListBox lstPDFFiles;
        private Label label1;
        private Button btnAddPdfForSeparation;
        private ListBox lstPages;
        private Button btnSeparatePdf;
        private Label label2;
    }
}