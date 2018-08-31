namespace ImageGS
{
    partial class frmGerchbergSaxton
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
            this.algorithmParameters = new System.Windows.Forms.GroupBox();
            this.TargetImageResizeType = new System.Windows.Forms.GroupBox();
            this.CropTarget = new System.Windows.Forms.RadioButton();
            this.ResizeTarget = new System.Windows.Forms.RadioButton();
            this.iterationsLabel = new System.Windows.Forms.Label();
            this.Iterations = new System.Windows.Forms.NumericUpDown();
            this.OutputHologramProperties = new System.Windows.Forms.GroupBox();
            this.SaveHologramButton = new System.Windows.Forms.Button();
            this.CalculateButton = new System.Windows.Forms.Button();
            this.heightLabel = new System.Windows.Forms.Label();
            this.OutputHeight = new System.Windows.Forms.NumericUpDown();
            this.widthLabel = new System.Windows.Forms.Label();
            this.OutputWidth = new System.Windows.Forms.NumericUpDown();
            this.algorithmParameters.SuspendLayout();
            this.TargetImageResizeType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Iterations)).BeginInit();
            this.OutputHologramProperties.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OutputHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OutputWidth)).BeginInit();
            this.SuspendLayout();
            // 
            // algorithmParameters
            // 
            this.algorithmParameters.Controls.Add(this.TargetImageResizeType);
            this.algorithmParameters.Controls.Add(this.iterationsLabel);
            this.algorithmParameters.Controls.Add(this.Iterations);
            this.algorithmParameters.Location = new System.Drawing.Point(12, 12);
            this.algorithmParameters.Name = "algorithmParameters";
            this.algorithmParameters.Size = new System.Drawing.Size(472, 172);
            this.algorithmParameters.TabIndex = 0;
            this.algorithmParameters.TabStop = false;
            this.algorithmParameters.Text = "Parameters";
            // 
            // TargetImageResizeType
            // 
            this.TargetImageResizeType.Controls.Add(this.CropTarget);
            this.TargetImageResizeType.Controls.Add(this.ResizeTarget);
            this.TargetImageResizeType.Location = new System.Drawing.Point(15, 58);
            this.TargetImageResizeType.Name = "TargetImageResizeType";
            this.TargetImageResizeType.Size = new System.Drawing.Size(198, 93);
            this.TargetImageResizeType.TabIndex = 2;
            this.TargetImageResizeType.TabStop = false;
            this.TargetImageResizeType.Text = "Target Image";
            // 
            // CropTarget
            // 
            this.CropTarget.AutoSize = true;
            this.CropTarget.Location = new System.Drawing.Point(22, 58);
            this.CropTarget.Name = "CropTarget";
            this.CropTarget.Size = new System.Drawing.Size(59, 21);
            this.CropTarget.TabIndex = 1;
            this.CropTarget.TabStop = true;
            this.CropTarget.Text = "Crop";
            this.CropTarget.UseVisualStyleBackColor = true;
            // 
            // ResizeTarget
            // 
            this.ResizeTarget.AutoSize = true;
            this.ResizeTarget.Location = new System.Drawing.Point(22, 31);
            this.ResizeTarget.Name = "ResizeTarget";
            this.ResizeTarget.Size = new System.Drawing.Size(72, 21);
            this.ResizeTarget.TabIndex = 0;
            this.ResizeTarget.TabStop = true;
            this.ResizeTarget.Text = "Resize";
            this.ResizeTarget.UseVisualStyleBackColor = true;
            // 
            // iterationsLabel
            // 
            this.iterationsLabel.AutoSize = true;
            this.iterationsLabel.Location = new System.Drawing.Point(12, 32);
            this.iterationsLabel.Name = "iterationsLabel";
            this.iterationsLabel.Size = new System.Drawing.Size(66, 17);
            this.iterationsLabel.TabIndex = 1;
            this.iterationsLabel.Text = "Iterations";
            // 
            // Iterations
            // 
            this.Iterations.Location = new System.Drawing.Point(84, 30);
            this.Iterations.Name = "Iterations";
            this.Iterations.Size = new System.Drawing.Size(129, 22);
            this.Iterations.TabIndex = 0;
            // 
            // OutputHologramProperties
            // 
            this.OutputHologramProperties.Controls.Add(this.SaveHologramButton);
            this.OutputHologramProperties.Controls.Add(this.CalculateButton);
            this.OutputHologramProperties.Controls.Add(this.heightLabel);
            this.OutputHologramProperties.Controls.Add(this.OutputHeight);
            this.OutputHologramProperties.Controls.Add(this.widthLabel);
            this.OutputHologramProperties.Controls.Add(this.OutputWidth);
            this.OutputHologramProperties.Location = new System.Drawing.Point(11, 198);
            this.OutputHologramProperties.Name = "OutputHologramProperties";
            this.OutputHologramProperties.Size = new System.Drawing.Size(472, 228);
            this.OutputHologramProperties.TabIndex = 1;
            this.OutputHologramProperties.TabStop = false;
            this.OutputHologramProperties.Text = "Output Hologram";
            // 
            // SaveHologramButton
            // 
            this.SaveHologramButton.Location = new System.Drawing.Point(223, 156);
            this.SaveHologramButton.Name = "SaveHologramButton";
            this.SaveHologramButton.Size = new System.Drawing.Size(162, 36);
            this.SaveHologramButton.TabIndex = 7;
            this.SaveHologramButton.Text = "Save Hologram";
            this.SaveHologramButton.UseVisualStyleBackColor = true;
            this.SaveHologramButton.Click += new System.EventHandler(this.SaveHologramButton_Click);
            // 
            // CalculateButton
            // 
            this.CalculateButton.Location = new System.Drawing.Point(39, 154);
            this.CalculateButton.Name = "CalculateButton";
            this.CalculateButton.Size = new System.Drawing.Size(175, 39);
            this.CalculateButton.TabIndex = 6;
            this.CalculateButton.Text = "Calculate";
            this.CalculateButton.UseVisualStyleBackColor = true;
            this.CalculateButton.Click += new System.EventHandler(this.CalculateButton_Click);
            // 
            // heightLabel
            // 
            this.heightLabel.AutoSize = true;
            this.heightLabel.Location = new System.Drawing.Point(35, 83);
            this.heightLabel.Name = "heightLabel";
            this.heightLabel.Size = new System.Drawing.Size(49, 17);
            this.heightLabel.TabIndex = 5;
            this.heightLabel.Text = "Height";
            // 
            // OutputHeight
            // 
            this.OutputHeight.Location = new System.Drawing.Point(85, 83);
            this.OutputHeight.Name = "OutputHeight";
            this.OutputHeight.Size = new System.Drawing.Size(129, 22);
            this.OutputHeight.TabIndex = 4;
            this.OutputHeight.ValueChanged += new System.EventHandler(this.OutputHeight_ValueChanged);
            // 
            // widthLabel
            // 
            this.widthLabel.AutoSize = true;
            this.widthLabel.Location = new System.Drawing.Point(35, 43);
            this.widthLabel.Name = "widthLabel";
            this.widthLabel.Size = new System.Drawing.Size(44, 17);
            this.widthLabel.TabIndex = 3;
            this.widthLabel.Text = "Width";
            // 
            // OutputWidth
            // 
            this.OutputWidth.Location = new System.Drawing.Point(85, 43);
            this.OutputWidth.Name = "OutputWidth";
            this.OutputWidth.Size = new System.Drawing.Size(129, 22);
            this.OutputWidth.TabIndex = 2;
            this.OutputWidth.ValueChanged += new System.EventHandler(this.OutputWidth_ValueChanged);
            // 
            // frmGerchbergSaxton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 455);
            this.Controls.Add(this.OutputHologramProperties);
            this.Controls.Add(this.algorithmParameters);
            this.Name = "frmGerchbergSaxton";
            this.Text = "Gerchberg-Saxton Algorithm";
            this.Activated += new System.EventHandler(this.frmGerchbergSaxton_Activated);
            this.algorithmParameters.ResumeLayout(false);
            this.algorithmParameters.PerformLayout();
            this.TargetImageResizeType.ResumeLayout(false);
            this.TargetImageResizeType.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Iterations)).EndInit();
            this.OutputHologramProperties.ResumeLayout(false);
            this.OutputHologramProperties.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OutputHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OutputWidth)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox algorithmParameters;
        private System.Windows.Forms.GroupBox OutputHologramProperties;
        private System.Windows.Forms.NumericUpDown Iterations;
        private System.Windows.Forms.Label iterationsLabel;
        private System.Windows.Forms.Label widthLabel;
        private System.Windows.Forms.NumericUpDown OutputWidth;
        private System.Windows.Forms.Label heightLabel;
        private System.Windows.Forms.NumericUpDown OutputHeight;
        private System.Windows.Forms.GroupBox TargetImageResizeType;
        private System.Windows.Forms.RadioButton ResizeTarget;
        private System.Windows.Forms.RadioButton CropTarget;
        private System.Windows.Forms.Button CalculateButton;
        private System.Windows.Forms.Button SaveHologramButton;
    }
}
