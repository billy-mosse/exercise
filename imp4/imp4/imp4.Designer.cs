namespace imp4
{
    partial class imp4
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose ( bool disposing )
        {
            if ( disposing && ( components != null ) )
            {
                components.Dispose ();
            }
            base.Dispose (disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent ( )
        {
            this.pctInput = new System.Windows.Forms.PictureBox();
            this.pctEdges = new System.Windows.Forms.PictureBox();
            this.btnUploadImage = new System.Windows.Forms.Button();
            this.btnCanny = new System.Windows.Forms.Button();
            this.dOpen = new System.Windows.Forms.OpenFileDialog();
            this.txtHighThreshold = new System.Windows.Forms.TextBox();
            this.lblHighThreshold = new System.Windows.Forms.Label();
            this.lblLowThreshold = new System.Windows.Forms.Label();
            this.txtLowThreshold = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pctInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctEdges)).BeginInit();
            this.SuspendLayout();
            // 
            // pctInput
            // 
            this.pctInput.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pctInput.Location = new System.Drawing.Point(12, 49);
            this.pctInput.Name = "pctInput";
            this.pctInput.Size = new System.Drawing.Size(330, 300);
            this.pctInput.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pctInput.TabIndex = 0;
            this.pctInput.TabStop = false;
            // 
            // pctEdges
            // 
            this.pctEdges.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pctEdges.Location = new System.Drawing.Point(542, 49);
            this.pctEdges.Name = "pctEdges";
            this.pctEdges.Size = new System.Drawing.Size(330, 300);
            this.pctEdges.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pctEdges.TabIndex = 1;
            this.pctEdges.TabStop = false;
            // 
            // btnUploadImage
            // 
            this.btnUploadImage.Location = new System.Drawing.Point(12, 12);
            this.btnUploadImage.Name = "btnUploadImage";
            this.btnUploadImage.Size = new System.Drawing.Size(75, 23);
            this.btnUploadImage.TabIndex = 2;
            this.btnUploadImage.Text = "Open";
            this.btnUploadImage.UseVisualStyleBackColor = true;
            this.btnUploadImage.Click += new System.EventHandler(this.btnUploadImage_Click);
            // 
            // btnCanny
            // 
            this.btnCanny.Location = new System.Drawing.Point(406, 265);
            this.btnCanny.Name = "btnCanny";
            this.btnCanny.Size = new System.Drawing.Size(75, 23);
            this.btnCanny.TabIndex = 4;
            this.btnCanny.Text = "Canny";
            this.btnCanny.UseVisualStyleBackColor = true;
            this.btnCanny.Click += new System.EventHandler(this.btnCanny_Click);
            // 
            // dOpen
            // 
            this.dOpen.FileName = "openFileDialog1";
            // 
            // txtHighThreshold
            // 
            this.txtHighThreshold.Location = new System.Drawing.Point(433, 239);
            this.txtHighThreshold.Name = "txtHighThreshold";
            this.txtHighThreshold.Size = new System.Drawing.Size(75, 20);
            this.txtHighThreshold.TabIndex = 5;
            this.txtHighThreshold.Text = "400";
            // 
            // lblHighThreshold
            // 
            this.lblHighThreshold.AutoSize = true;
            this.lblHighThreshold.Location = new System.Drawing.Point(352, 242);
            this.lblHighThreshold.Name = "lblHighThreshold";
            this.lblHighThreshold.Size = new System.Drawing.Size(75, 13);
            this.lblHighThreshold.TabIndex = 6;
            this.lblHighThreshold.Text = "High threshold";
            // 
            // lblLowThreshold
            // 
            this.lblLowThreshold.AutoSize = true;
            this.lblLowThreshold.Location = new System.Drawing.Point(352, 211);
            this.lblLowThreshold.Name = "lblLowThreshold";
            this.lblLowThreshold.Size = new System.Drawing.Size(73, 13);
            this.lblLowThreshold.TabIndex = 8;
            this.lblLowThreshold.Text = "Low threshold";
            // 
            // txtLowThreshold
            // 
            this.txtLowThreshold.Location = new System.Drawing.Point(433, 208);
            this.txtLowThreshold.Name = "txtLowThreshold";
            this.txtLowThreshold.Size = new System.Drawing.Size(75, 20);
            this.txtLowThreshold.TabIndex = 7;
            this.txtLowThreshold.Text = "80";
            // 
            // imp4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 362);
            this.Controls.Add(this.lblLowThreshold);
            this.Controls.Add(this.txtLowThreshold);
            this.Controls.Add(this.lblHighThreshold);
            this.Controls.Add(this.txtHighThreshold);
            this.Controls.Add(this.btnCanny);
            this.Controls.Add(this.btnUploadImage);
            this.Controls.Add(this.pctEdges);
            this.Controls.Add(this.pctInput);
            this.Name = "imp4";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Imp4";
            ((System.ComponentModel.ISupportInitialize)(this.pctInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctEdges)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pctInput;
        private System.Windows.Forms.PictureBox pctEdges;
        private System.Windows.Forms.Button btnUploadImage;
        private System.Windows.Forms.Button btnCanny;
        private System.Windows.Forms.OpenFileDialog dOpen;
        private System.Windows.Forms.TextBox txtHighThreshold;
        private System.Windows.Forms.Label lblHighThreshold;
        private System.Windows.Forms.Label lblLowThreshold;
        private System.Windows.Forms.TextBox txtLowThreshold;
    }
}

