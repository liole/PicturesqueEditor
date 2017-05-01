namespace Picturesque.Editor.Tools.Properties
{
	partial class CloneStampProperties
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.titleLabel = new System.Windows.Forms.Label();
			this.titleSplitter = new System.Windows.Forms.Panel();
			this.xLabel = new System.Windows.Forms.Label();
			this.wValue = new System.Windows.Forms.NumericUpDown();
			this.xPxLabel = new System.Windows.Forms.Label();
			this.wTrackBar = new System.Windows.Forms.TrackBar();
			this.yPxLabel = new System.Windows.Forms.Label();
			this.yValue = new System.Windows.Forms.NumericUpDown();
			this.yLabel = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.xValue = new System.Windows.Forms.NumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.shiftLbl = new System.Windows.Forms.Label();
			this.poygonInfo = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.wValue)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.wTrackBar)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.yValue)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.xValue)).BeginInit();
			this.SuspendLayout();
			// 
			// titleLabel
			// 
			this.titleLabel.AutoSize = true;
			this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.titleLabel.ForeColor = System.Drawing.Color.Gainsboro;
			this.titleLabel.Location = new System.Drawing.Point(3, 8);
			this.titleLabel.Name = "titleLabel";
			this.titleLabel.Size = new System.Drawing.Size(47, 16);
			this.titleLabel.TabIndex = 0;
			this.titleLabel.Text = "Stamp";
			// 
			// titleSplitter
			// 
			this.titleSplitter.BackColor = System.Drawing.Color.Silver;
			this.titleSplitter.Location = new System.Drawing.Point(54, 6);
			this.titleSplitter.Name = "titleSplitter";
			this.titleSplitter.Size = new System.Drawing.Size(1, 24);
			this.titleSplitter.TabIndex = 1;
			// 
			// xLabel
			// 
			this.xLabel.AutoSize = true;
			this.xLabel.Location = new System.Drawing.Point(61, 10);
			this.xLabel.Name = "xLabel";
			this.xLabel.Size = new System.Drawing.Size(38, 13);
			this.xLabel.TabIndex = 2;
			this.xLabel.Text = "Width:";
			// 
			// wValue
			// 
			this.wValue.Location = new System.Drawing.Point(213, 6);
			this.wValue.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
			this.wValue.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.wValue.Name = "wValue";
			this.wValue.Size = new System.Drawing.Size(54, 20);
			this.wValue.TabIndex = 3;
			this.wValue.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.wValue.ValueChanged += new System.EventHandler(this.wWalue_ValueChanged);
			// 
			// xPxLabel
			// 
			this.xPxLabel.AutoSize = true;
			this.xPxLabel.Location = new System.Drawing.Point(273, 13);
			this.xPxLabel.Name = "xPxLabel";
			this.xPxLabel.Size = new System.Drawing.Size(18, 13);
			this.xPxLabel.TabIndex = 4;
			this.xPxLabel.Text = "px";
			// 
			// wTrackBar
			// 
			this.wTrackBar.AutoSize = false;
			this.wTrackBar.Location = new System.Drawing.Point(105, 6);
			this.wTrackBar.Maximum = 200;
			this.wTrackBar.Minimum = 1;
			this.wTrackBar.Name = "wTrackBar";
			this.wTrackBar.Size = new System.Drawing.Size(104, 26);
			this.wTrackBar.TabIndex = 5;
			this.wTrackBar.TickFrequency = 10;
			this.wTrackBar.Value = 1;
			this.wTrackBar.ValueChanged += new System.EventHandler(this.wTrackBar_ValueChanged);
			// 
			// yPxLabel
			// 
			this.yPxLabel.AutoSize = true;
			this.yPxLabel.Location = new System.Drawing.Point(545, 13);
			this.yPxLabel.Name = "yPxLabel";
			this.yPxLabel.Size = new System.Drawing.Size(18, 13);
			this.yPxLabel.TabIndex = 13;
			this.yPxLabel.Text = "px";
			// 
			// yValue
			// 
			this.yValue.DecimalPlaces = 2;
			this.yValue.Location = new System.Drawing.Point(473, 6);
			this.yValue.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			this.yValue.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
			this.yValue.Name = "yValue";
			this.yValue.Size = new System.Drawing.Size(66, 20);
			this.yValue.TabIndex = 12;
			this.yValue.ValueChanged += new System.EventHandler(this.yValue_ValueChanged);
			// 
			// yLabel
			// 
			this.yLabel.AutoSize = true;
			this.yLabel.Location = new System.Drawing.Point(450, 10);
			this.yLabel.Name = "yLabel";
			this.yLabel.Size = new System.Drawing.Size(17, 13);
			this.yLabel.TabIndex = 11;
			this.yLabel.Text = "Y:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(426, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(18, 13);
			this.label1.TabIndex = 10;
			this.label1.Text = "px";
			// 
			// xValue
			// 
			this.xValue.DecimalPlaces = 2;
			this.xValue.Location = new System.Drawing.Point(354, 6);
			this.xValue.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			this.xValue.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
			this.xValue.Name = "xValue";
			this.xValue.Size = new System.Drawing.Size(66, 20);
			this.xValue.TabIndex = 9;
			this.xValue.ValueChanged += new System.EventHandler(this.xValue_ValueChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(331, 10);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(17, 13);
			this.label2.TabIndex = 8;
			this.label2.Text = "X:";
			// 
			// shiftLbl
			// 
			this.shiftLbl.AutoSize = true;
			this.shiftLbl.Location = new System.Drawing.Point(297, 10);
			this.shiftLbl.Name = "shiftLbl";
			this.shiftLbl.Size = new System.Drawing.Size(31, 13);
			this.shiftLbl.TabIndex = 14;
			this.shiftLbl.Text = "Shift:";
			// 
			// poygonInfo
			// 
			this.poygonInfo.AutoSize = true;
			this.poygonInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.poygonInfo.ForeColor = System.Drawing.Color.LightGreen;
			this.poygonInfo.Location = new System.Drawing.Point(569, 10);
			this.poygonInfo.Name = "poygonInfo";
			this.poygonInfo.Size = new System.Drawing.Size(158, 13);
			this.poygonInfo.TabIndex = 15;
			this.poygonInfo.Text = "Use Ctrl key to pick source area";
			this.poygonInfo.Visible = false;
			// 
			// CloneStampProperties
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.DimGray;
			this.Controls.Add(this.poygonInfo);
			this.Controls.Add(this.shiftLbl);
			this.Controls.Add(this.yPxLabel);
			this.Controls.Add(this.yValue);
			this.Controls.Add(this.yLabel);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.xValue);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.wTrackBar);
			this.Controls.Add(this.xPxLabel);
			this.Controls.Add(this.wValue);
			this.Controls.Add(this.xLabel);
			this.Controls.Add(this.titleSplitter);
			this.Controls.Add(this.titleLabel);
			this.ForeColor = System.Drawing.Color.White;
			this.Name = "CloneStampProperties";
			this.Size = new System.Drawing.Size(763, 32);
			((System.ComponentModel.ISupportInitialize)(this.wValue)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.wTrackBar)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.yValue)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.xValue)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label titleLabel;
		private System.Windows.Forms.Panel titleSplitter;
		private System.Windows.Forms.Label xLabel;
		private System.Windows.Forms.NumericUpDown wValue;
		private System.Windows.Forms.Label xPxLabel;
		private System.Windows.Forms.TrackBar wTrackBar;
		private System.Windows.Forms.Label yPxLabel;
		private System.Windows.Forms.NumericUpDown yValue;
		private System.Windows.Forms.Label yLabel;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.NumericUpDown xValue;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label shiftLbl;
		private System.Windows.Forms.Label poygonInfo;
	}
}
