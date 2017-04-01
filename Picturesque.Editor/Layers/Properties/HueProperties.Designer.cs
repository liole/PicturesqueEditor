namespace Picturesque.Editor.Layers.Properties
{
	partial class HueProperties
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
			this.hueTrackBar = new System.Windows.Forms.TrackBar();
			this.adjustmentBox = new System.Windows.Forms.GroupBox();
			this.colorizeChkBox = new System.Windows.Forms.CheckBox();
			this.lightnessLbl = new System.Windows.Forms.Label();
			this.lightnessValue = new System.Windows.Forms.NumericUpDown();
			this.lightnessTrackBar = new System.Windows.Forms.TrackBar();
			this.saturationLbl = new System.Windows.Forms.Label();
			this.saturationValue = new System.Windows.Forms.NumericUpDown();
			this.saturationTrackBar = new System.Windows.Forms.TrackBar();
			this.hueLbl = new System.Windows.Forms.Label();
			this.hueValue = new System.Windows.Forms.NumericUpDown();
			this.autoUpdate = new System.Windows.Forms.CheckBox();
			((System.ComponentModel.ISupportInitialize)(this.hueTrackBar)).BeginInit();
			this.adjustmentBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.lightnessValue)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lightnessTrackBar)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.saturationValue)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.saturationTrackBar)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.hueValue)).BeginInit();
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
			this.okBtn.Location = new System.Drawing.Point(53, 284);
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
			this.cancelBtn.Location = new System.Drawing.Point(150, 284);
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
			// hueTrackBar
			// 
			this.hueTrackBar.AutoSize = false;
			this.hueTrackBar.Location = new System.Drawing.Point(6, 47);
			this.hueTrackBar.Maximum = 180;
			this.hueTrackBar.Minimum = -180;
			this.hueTrackBar.Name = "hueTrackBar";
			this.hueTrackBar.Size = new System.Drawing.Size(227, 28);
			this.hueTrackBar.TabIndex = 10;
			this.hueTrackBar.TickFrequency = 12;
			this.hueTrackBar.ValueChanged += new System.EventHandler(this.hueTrackBar_ValueChanged);
			// 
			// adjustmentBox
			// 
			this.adjustmentBox.Controls.Add(this.colorizeChkBox);
			this.adjustmentBox.Controls.Add(this.lightnessLbl);
			this.adjustmentBox.Controls.Add(this.lightnessValue);
			this.adjustmentBox.Controls.Add(this.lightnessTrackBar);
			this.adjustmentBox.Controls.Add(this.saturationLbl);
			this.adjustmentBox.Controls.Add(this.saturationValue);
			this.adjustmentBox.Controls.Add(this.saturationTrackBar);
			this.adjustmentBox.Controls.Add(this.hueLbl);
			this.adjustmentBox.Controls.Add(this.hueValue);
			this.adjustmentBox.Controls.Add(this.hueTrackBar);
			this.adjustmentBox.ForeColor = System.Drawing.Color.White;
			this.adjustmentBox.Location = new System.Drawing.Point(12, 50);
			this.adjustmentBox.Name = "adjustmentBox";
			this.adjustmentBox.Size = new System.Drawing.Size(239, 220);
			this.adjustmentBox.TabIndex = 11;
			this.adjustmentBox.TabStop = false;
			this.adjustmentBox.Text = "Adjustments";
			// 
			// colorizeChkBox
			// 
			this.colorizeChkBox.AutoSize = true;
			this.colorizeChkBox.Location = new System.Drawing.Point(42, 22);
			this.colorizeChkBox.Name = "colorizeChkBox";
			this.colorizeChkBox.Size = new System.Drawing.Size(63, 17);
			this.colorizeChkBox.TabIndex = 19;
			this.colorizeChkBox.Text = "Colorize";
			this.colorizeChkBox.UseVisualStyleBackColor = true;
			this.colorizeChkBox.CheckedChanged += new System.EventHandler(this.colorizeChkBox_CheckedChanged);
			// 
			// lightnessLbl
			// 
			this.lightnessLbl.AutoSize = true;
			this.lightnessLbl.Location = new System.Drawing.Point(6, 147);
			this.lightnessLbl.Name = "lightnessLbl";
			this.lightnessLbl.Size = new System.Drawing.Size(55, 13);
			this.lightnessLbl.TabIndex = 18;
			this.lightnessLbl.Text = "Lightness:";
			// 
			// lightnessValue
			// 
			this.lightnessValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lightnessValue.Location = new System.Drawing.Point(171, 143);
			this.lightnessValue.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
			this.lightnessValue.Name = "lightnessValue";
			this.lightnessValue.Size = new System.Drawing.Size(62, 22);
			this.lightnessValue.TabIndex = 17;
			this.lightnessValue.ValueChanged += new System.EventHandler(this.lightnessValue_ValueChanged);
			// 
			// lightnessTrackBar
			// 
			this.lightnessTrackBar.AutoSize = false;
			this.lightnessTrackBar.Location = new System.Drawing.Point(6, 171);
			this.lightnessTrackBar.Maximum = 100;
			this.lightnessTrackBar.Minimum = -100;
			this.lightnessTrackBar.Name = "lightnessTrackBar";
			this.lightnessTrackBar.Size = new System.Drawing.Size(227, 28);
			this.lightnessTrackBar.TabIndex = 16;
			this.lightnessTrackBar.TickFrequency = 10;
			this.lightnessTrackBar.ValueChanged += new System.EventHandler(this.lightnessTrackBar_ValueChanged);
			// 
			// saturationLbl
			// 
			this.saturationLbl.AutoSize = true;
			this.saturationLbl.Location = new System.Drawing.Point(6, 85);
			this.saturationLbl.Name = "saturationLbl";
			this.saturationLbl.Size = new System.Drawing.Size(58, 13);
			this.saturationLbl.TabIndex = 15;
			this.saturationLbl.Text = "Saturation:";
			// 
			// saturationValue
			// 
			this.saturationValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.saturationValue.Location = new System.Drawing.Point(171, 81);
			this.saturationValue.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
			this.saturationValue.Name = "saturationValue";
			this.saturationValue.Size = new System.Drawing.Size(62, 22);
			this.saturationValue.TabIndex = 14;
			this.saturationValue.ValueChanged += new System.EventHandler(this.saturationValue_ValueChanged);
			// 
			// saturationTrackBar
			// 
			this.saturationTrackBar.AutoSize = false;
			this.saturationTrackBar.Location = new System.Drawing.Point(6, 109);
			this.saturationTrackBar.Maximum = 100;
			this.saturationTrackBar.Minimum = -100;
			this.saturationTrackBar.Name = "saturationTrackBar";
			this.saturationTrackBar.Size = new System.Drawing.Size(227, 28);
			this.saturationTrackBar.TabIndex = 13;
			this.saturationTrackBar.TickFrequency = 10;
			this.saturationTrackBar.ValueChanged += new System.EventHandler(this.saturationTrackBar_ValueChanged);
			// 
			// hueLbl
			// 
			this.hueLbl.AutoSize = true;
			this.hueLbl.Location = new System.Drawing.Point(6, 23);
			this.hueLbl.Name = "hueLbl";
			this.hueLbl.Size = new System.Drawing.Size(30, 13);
			this.hueLbl.TabIndex = 12;
			this.hueLbl.Text = "Hue:";
			// 
			// hueValue
			// 
			this.hueValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.hueValue.Location = new System.Drawing.Point(171, 19);
			this.hueValue.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
			this.hueValue.Minimum = new decimal(new int[] {
            180,
            0,
            0,
            -2147483648});
			this.hueValue.Name = "hueValue";
			this.hueValue.Size = new System.Drawing.Size(62, 22);
			this.hueValue.TabIndex = 11;
			this.hueValue.ValueChanged += new System.EventHandler(this.hueValue_ValueChanged);
			// 
			// autoUpdate
			// 
			this.autoUpdate.AutoSize = true;
			this.autoUpdate.Checked = true;
			this.autoUpdate.CheckState = System.Windows.Forms.CheckState.Checked;
			this.autoUpdate.Location = new System.Drawing.Point(174, 27);
			this.autoUpdate.Name = "autoUpdate";
			this.autoUpdate.Size = new System.Drawing.Size(84, 17);
			this.autoUpdate.TabIndex = 20;
			this.autoUpdate.Text = "Auto update";
			this.autoUpdate.UseVisualStyleBackColor = true;
			this.autoUpdate.CheckedChanged += new System.EventHandler(this.autoUpdate_CheckedChanged);
			// 
			// HueProperties
			// 
			this.AcceptButton = this.okBtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.DimGray;
			this.CancelButton = this.cancelBtn;
			this.ClientSize = new System.Drawing.Size(266, 327);
			this.Controls.Add(this.autoUpdate);
			this.Controls.Add(this.adjustmentBox);
			this.Controls.Add(this.nameLbl);
			this.Controls.Add(this.nameTb);
			this.Controls.Add(this.cancelBtn);
			this.Controls.Add(this.okBtn);
			this.ForeColor = System.Drawing.Color.White;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "HueProperties";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Layer properties";
			((System.ComponentModel.ISupportInitialize)(this.hueTrackBar)).EndInit();
			this.adjustmentBox.ResumeLayout(false);
			this.adjustmentBox.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.lightnessValue)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lightnessTrackBar)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.saturationValue)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.saturationTrackBar)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.hueValue)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button okBtn;
		private System.Windows.Forms.Button cancelBtn;
		private System.Windows.Forms.TextBox nameTb;
		private System.Windows.Forms.Label nameLbl;
		private System.Windows.Forms.TrackBar hueTrackBar;
		private System.Windows.Forms.GroupBox adjustmentBox;
		private System.Windows.Forms.NumericUpDown hueValue;
		private System.Windows.Forms.Label hueLbl;
		private System.Windows.Forms.Label saturationLbl;
		private System.Windows.Forms.NumericUpDown saturationValue;
		private System.Windows.Forms.TrackBar saturationTrackBar;
		private System.Windows.Forms.Label lightnessLbl;
		private System.Windows.Forms.NumericUpDown lightnessValue;
		private System.Windows.Forms.TrackBar lightnessTrackBar;
		private System.Windows.Forms.CheckBox colorizeChkBox;
		private System.Windows.Forms.CheckBox autoUpdate;
	}
}