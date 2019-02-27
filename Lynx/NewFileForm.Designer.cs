namespace Lynx
{
    partial class NewFileForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewFileForm));
            this.pnlFileName = new System.Windows.Forms.Panel();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.lblFileName = new System.Windows.Forms.Label();
            this.pnlCanvasSize = new System.Windows.Forms.Panel();
            this.txtCanvasWidth = new System.Windows.Forms.TextBox();
            this.txtCanvasHeight = new System.Windows.Forms.TextBox();
            this.btnCanvasHeight = new System.Windows.Forms.Label();
            this.lblPxSize2 = new System.Windows.Forms.Label();
            this.lblPxSize1 = new System.Windows.Forms.Label();
            this.lblCanvasWidth = new System.Windows.Forms.Label();
            this.lblCanvasSize = new System.Windows.Forms.Label();
            this.btnNewFileOk = new System.Windows.Forms.Button();
            this.btnNewFileCancel = new System.Windows.Forms.Button();
            this.pnlFileName.SuspendLayout();
            this.pnlCanvasSize.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlFileName
            // 
            this.pnlFileName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFileName.Controls.Add(this.txtFileName);
            this.pnlFileName.Controls.Add(this.lblFileName);
            this.pnlFileName.Location = new System.Drawing.Point(12, 12);
            this.pnlFileName.Name = "pnlFileName";
            this.pnlFileName.Size = new System.Drawing.Size(363, 52);
            this.pnlFileName.TabIndex = 0;
            // 
            // txtFileName
            // 
            this.txtFileName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFileName.Location = new System.Drawing.Point(77, 11);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(254, 20);
            this.txtFileName.TabIndex = 1;
            this.txtFileName.Text = "Untitled";
            this.txtFileName.Validating += new System.ComponentModel.CancelEventHandler(this.txtFileNameValidating);
            // 
            // lblFileName
            // 
            this.lblFileName.AutoSize = true;
            this.lblFileName.Location = new System.Drawing.Point(13, 14);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(58, 13);
            this.lblFileName.TabIndex = 0;
            this.lblFileName.Text = "FIle Name:";
            // 
            // pnlCanvasSize
            // 
            this.pnlCanvasSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCanvasSize.Controls.Add(this.txtCanvasWidth);
            this.pnlCanvasSize.Controls.Add(this.txtCanvasHeight);
            this.pnlCanvasSize.Controls.Add(this.btnCanvasHeight);
            this.pnlCanvasSize.Controls.Add(this.lblPxSize2);
            this.pnlCanvasSize.Controls.Add(this.lblPxSize1);
            this.pnlCanvasSize.Controls.Add(this.lblCanvasWidth);
            this.pnlCanvasSize.Controls.Add(this.lblCanvasSize);
            this.pnlCanvasSize.Location = new System.Drawing.Point(12, 70);
            this.pnlCanvasSize.Name = "pnlCanvasSize";
            this.pnlCanvasSize.Size = new System.Drawing.Size(363, 180);
            this.pnlCanvasSize.TabIndex = 1;
            // 
            // txtCanvasWidth
            // 
            this.txtCanvasWidth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCanvasWidth.Location = new System.Drawing.Point(149, 67);
            this.txtCanvasWidth.Name = "txtCanvasWidth";
            this.txtCanvasWidth.Size = new System.Drawing.Size(71, 20);
            this.txtCanvasWidth.TabIndex = 3;
            this.txtCanvasWidth.Text = "800";
            this.txtCanvasWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCanvasWidth.Validating += new System.ComponentModel.CancelEventHandler(this.txtCanvasWidthValidation);
            // 
            // txtCanvasHeight
            // 
            this.txtCanvasHeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCanvasHeight.Location = new System.Drawing.Point(149, 109);
            this.txtCanvasHeight.Name = "txtCanvasHeight";
            this.txtCanvasHeight.Size = new System.Drawing.Size(71, 20);
            this.txtCanvasHeight.TabIndex = 3;
            this.txtCanvasHeight.Text = "600";
            this.txtCanvasHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCanvasHeight.Validating += new System.ComponentModel.CancelEventHandler(this.txtCanvasHeightValidation);
            // 
            // btnCanvasHeight
            // 
            this.btnCanvasHeight.AutoSize = true;
            this.btnCanvasHeight.Location = new System.Drawing.Point(55, 112);
            this.btnCanvasHeight.Name = "btnCanvasHeight";
            this.btnCanvasHeight.Size = new System.Drawing.Size(80, 13);
            this.btnCanvasHeight.TabIndex = 2;
            this.btnCanvasHeight.Text = "Canvas Height:";
            // 
            // lblPxSize2
            // 
            this.lblPxSize2.AutoSize = true;
            this.lblPxSize2.Enabled = false;
            this.lblPxSize2.Location = new System.Drawing.Point(226, 112);
            this.lblPxSize2.Name = "lblPxSize2";
            this.lblPxSize2.Size = new System.Drawing.Size(18, 13);
            this.lblPxSize2.TabIndex = 2;
            this.lblPxSize2.Text = "px";
            // 
            // lblPxSize1
            // 
            this.lblPxSize1.AutoSize = true;
            this.lblPxSize1.Enabled = false;
            this.lblPxSize1.ForeColor = System.Drawing.Color.Black;
            this.lblPxSize1.Location = new System.Drawing.Point(226, 69);
            this.lblPxSize1.Name = "lblPxSize1";
            this.lblPxSize1.Size = new System.Drawing.Size(18, 13);
            this.lblPxSize1.TabIndex = 2;
            this.lblPxSize1.Text = "px";
            // 
            // lblCanvasWidth
            // 
            this.lblCanvasWidth.AutoSize = true;
            this.lblCanvasWidth.Location = new System.Drawing.Point(55, 67);
            this.lblCanvasWidth.Name = "lblCanvasWidth";
            this.lblCanvasWidth.Size = new System.Drawing.Size(77, 13);
            this.lblCanvasWidth.TabIndex = 2;
            this.lblCanvasWidth.Text = "Canvas Width:";
            // 
            // lblCanvasSize
            // 
            this.lblCanvasSize.AutoSize = true;
            this.lblCanvasSize.Location = new System.Drawing.Point(151, 18);
            this.lblCanvasSize.Name = "lblCanvasSize";
            this.lblCanvasSize.Size = new System.Drawing.Size(69, 13);
            this.lblCanvasSize.TabIndex = 2;
            this.lblCanvasSize.Text = "Canvas Size:";
            // 
            // btnNewFileOk
            // 
            this.btnNewFileOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnNewFileOk.Location = new System.Drawing.Point(401, 12);
            this.btnNewFileOk.Name = "btnNewFileOk";
            this.btnNewFileOk.Size = new System.Drawing.Size(75, 23);
            this.btnNewFileOk.TabIndex = 2;
            this.btnNewFileOk.Text = "Ok";
            this.btnNewFileOk.UseVisualStyleBackColor = true;
            this.btnNewFileOk.Click += new System.EventHandler(this.newFileOk_Click);
            // 
            // btnNewFileCancel
            // 
            this.btnNewFileCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnNewFileCancel.Location = new System.Drawing.Point(401, 41);
            this.btnNewFileCancel.Name = "btnNewFileCancel";
            this.btnNewFileCancel.Size = new System.Drawing.Size(75, 23);
            this.btnNewFileCancel.TabIndex = 2;
            this.btnNewFileCancel.Text = "Cancel";
            this.btnNewFileCancel.UseVisualStyleBackColor = true;
            this.btnNewFileCancel.Click += new System.EventHandler(this.newFileCancel_Click);
            // 
            // NewFileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnNewFileCancel;
            this.ClientSize = new System.Drawing.Size(497, 261);
            this.Controls.Add(this.btnNewFileCancel);
            this.Controls.Add(this.btnNewFileOk);
            this.Controls.Add(this.pnlCanvasSize);
            this.Controls.Add(this.pnlFileName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NewFileForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New File ";
            this.TopMost = true;
            this.pnlFileName.ResumeLayout(false);
            this.pnlFileName.PerformLayout();
            this.pnlCanvasSize.ResumeLayout(false);
            this.pnlCanvasSize.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlFileName;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.Panel pnlCanvasSize;
        private System.Windows.Forms.Button btnNewFileOk;
        private System.Windows.Forms.Button btnNewFileCancel;
        private System.Windows.Forms.TextBox txtCanvasWidth;
        private System.Windows.Forms.TextBox txtCanvasHeight;
        private System.Windows.Forms.Label btnCanvasHeight;
        private System.Windows.Forms.Label lblPxSize2;
        private System.Windows.Forms.Label lblPxSize1;
        private System.Windows.Forms.Label lblCanvasWidth;
        private System.Windows.Forms.Label lblCanvasSize;
    }
}