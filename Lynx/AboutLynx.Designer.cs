namespace Lynx
{
    partial class AboutLynx
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutLynx));
            this.logo_pb = new System.Windows.Forms.PictureBox();
            this.logo_panel = new System.Windows.Forms.Panel();
            this.autor_lbl = new System.Windows.Forms.Label();
            this.autorName_lbl = new System.Windows.Forms.Label();
            this.product_lbl = new System.Windows.Forms.Label();
            this.productName_lbl = new System.Windows.Forms.Label();
            this.city_lbl = new System.Windows.Forms.Label();
            this.date_lbl = new System.Windows.Forms.Label();
            this.middlePanel = new System.Windows.Forms.Panel();
            this.version_lbl = new System.Windows.Forms.Label();
            this.aboutOk_btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.logo_pb)).BeginInit();
            this.logo_panel.SuspendLayout();
            this.middlePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // logo_pb
            // 
            this.logo_pb.ErrorImage = null;
            this.logo_pb.Image = global::Lynx.Properties.Resources.Lynx_logo_png;
            this.logo_pb.InitialImage = global::Lynx.Properties.Resources.Lynx_logo_png;
            this.logo_pb.Location = new System.Drawing.Point(45, -17);
            this.logo_pb.Name = "logo_pb";
            this.logo_pb.Size = new System.Drawing.Size(367, 280);
            this.logo_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.logo_pb.TabIndex = 0;
            this.logo_pb.TabStop = false;
            // 
            // logo_panel
            // 
            this.logo_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.logo_panel.Controls.Add(this.logo_pb);
            this.logo_panel.Location = new System.Drawing.Point(-16, -12);
            this.logo_panel.Name = "logo_panel";
            this.logo_panel.Size = new System.Drawing.Size(456, 216);
            this.logo_panel.TabIndex = 1;
            // 
            // autor_lbl
            // 
            this.autor_lbl.AutoSize = true;
            this.autor_lbl.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autor_lbl.Location = new System.Drawing.Point(151, 36);
            this.autor_lbl.Name = "autor_lbl";
            this.autor_lbl.Size = new System.Drawing.Size(48, 15);
            this.autor_lbl.TabIndex = 2;
            this.autor_lbl.Text = "Author:";
            // 
            // autorName_lbl
            // 
            this.autorName_lbl.AutoSize = true;
            this.autorName_lbl.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autorName_lbl.Location = new System.Drawing.Point(198, 36);
            this.autorName_lbl.Name = "autorName_lbl";
            this.autorName_lbl.Size = new System.Drawing.Size(94, 15);
            this.autorName_lbl.TabIndex = 2;
            this.autorName_lbl.Text = "Teodor Raychev";
            // 
            // product_lbl
            // 
            this.product_lbl.AutoSize = true;
            this.product_lbl.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.product_lbl.Location = new System.Drawing.Point(137, 66);
            this.product_lbl.Name = "product_lbl";
            this.product_lbl.Size = new System.Drawing.Size(55, 15);
            this.product_lbl.TabIndex = 2;
            this.product_lbl.Text = "Product:";
            // 
            // productName_lbl
            // 
            this.productName_lbl.AutoSize = true;
            this.productName_lbl.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productName_lbl.Location = new System.Drawing.Point(198, 66);
            this.productName_lbl.Name = "productName_lbl";
            this.productName_lbl.Size = new System.Drawing.Size(115, 15);
            this.productName_lbl.TabIndex = 2;
            this.productName_lbl.Text = "Lynx Graphic Editor ";
            // 
            // city_lbl
            // 
            this.city_lbl.AutoSize = true;
            this.city_lbl.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.city_lbl.Location = new System.Drawing.Point(187, 358);
            this.city_lbl.Name = "city_lbl";
            this.city_lbl.Size = new System.Drawing.Size(55, 16);
            this.city_lbl.TabIndex = 2;
            this.city_lbl.Text = "Plovdiv";
            // 
            // date_lbl
            // 
            this.date_lbl.AutoSize = true;
            this.date_lbl.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.date_lbl.Location = new System.Drawing.Point(196, 383);
            this.date_lbl.Name = "date_lbl";
            this.date_lbl.Size = new System.Drawing.Size(35, 15);
            this.date_lbl.TabIndex = 2;
            this.date_lbl.Text = "2017";
            // 
            // middlePanel
            // 
            this.middlePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.middlePanel.Controls.Add(this.version_lbl);
            this.middlePanel.Controls.Add(this.autor_lbl);
            this.middlePanel.Controls.Add(this.productName_lbl);
            this.middlePanel.Controls.Add(this.autorName_lbl);
            this.middlePanel.Controls.Add(this.product_lbl);
            this.middlePanel.Location = new System.Drawing.Point(-12, 200);
            this.middlePanel.Name = "middlePanel";
            this.middlePanel.Size = new System.Drawing.Size(471, 130);
            this.middlePanel.TabIndex = 3;
            // 
            // version_lbl
            // 
            this.version_lbl.AutoSize = true;
            this.version_lbl.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.version_lbl.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.version_lbl.Location = new System.Drawing.Point(186, 98);
            this.version_lbl.Name = "version_lbl";
            this.version_lbl.Size = new System.Drawing.Size(82, 15);
            this.version_lbl.TabIndex = 2;
            this.version_lbl.Text = "version 2.1.0.";
            // 
            // aboutOk_btn
            // 
            this.aboutOk_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.aboutOk_btn.Location = new System.Drawing.Point(178, 438);
            this.aboutOk_btn.Name = "aboutOk_btn";
            this.aboutOk_btn.Size = new System.Drawing.Size(75, 23);
            this.aboutOk_btn.TabIndex = 4;
            this.aboutOk_btn.Text = "Ok";
            this.aboutOk_btn.UseVisualStyleBackColor = true;
            this.aboutOk_btn.Click += new System.EventHandler(this.aboutOk_btn_Click);
            // 
            // AboutLynx
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 487);
            this.Controls.Add(this.aboutOk_btn);
            this.Controls.Add(this.logo_panel);
            this.Controls.Add(this.date_lbl);
            this.Controls.Add(this.city_lbl);
            this.Controls.Add(this.middlePanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "AboutLynx";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "About Lynx";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.AboutLynx_Load);
            ((System.ComponentModel.ISupportInitialize)(this.logo_pb)).EndInit();
            this.logo_panel.ResumeLayout(false);
            this.middlePanel.ResumeLayout(false);
            this.middlePanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox logo_pb;
        private System.Windows.Forms.Panel logo_panel;
        private System.Windows.Forms.Panel middlePanel;
        private System.Windows.Forms.Label autor_lbl;
        private System.Windows.Forms.Label autorName_lbl;
        private System.Windows.Forms.Label product_lbl;
        private System.Windows.Forms.Label productName_lbl;
        private System.Windows.Forms.Label city_lbl;
        private System.Windows.Forms.Label date_lbl;
        private System.Windows.Forms.Label version_lbl;
        private System.Windows.Forms.Button aboutOk_btn;
    }
}