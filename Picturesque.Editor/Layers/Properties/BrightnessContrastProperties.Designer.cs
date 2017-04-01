namespace Picturesque.Editor.Layers.Properties
{
	partial class BrightnessContrastProperties
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
			this.okBtn = new System.Windows.Forms.Button();
			this.cancelBtn = new System.Windows.Forms.Button();
			this.nameTb = new System.Windows.Forms.TextBox();
			this.nameLbl = new System.Windows.Forms.Label();
			this.brightnessTrackBar = new System.Windows.Forms.TrackBar();
			this.adjustmentBox = new System.Windows.Forms.GroupBox();
			this.contrastLbl = new System.Windows.Forms.Label();
			this.contrastValue = new System.Windows.Forms.NumericUpDown();
			this.contrastTrackBar = new System.Windows.Forms.TrackBar();
			this.brightnessLbl = new System.Windows.Forms.Label();
			this.brightnessValue = new System.Windows.Forms.NumericUpDown();
			this.brightnessWarning = new System.Windows.Forms.Label();
			this.contrastWarning = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.brightnessTrackBar)).BeginInit();
			this.adjustmentBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.contrastValue)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.contrastTrackBar)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.brightnessValue)).BeginInit();
			this.SuspendLayout();
			// 
			// okBtn
			// 
			this.okBtn.BackColor = System.Drawing.Color.Gray;
			this.okBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.okBtn.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
			this.okBtn.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
			this.okBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
			this.okBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.okBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.okBtn.ImageKey = "(none)";
			this.okBtn.Location = new System.Drawing.Point(54, 221);
			this.okBtn.Margin = new System.Windows.Forms.Padding(1);
			this.okBtn.Name = "okBtn";
			this.okBtn.Size = new System.Drawing.Size(64, 24);
			this.okBtn.TabIndex = 4;
			this.okBtn.Tag = "";
			this.okBtn.Text = "&OK";
			this.okBtn.UseVisualStyleBackColor = false;
			// 
			// cancelBtn
			// 
			this.cancelBtn.BackColor = System.Drawing.Color.Gray;
			this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelBtn.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
			this.cancelBtn.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
			this.cancelBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
			this.cancelBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.cancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cancelBtn.ImageKey = "(none)";
			this.cancelBtn.Location = new System.Drawing.Point(151, 221);
			this.cancelBtn.Margin = new System.Windows.Forms.Padding(1);
			this.cancelBtn.Name = "cancelBtn";
			this.cancelBtn.Size = new System.Drawing.Size(64, 24);
			this.cancelBtn.TabIndex = 5;
			this.cancelBtn.Tag = "";
			this.cancelBtn.Text = "&Cancel";
			this.cancelBtn.UseVisualStyleBackColor = false;
			// 
			// nameTb
			// 
			this.nameTb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.nameTb.Location = new System.Drawing.Point(12, 22);
			this.nameTb.Name = "nameTb";
			this.nameTb.Size = new System.Drawing.Size(156, 22);
			this.nameTb.TabIndex = 6;
			// 
			// nameLbl
			// 
			this.nameLbl.AutoSize = true;
			this.nameLbl.Location = new System.Drawing.Point(12, 9);
			this.nameLbl.Name = "nameLbl";
			this.nameLbl.Size = new System.Drawing.Size(38, 13);
			this.nameLbl.TabIndex = 8;
			this.nameLbl.Text = "Name:";
			// 
			// brightnessTrackBar
			// 
			this.brightnessTrackBar.AutoSize = false;
			this.brightnessTrackBar.Location = new System.Drawing.Point(6, 47);
			this.brightnessTrackBar.Maximum = 255;
			this.brightnessTrackBar.Minimum = -255;
			this.brightnessTrackBar.Name = "brightnessTrackBar";
			this.brightnessTrackBar.Size = new System.Drawing.Size(227, 28);
			this.brightnessTrackBar.TabIndex = 10;
			this.brightnessTrackBar.TickFrequency = 15;
			this.brightnessTrackBar.ValueChanged += new System.EventHandler(this.brightnessTrackBar_ValueChanged);
			// 
			// adjustmentBox
			// 
			this.adjustmentBox.Controls.Add(this.contrastLbl);
			this.adjustmentBox.Controls.Add(this.contrastWarning);
			this.adjustmentBox.Controls.Add(this.contrastValue);
			this.adjustmentBox.Controls.Add(this.contrastTrackBar);
			this.adjustmentBox.Controls.Add(this.brightnessLbl);
			this.adjustmentBox.Controls.Add(this.brightnessWarning);
			this.adjustmentBox.Controls.Add(this.brightnessValue);
			this.adjustmentBox.Controls.Add(this.brightnessTrackBar);
			this.adjustmentBox.ForeColor = System.Drawing.Color.White;
			this.adjustmentBox.Location = new System.Drawing.Point(12, 50);
			this.adjustmentBox.Name = "adjustmentBox";
			this.adjustmentBox.Size = new System.Drawing.Size(239, 154);
			this.adjustmentBox.TabIndex = 11;
			this.adjustmentBox.TabStop = false;
			this.adjustmentBox.Text = "Adjustments";
			// 
			// contrastLbl
			// 
			this.contrastLbl.AutoSize = true;
			this.contrastLbl.Location = new System.Drawing.Point(6, 85);
			this.contrastLbl.Name = "contrastLbl";
			this.contrastLbl.Size = new System.Drawing.Size(49, 13);
			this.contrastLbl.TabIndex = 15;
			this.contrastLbl.Text = "Contrast:";
			// 
			// contrastValue
			// 
			this.contrastValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.contrastValue.Location = new System.Drawing.Point(171, 81);
			this.contrastValue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
			this.contrastValue.Minimum = new decimal(new int[] {
            255,
            0,
            0,
            -2147483648});
			this.contrastValue.Name = "contrastValue";
			this.contrastValue.Size = new System.Drawing.Size(62, 22);
			this.contrastValue.TabIndex = 14;
			this.contrastValue.ValueChanged += new System.EventHandler(this.contrastValue_ValueChanged);
			// 
			// contrastTrackBar
			// 
			this.contrastTrackBar.AutoSize = false;
			this.contrastTrackBar.Location = new System.Drawing.Point(6, 109);
			this.contrastTrackBar.Maximum = 255;
			this.contrastTrackBar.Minimum = -255;
			this.contrastTrackBar.Name = "contrastTrackBar";
			this.contrastTrackBar.Size = new System.Drawing.Size(227, 28);
			this.contrastTrackBar.TabIndex = 13;
			this.contrastTrackBar.TickFrequency = 15;
			this.contrastTrackBar.ValueChanged += new System.EventHandler(this.contrastTrackBar_ValueChanged);
			// 
			// brightnessLbl
			// 
			this.brightnessLbl.AutoSize = true;
			this.brightnessLbl.Location = new System.Drawing.Point(6, 23);
			this.brightnessLbl.Name = "brightnessLbl";
			this.brightnessLbl.Size = new System.Drawing.Size(59, 13);
			this.brightnessLbl.TabIndex = 12;
			this.brightnessLbl.Text = "Brightness:";
			// 
			// brightnessValue
			// 
			this.brightnessValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.brightnessValue.Location = new System.Drawing.Point(171, 19);
			this.brightnessValue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
			this.brightnessValue.Minimum = new decimal(new int[] {
            255,
            0,
            0,
            -2147483648});
			this.brightnessValue.Name = "brightnessValue";
			this.brightnessValue.Size = new System.Drawing.Size(62, 22);
			this.brightnessValue.TabIndex = 11;
			this.brightnessValue.ValueChanged += new System.EventHandler(this.brightnessValue_ValueChanged);
			// 
			// brightnessWarning
			// 
			this.brightnessWarning.AutoSize = true;
			this.brightnessWarning.ForeColor = System.Drawing.Color.Orange;
			this.brightnessWarning.Location = new System.Drawing.Point(6, 36);
			this.brightnessWarning.Name = "brightnessWarning";
			this.brightnessWarning.Size = new System.Drawing.Size(105, 13);
			this.brightnessWarning.TabIndex = 16;
			this.brightnessWarning.Text = "Value is too extreme!";
			this.brightnessWarning.Visible = false;
			// 
			// contrastWarning
			// 
			this.contrastWarning.AutoSize = true;
			this.contrastWarning.ForeColor = System.Drawing.Color.Orange;
			this.contrastWarning.Location = new System.Drawing.Point(6, 98);
			this.contrastWarning.Name = "contrastWarning";
			this.contrastWarning.Size = new System.Drawing.Size(105, 13);
			this.contrastWarning.TabIndex = 17;
			this.contrastWarning.Text = "Value is too extreme!";
			this.contrastWarning.Visible = false;
			// 
			// BrightnessContrastProperties
			// 
			this.AcceptButton = this.okBtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.DimGray;
			this.CancelButton = this.cancelBtn;
			this.ClientSize = new System.Drawing.Size(266, 263);
			this.Controls.Add(this.adjustmentBox);
			this.Controls.Add(this.nameLbl);
			this.Controls.Add(this.nameTb);
			this.Controls.Add(this.cancelBtn);
			this.Controls.Add(this.okBtn);
			this.ForeColor = System.Drawing.Color.White;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "BrightnessContrastProperties";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Layer properties";
			((System.ComponentModel.ISupportInitialize)(this.brightnessTrackBar)).EndInit();
			this.adjustmentBox.ResumeLayout(false);
			this.adjustmentBox.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.contrastValue)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.contrastTrackBar)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.brightnessValue)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button okBtn;
		private System.Windows.Forms.Button cancelBtn;
		private System.Windows.Forms.TextBox nameTb;
		private System.Windows.Forms.Label nameLbl;
		private System.Windows.Forms.TrackBar brightnessTrackBar;
		private System.Windows.Forms.GroupBox adjustmentBox;
		private System.Windows.Forms.NumericUpDown brightnessValue;
		private System.Windows.Forms.Label brightnessLbl;
		private System.Windows.Forms.Label contrastLbl;
		private System.Windows.Forms.NumericUpDown contrastValue;
		private System.Windows.Forms.TrackBar contrastTrackBar;
		private System.Windows.Forms.Label brightnessWarning;
		private System.Windows.Forms.Label contrastWarning;
	}
}