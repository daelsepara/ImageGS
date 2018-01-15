namespace ImageGS
{
    partial class frmSpatialLightModulator
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
            this.SetBitmapButton = new System.Windows.Forms.Button();
            this.DetectButton = new System.Windows.Forms.Button();
            this.HeightLabel = new System.Windows.Forms.Label();
            this.SLMHeight = new System.Windows.Forms.NumericUpDown();
            this.WidthLabel = new System.Windows.Forms.Label();
            this.SLMWidth = new System.Windows.Forms.NumericUpDown();
            this.BitmapList = new System.Windows.Forms.ListBox();
            this.LeftLabel = new System.Windows.Forms.Label();
            this.SLMLeft = new System.Windows.Forms.NumericUpDown();
            this.TopLabel = new System.Windows.Forms.Label();
            this.SLMTop = new System.Windows.Forms.NumericUpDown();
            this.BitmapsLabel = new System.Windows.Forms.Label();
            this.HideButton = new System.Windows.Forms.Button();
            this.OffsetYLabel = new System.Windows.Forms.Label();
            this.OffsetY = new System.Windows.Forms.NumericUpDown();
            this.OffsetXLabel = new System.Windows.Forms.Label();
            this.OffsetX = new System.Windows.Forms.NumericUpDown();
            this.OffsetLabel = new System.Windows.Forms.Label();
            this.SLMWindowLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.SLMHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SLMWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SLMLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SLMTop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OffsetY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OffsetX)).BeginInit();
            this.SuspendLayout();
            // 
            // SetBitmapButton
            // 
            this.SetBitmapButton.Location = new System.Drawing.Point(375, 222);
            this.SetBitmapButton.Name = "SetBitmapButton";
            this.SetBitmapButton.Size = new System.Drawing.Size(120, 36);
            this.SetBitmapButton.TabIndex = 13;
            this.SetBitmapButton.Text = "Show";
            this.SetBitmapButton.UseVisualStyleBackColor = true;
            this.SetBitmapButton.Click += new System.EventHandler(this.SetBitmapButton_Click);
            // 
            // DetectButton
            // 
            this.DetectButton.Location = new System.Drawing.Point(36, 219);
            this.DetectButton.Name = "DetectButton";
            this.DetectButton.Size = new System.Drawing.Size(175, 39);
            this.DetectButton.TabIndex = 12;
            this.DetectButton.Text = "Detect";
            this.DetectButton.UseVisualStyleBackColor = true;
            this.DetectButton.Click += new System.EventHandler(this.DetectButton_Click);
            // 
            // HeightLabel
            // 
            this.HeightLabel.AutoSize = true;
            this.HeightLabel.Location = new System.Drawing.Point(32, 100);
            this.HeightLabel.Name = "HeightLabel";
            this.HeightLabel.Size = new System.Drawing.Size(49, 17);
            this.HeightLabel.TabIndex = 11;
            this.HeightLabel.Text = "Height";
            // 
            // SLMHeight
            // 
            this.SLMHeight.Location = new System.Drawing.Point(82, 100);
            this.SLMHeight.Name = "SLMHeight";
            this.SLMHeight.Size = new System.Drawing.Size(129, 22);
            this.SLMHeight.TabIndex = 10;
            this.SLMHeight.ValueChanged += new System.EventHandler(this.Height_ValueChanged);
            // 
            // WidthLabel
            // 
            this.WidthLabel.AutoSize = true;
            this.WidthLabel.Location = new System.Drawing.Point(32, 60);
            this.WidthLabel.Name = "WidthLabel";
            this.WidthLabel.Size = new System.Drawing.Size(44, 17);
            this.WidthLabel.TabIndex = 9;
            this.WidthLabel.Text = "Width";
            // 
            // SLMWidth
            // 
            this.SLMWidth.Location = new System.Drawing.Point(82, 60);
            this.SLMWidth.Name = "SLMWidth";
            this.SLMWidth.Size = new System.Drawing.Size(129, 22);
            this.SLMWidth.TabIndex = 8;
            this.SLMWidth.ValueChanged += new System.EventHandler(this.Width_ValueChanged);
            // 
            // BitmapList
            // 
            this.BitmapList.FormattingEnabled = true;
            this.BitmapList.ItemHeight = 16;
            this.BitmapList.Location = new System.Drawing.Point(235, 60);
            this.BitmapList.Name = "BitmapList";
            this.BitmapList.Size = new System.Drawing.Size(260, 84);
            this.BitmapList.TabIndex = 14;
            // 
            // LeftLabel
            // 
            this.LeftLabel.AutoSize = true;
            this.LeftLabel.Location = new System.Drawing.Point(32, 183);
            this.LeftLabel.Name = "LeftLabel";
            this.LeftLabel.Size = new System.Drawing.Size(32, 17);
            this.LeftLabel.TabIndex = 18;
            this.LeftLabel.Text = "Left";
            // 
            // SLMLeft
            // 
            this.SLMLeft.Location = new System.Drawing.Point(82, 183);
            this.SLMLeft.Name = "SLMLeft";
            this.SLMLeft.Size = new System.Drawing.Size(129, 22);
            this.SLMLeft.TabIndex = 17;
            this.SLMLeft.ValueChanged += new System.EventHandler(this.Left_ValueChanged);
            // 
            // TopLabel
            // 
            this.TopLabel.AutoSize = true;
            this.TopLabel.Location = new System.Drawing.Point(32, 143);
            this.TopLabel.Name = "TopLabel";
            this.TopLabel.Size = new System.Drawing.Size(33, 17);
            this.TopLabel.TabIndex = 16;
            this.TopLabel.Text = "Top";
            // 
            // SLMTop
            // 
            this.SLMTop.Location = new System.Drawing.Point(82, 143);
            this.SLMTop.Name = "SLMTop";
            this.SLMTop.Size = new System.Drawing.Size(129, 22);
            this.SLMTop.TabIndex = 15;
            this.SLMTop.ValueChanged += new System.EventHandler(this.Top_ValueChanged);
            // 
            // BitmapsLabel
            // 
            this.BitmapsLabel.AutoSize = true;
            this.BitmapsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BitmapsLabel.Location = new System.Drawing.Point(232, 28);
            this.BitmapsLabel.Name = "BitmapsLabel";
            this.BitmapsLabel.Size = new System.Drawing.Size(65, 17);
            this.BitmapsLabel.TabIndex = 19;
            this.BitmapsLabel.Text = "Bitmaps";
            // 
            // HideButton
            // 
            this.HideButton.Location = new System.Drawing.Point(235, 222);
            this.HideButton.Name = "HideButton";
            this.HideButton.Size = new System.Drawing.Size(120, 36);
            this.HideButton.TabIndex = 20;
            this.HideButton.Text = "Hide";
            this.HideButton.UseVisualStyleBackColor = true;
            this.HideButton.Click += new System.EventHandler(this.HideButton_Click);
            // 
            // OffsetYLabel
            // 
            this.OffsetYLabel.AutoSize = true;
            this.OffsetYLabel.Location = new System.Drawing.Point(310, 182);
            this.OffsetYLabel.Name = "OffsetYLabel";
            this.OffsetYLabel.Size = new System.Drawing.Size(17, 17);
            this.OffsetYLabel.TabIndex = 24;
            this.OffsetYLabel.Text = "Y";
            this.OffsetYLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // OffsetY
            // 
            this.OffsetY.Location = new System.Drawing.Point(333, 182);
            this.OffsetY.Name = "OffsetY";
            this.OffsetY.Size = new System.Drawing.Size(162, 22);
            this.OffsetY.TabIndex = 23;
            this.OffsetY.ValueChanged += new System.EventHandler(this.OffsetY_ValueChanged);
            // 
            // OffsetXLabel
            // 
            this.OffsetXLabel.AutoSize = true;
            this.OffsetXLabel.Location = new System.Drawing.Point(310, 150);
            this.OffsetXLabel.Name = "OffsetXLabel";
            this.OffsetXLabel.Size = new System.Drawing.Size(17, 17);
            this.OffsetXLabel.TabIndex = 22;
            this.OffsetXLabel.Text = "X";
            this.OffsetXLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // OffsetX
            // 
            this.OffsetX.Location = new System.Drawing.Point(333, 150);
            this.OffsetX.Name = "OffsetX";
            this.OffsetX.Size = new System.Drawing.Size(162, 22);
            this.OffsetX.TabIndex = 21;
            this.OffsetX.ValueChanged += new System.EventHandler(this.OffsetX_ValueChanged);
            // 
            // OffsetLabel
            // 
            this.OffsetLabel.AutoSize = true;
            this.OffsetLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OffsetLabel.Location = new System.Drawing.Point(237, 150);
            this.OffsetLabel.Name = "OffsetLabel";
            this.OffsetLabel.Size = new System.Drawing.Size(60, 17);
            this.OffsetLabel.TabIndex = 25;
            this.OffsetLabel.Text = "Offsets";
            // 
            // SLMWindowLabel
            // 
            this.SLMWindowLabel.AutoSize = true;
            this.SLMWindowLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SLMWindowLabel.Location = new System.Drawing.Point(33, 28);
            this.SLMWindowLabel.Name = "SLMWindowLabel";
            this.SLMWindowLabel.Size = new System.Drawing.Size(99, 17);
            this.SLMWindowLabel.TabIndex = 26;
            this.SLMWindowLabel.Text = "SLM Window";
            // 
            // frmSpatialLightModulator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 287);
            this.Controls.Add(this.SLMWindowLabel);
            this.Controls.Add(this.OffsetLabel);
            this.Controls.Add(this.OffsetYLabel);
            this.Controls.Add(this.OffsetY);
            this.Controls.Add(this.OffsetXLabel);
            this.Controls.Add(this.OffsetX);
            this.Controls.Add(this.HideButton);
            this.Controls.Add(this.BitmapsLabel);
            this.Controls.Add(this.LeftLabel);
            this.Controls.Add(this.SLMLeft);
            this.Controls.Add(this.TopLabel);
            this.Controls.Add(this.SLMTop);
            this.Controls.Add(this.BitmapList);
            this.Controls.Add(this.SetBitmapButton);
            this.Controls.Add(this.DetectButton);
            this.Controls.Add(this.HeightLabel);
            this.Controls.Add(this.SLMHeight);
            this.Controls.Add(this.WidthLabel);
            this.Controls.Add(this.SLMWidth);
            this.Name = "frmSpatialLightModulator";
            this.Text = "Spatial Light Modulator";
            this.Activated += new System.EventHandler(this.frmSpatialLightModulator_Activated);
            ((System.ComponentModel.ISupportInitialize)(this.SLMHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SLMWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SLMLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SLMTop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OffsetY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OffsetX)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SetBitmapButton;
        private System.Windows.Forms.Button DetectButton;
        private System.Windows.Forms.Label HeightLabel;
        private System.Windows.Forms.NumericUpDown SLMHeight;
        private System.Windows.Forms.Label WidthLabel;
        private System.Windows.Forms.NumericUpDown SLMWidth;
        private System.Windows.Forms.ListBox BitmapList;
        private System.Windows.Forms.Label LeftLabel;
        private System.Windows.Forms.NumericUpDown SLMLeft;
        private System.Windows.Forms.Label TopLabel;
        private System.Windows.Forms.NumericUpDown SLMTop;
        private System.Windows.Forms.Label BitmapsLabel;
        private System.Windows.Forms.Button HideButton;
        private System.Windows.Forms.Label OffsetYLabel;
        private System.Windows.Forms.NumericUpDown OffsetY;
        private System.Windows.Forms.Label OffsetXLabel;
        private System.Windows.Forms.NumericUpDown OffsetX;
        private System.Windows.Forms.Label OffsetLabel;
        private System.Windows.Forms.Label SLMWindowLabel;
    }
}