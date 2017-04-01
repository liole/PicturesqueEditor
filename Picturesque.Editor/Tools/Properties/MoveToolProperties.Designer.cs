namespace Picturesque.Editor.Tools.Properties
{
	partial class MoveToolProperties
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
			this.xValue = new System.Windows.Forms.NumericUpDown();
			this.xPxLabel = new System.Windows.Forms.Label();
			this.yPxLabel = new System.Windows.Forms.Label();
			this.yValue = new System.Windows.Forms.NumericUpDown();
			this.yLabel = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.xValue)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.yValue)).BeginInit();
			this.SuspendLayout();
			// 
			// titleLabel
			// 
			this.titleLabel.AutoSize = true;
			this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.titleLabel.ForeColor = System.Drawing.Color.Gainsboro;
			this.titleLabel.Location = new System.Drawing.Point(3, 8);
			this.titleLabel.Name = "titleLabel";
			this.titleLabel.Size = new System.Drawing.Size(70, 16);
			this.titleLabel.TabIndex = 0;
			this.titleLabel.Text = "MoveTool";
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
			// xPxLabel
			// 
			this.xPxLabel.AutoSize = true;
			this.xPxLabel.Location = new System.Drawing.Point(181, 13);
			this.xPxLabel.Name = "xPxLabel";
			this.xPxLabel.Size = new System.Drawing.Size(18, 13);
			this.xPxLabel.TabIndex = 4;
			this.xPxLabel.Text = "px";
			// 
			// yPxLabel
			// 
			this.yPxLabel.AutoSize = true;
			this.yPxLabel.Location = new System.Drawing.Point(300, 13);
			this.yPxLabel.Name = "yPxLabel";
			this.yPxLabel.Size = new System.Drawing.Size(18, 13);
			this.yPxLabel.TabIndex = 7;
			this.yPxLabel.Text = "px";
			// 
			// yValue
			// 
			this.yValue.DecimalPlaces = 2;
			this.yValue.Location = new System.Drawing.Point(228, 6);
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
			this.yLabel.Location = new System.Drawing.Point(205, 10);
			this.yLabel.Name = "yLabel";
			this.yLabel.Size = new System.Drawing.Size(17, 13);
			this.yLabel.TabIndex = 5;
			this.yLabel.Text = "Y:";
			// 
			// MoveToolProperties
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.DimGray;
			this.Controls.Add(this.yPxLabel);
			this.Controls.Add(this.yValue);
			this.Controls.Add(this.yLabel);
			this.Controls.Add(this.xPxLabel);
			this.Controls.Add(this.xValue);
			this.Controls.Add(this.xLabel);
			this.Controls.Add(this.titleSplitter);
			this.Controls.Add(this.titleLabel);
			this.ForeColor = System.Drawing.Color.White;
			this.Name = "MoveToolProperties";
			this.Size = new System.Drawing.Size(377, 32);
			((System.ComponentModel.ISupportInitialize)(this.xValue)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.yValue)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label titleLabel;
		private System.Windows.Forms.Panel titleSplitter;
		private System.Windows.Forms.Label xLabel;
		private System.Windows.Forms.NumericUpDown xValue;
		private System.Windows.Forms.Label xPxLabel;
		private System.Windows.Forms.Label yPxLabel;
		private System.Windows.Forms.NumericUpDown yValue;
		private System.Windows.Forms.Label yLabel;
	}
}
