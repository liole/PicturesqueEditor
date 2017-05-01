namespace Picturesque.Editor.Tools.Properties
{
	partial class TransformToolProperties
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TransformToolProperties));
			this.titleLabel = new System.Windows.Forms.Label();
			this.titleSplitter = new System.Windows.Forms.Panel();
			this.xLabel = new System.Windows.Forms.Label();
			this.xValue = new System.Windows.Forms.NumericUpDown();
			this.yValue = new System.Windows.Forms.NumericUpDown();
			this.yLabel = new System.Windows.Forms.Label();
			this.scaleLbl = new System.Windows.Forms.Label();
			this.scaleYValue = new System.Windows.Forms.NumericUpDown();
			this.syLbl = new System.Windows.Forms.Label();
			this.scaleXValue = new System.Windows.Forms.NumericUpDown();
			this.sxLbl = new System.Windows.Forms.Label();
			this.rotLbl = new System.Windows.Forms.Label();
			this.rotateValue = new System.Windows.Forms.NumericUpDown();
			this.revertBtn = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.xValue)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.yValue)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.scaleYValue)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.scaleXValue)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.rotateValue)).BeginInit();
			this.SuspendLayout();
			// 
			// titleLabel
			// 
			this.titleLabel.AutoSize = true;
			this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.titleLabel.ForeColor = System.Drawing.Color.Gainsboro;
			this.titleLabel.Location = new System.Drawing.Point(3, 8);
			this.titleLabel.Name = "titleLabel";
			this.titleLabel.Size = new System.Drawing.Size(69, 16);
			this.titleLabel.TabIndex = 0;
			this.titleLabel.Text = "Transform";
			// 
			// titleSplitter
			// 
			this.titleSplitter.BackColor = System.Drawing.Color.Silver;
			this.titleSplitter.Location = new System.Drawing.Point(79, 6);
			this.titleSplitter.Name = "titleSplitter";
			this.titleSplitter.Size = new System.Drawing.Size(1, 24);
			this.titleSplitter.TabIndex = 1;
			// 
			// xLabel
			// 
			this.xLabel.AutoSize = true;
			this.xLabel.Location = new System.Drawing.Point(86, 10);
			this.xLabel.Name = "xLabel";
			this.xLabel.Size = new System.Drawing.Size(17, 13);
			this.xLabel.TabIndex = 2;
			this.xLabel.Text = "X:";
			// 
			// xValue
			// 
			this.xValue.DecimalPlaces = 2;
			this.xValue.Location = new System.Drawing.Point(109, 6);
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
			this.xValue.TabIndex = 3;
			this.xValue.ValueChanged += new System.EventHandler(this.value_ValueChanged);
			// 
			// yValue
			// 
			this.yValue.DecimalPlaces = 2;
			this.yValue.Location = new System.Drawing.Point(204, 6);
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
			this.yValue.TabIndex = 6;
			this.yValue.ValueChanged += new System.EventHandler(this.value_ValueChanged);
			// 
			// yLabel
			// 
			this.yLabel.AutoSize = true;
			this.yLabel.Location = new System.Drawing.Point(181, 10);
			this.yLabel.Name = "yLabel";
			this.yLabel.Size = new System.Drawing.Size(17, 13);
			this.yLabel.TabIndex = 5;
			this.yLabel.Text = "Y:";
			// 
			// scaleLbl
			// 
			this.scaleLbl.AutoSize = true;
			this.scaleLbl.Location = new System.Drawing.Point(276, 10);
			this.scaleLbl.Name = "scaleLbl";
			this.scaleLbl.Size = new System.Drawing.Size(37, 13);
			this.scaleLbl.TabIndex = 7;
			this.scaleLbl.Text = "Scale:";
			// 
			// scaleYValue
			// 
			this.scaleYValue.DecimalPlaces = 2;
			this.scaleYValue.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
			this.scaleYValue.Location = new System.Drawing.Point(437, 6);
			this.scaleYValue.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
			this.scaleYValue.Name = "scaleYValue";
			this.scaleYValue.Size = new System.Drawing.Size(66, 20);
			this.scaleYValue.TabIndex = 11;
			this.scaleYValue.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.scaleYValue.ValueChanged += new System.EventHandler(this.value_ValueChanged);
			// 
			// syLbl
			// 
			this.syLbl.AutoSize = true;
			this.syLbl.Location = new System.Drawing.Point(414, 10);
			this.syLbl.Name = "syLbl";
			this.syLbl.Size = new System.Drawing.Size(17, 13);
			this.syLbl.TabIndex = 10;
			this.syLbl.Text = "Y:";
			// 
			// scaleXValue
			// 
			this.scaleXValue.DecimalPlaces = 2;
			this.scaleXValue.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
			this.scaleXValue.Location = new System.Drawing.Point(342, 6);
			this.scaleXValue.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
			this.scaleXValue.Name = "scaleXValue";
			this.scaleXValue.Size = new System.Drawing.Size(66, 20);
			this.scaleXValue.TabIndex = 9;
			this.scaleXValue.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.scaleXValue.ValueChanged += new System.EventHandler(this.value_ValueChanged);
			// 
			// sxLbl
			// 
			this.sxLbl.AutoSize = true;
			this.sxLbl.Location = new System.Drawing.Point(319, 10);
			this.sxLbl.Name = "sxLbl";
			this.sxLbl.Size = new System.Drawing.Size(17, 13);
			this.sxLbl.TabIndex = 8;
			this.sxLbl.Text = "X:";
			// 
			// rotLbl
			// 
			this.rotLbl.AutoSize = true;
			this.rotLbl.Location = new System.Drawing.Point(509, 10);
			this.rotLbl.Name = "rotLbl";
			this.rotLbl.Size = new System.Drawing.Size(42, 13);
			this.rotLbl.TabIndex = 12;
			this.rotLbl.Text = "Rotate:";
			// 
			// rotateValue
			// 
			this.rotateValue.DecimalPlaces = 2;
			this.rotateValue.Location = new System.Drawing.Point(557, 6);
			this.rotateValue.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
			this.rotateValue.Minimum = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
			this.rotateValue.Name = "rotateValue";
			this.rotateValue.Size = new System.Drawing.Size(66, 20);
			this.rotateValue.TabIndex = 13;
			this.rotateValue.ValueChanged += new System.EventHandler(this.value_ValueChanged);
			// 
			// revertBtn
			// 
			this.revertBtn.FlatAppearance.BorderSize = 0;
			this.revertBtn.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
			this.revertBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
			this.revertBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.revertBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.revertBtn.Image = ((System.Drawing.Image)(resources.GetObject("revertBtn.Image")));
			this.revertBtn.Location = new System.Drawing.Point(641, 3);
			this.revertBtn.Name = "revertBtn";
			this.revertBtn.Size = new System.Drawing.Size(24, 24);
			this.revertBtn.TabIndex = 14;
			this.revertBtn.Tag = "";
			this.revertBtn.UseVisualStyleBackColor = false;
			this.revertBtn.Click += new System.EventHandler(this.revertBtn_Click);
			// 
			// TransformToolProperties
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.DimGray;
			this.Controls.Add(this.revertBtn);
			this.Controls.Add(this.rotateValue);
			this.Controls.Add(this.rotLbl);
			this.Controls.Add(this.scaleYValue);
			this.Controls.Add(this.syLbl);
			this.Controls.Add(this.scaleXValue);
			this.Controls.Add(this.sxLbl);
			this.Controls.Add(this.scaleLbl);
			this.Controls.Add(this.yValue);
			this.Controls.Add(this.yLabel);
			this.Controls.Add(this.xValue);
			this.Controls.Add(this.xLabel);
			this.Controls.Add(this.titleSplitter);
			this.Controls.Add(this.titleLabel);
			this.ForeColor = System.Drawing.Color.White;
			this.Name = "TransformToolProperties";
			this.Size = new System.Drawing.Size(829, 32);
			((System.ComponentModel.ISupportInitialize)(this.xValue)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.yValue)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.scaleYValue)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.scaleXValue)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.rotateValue)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label titleLabel;
		private System.Windows.Forms.Panel titleSplitter;
		private System.Windows.Forms.Label xLabel;
		private System.Windows.Forms.NumericUpDown xValue;
		private System.Windows.Forms.NumericUpDown yValue;
		private System.Windows.Forms.Label yLabel;
		private System.Windows.Forms.Label scaleLbl;
		private System.Windows.Forms.NumericUpDown scaleYValue;
		private System.Windows.Forms.Label syLbl;
		private System.Windows.Forms.NumericUpDown scaleXValue;
		private System.Windows.Forms.Label sxLbl;
		private System.Windows.Forms.Label rotLbl;
		private System.Windows.Forms.NumericUpDown rotateValue;
		private System.Windows.Forms.Button revertBtn;
	}
}
