using System.Windows.Forms;

namespace ImageGS
{
    partial class ImageGSForm
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
            this.ImagePages = new System.Windows.Forms.TabControl();
            this.TargetImagePage = new System.Windows.Forms.TabPage();
            this.OpenImageButton = new System.Windows.Forms.Button();
            this.TargetImage = new System.Windows.Forms.PictureBox();
            this.PhaseImagePage = new System.Windows.Forms.TabPage();
            this.SLMButton = new System.Windows.Forms.Button();
            this.GSButton = new System.Windows.Forms.Button();
            this.PhaseImage = new System.Windows.Forms.PictureBox();
            this.ImageGSTimer = new System.Windows.Forms.Timer(this.components);
            this.ImagePages.SuspendLayout();
            this.TargetImagePage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TargetImage)).BeginInit();
            this.PhaseImagePage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PhaseImage)).BeginInit();
            this.SuspendLayout();
            // 
            // ImagePages
            // 
            this.ImagePages.Controls.Add(this.TargetImagePage);
            this.ImagePages.Controls.Add(this.PhaseImagePage);
            this.ImagePages.Location = new System.Drawing.Point(13, 13);
            this.ImagePages.Name = "ImagePages";
            this.ImagePages.SelectedIndex = 0;
            this.ImagePages.Size = new System.Drawing.Size(500, 500);
            this.ImagePages.TabIndex = 0;
            // 
            // TargetImagePage
            // 
            this.TargetImagePage.BackColor = System.Drawing.Color.Transparent;
            this.TargetImagePage.Controls.Add(this.OpenImageButton);
            this.TargetImagePage.Controls.Add(this.TargetImage);
            this.TargetImagePage.Location = new System.Drawing.Point(4, 25);
            this.TargetImagePage.Name = "TargetImagePage";
            this.TargetImagePage.Padding = new System.Windows.Forms.Padding(3);
            this.TargetImagePage.Size = new System.Drawing.Size(492, 471);
            this.TargetImagePage.TabIndex = 0;
            this.TargetImagePage.Text = "Target Image";
            // 
            // OpenImageButton
            // 
            this.OpenImageButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OpenImageButton.Location = new System.Drawing.Point(38, 407);
            this.OpenImageButton.Name = "OpenImageButton";
            this.OpenImageButton.Size = new System.Drawing.Size(109, 52);
            this.OpenImageButton.TabIndex = 1;
            this.OpenImageButton.Text = "Open";
            this.OpenImageButton.UseVisualStyleBackColor = true;
            this.OpenImageButton.Click += new System.EventHandler(this.OpenImageButton_Click);
            // 
            // TargetImage
            // 
            this.TargetImage.BackColor = System.Drawing.Color.Transparent;
            this.TargetImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TargetImage.Location = new System.Drawing.Point(38, 17);
            this.TargetImage.Name = "TargetImage";
            this.TargetImage.Size = new System.Drawing.Size(384, 384);
            this.TargetImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.TargetImage.TabIndex = 0;
            this.TargetImage.TabStop = false;
            // 
            // PhaseImagePage
            // 
            this.PhaseImagePage.BackColor = System.Drawing.Color.Transparent;
            this.PhaseImagePage.Controls.Add(this.SLMButton);
            this.PhaseImagePage.Controls.Add(this.GSButton);
            this.PhaseImagePage.Controls.Add(this.PhaseImage);
            this.PhaseImagePage.Location = new System.Drawing.Point(4, 25);
            this.PhaseImagePage.Name = "PhaseImagePage";
            this.PhaseImagePage.Padding = new System.Windows.Forms.Padding(3);
            this.PhaseImagePage.Size = new System.Drawing.Size(492, 471);
            this.PhaseImagePage.TabIndex = 1;
            this.PhaseImagePage.Text = "Phase";
            // 
            // SLMButton
            // 
            this.SLMButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SLMButton.Location = new System.Drawing.Point(153, 407);
            this.SLMButton.Name = "SLMButton";
            this.SLMButton.Size = new System.Drawing.Size(109, 52);
            this.SLMButton.TabIndex = 3;
            this.SLMButton.Text = "SLM";
            this.SLMButton.UseVisualStyleBackColor = true;
            this.SLMButton.Click += new System.EventHandler(this.SLMButton_Click);
            // 
            // GSButton
            // 
            this.GSButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GSButton.Location = new System.Drawing.Point(38, 407);
            this.GSButton.Name = "GSButton";
            this.GSButton.Size = new System.Drawing.Size(109, 52);
            this.GSButton.TabIndex = 2;
            this.GSButton.Text = "Calculate";
            this.GSButton.UseVisualStyleBackColor = true;
            this.GSButton.Click += new System.EventHandler(this.GSButton_Click);
            // 
            // PhaseImage
            // 
            this.PhaseImage.BackColor = System.Drawing.Color.Transparent;
            this.PhaseImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PhaseImage.Location = new System.Drawing.Point(38, 17);
            this.PhaseImage.Name = "PhaseImage";
            this.PhaseImage.Size = new System.Drawing.Size(384, 384);
            this.PhaseImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PhaseImage.TabIndex = 1;
            this.PhaseImage.TabStop = false;
            // 
            // ImageGSTimer
            // 
            this.ImageGSTimer.Enabled = true;
            this.ImageGSTimer.Tick += new System.EventHandler(this.ImageGSTimer_Tick);
            // 
            // ImageGSForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 553);
            this.Controls.Add(this.ImagePages);
            this.Name = "ImageGSForm";
            this.Text = "ImageGS";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ImageGSForm_FormClosing);
            this.ImagePages.ResumeLayout(false);
            this.TargetImagePage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TargetImage)).EndInit();
            this.PhaseImagePage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PhaseImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl ImagePages;
        private System.Windows.Forms.TabPage TargetImagePage;
        private System.Windows.Forms.TabPage PhaseImagePage;
        private System.Windows.Forms.PictureBox TargetImage;
        private System.Windows.Forms.Button OpenImageButton;
        private System.Windows.Forms.PictureBox PhaseImage;
        private System.Windows.Forms.Button GSButton;
        private System.Windows.Forms.Button SLMButton;
        private System.Windows.Forms.Timer ImageGSTimer;

        private void ImageGSForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            CleanShutdown();
        }
    }
}

