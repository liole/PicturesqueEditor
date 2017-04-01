namespace Picturesque.Editor.Tools.Properties
{
	partial class PencilProperties
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
			((System.ComponentModel.ISupportInitialize)(this.wValue)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.wTrackBar)).BeginInit();
			this.SuspendLayout();
			// 
			// titleLabel
			// 
			this.titleLabel.AutoSize = true;
			this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.titleLabel.ForeColor = System.Drawing.Color.Gainsboro;
			this.titleLabel.Location = new System.Drawing.Point(3, 8);
			this.titleLabel.Name = "titleLabel";
			this.titleLabel.Size = new System.Drawing.Size(45, 16);
			this.titleLabel.TabIndex = 0;
			this.titleLabel.Text = "Pencil";
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
			this.wValue.Location = new System.Drawing.Point(265, 6);
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
			this.xPxLabel.Location = new System.Drawing.Point(325, 13);
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
			this.wTrackBar.Size = new System.Drawing.Size(154, 26);
			this.wTrackBar.TabIndex = 5;
			this.wTrackBar.TickFrequency = 10;
			this.wTrackBar.Value = 1;
			this.wTrackBar.ValueChanged += new System.EventHandler(this.wTrackBar_ValueChanged);
			// 
			// PencilProperties
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.DimGray;
			this.Controls.Add(this.wTrackBar);
			this.Controls.Add(this.xPxLabel);
			this.Controls.Add(this.wValue);
			this.Controls.Add(this.xLabel);
			this.Controls.Add(this.titleSplitter);
			this.Controls.Add(this.titleLabel);
			this.ForeColor = System.Drawing.Color.White;
			this.Name = "PencilProperties";
			this.Size = new System.Drawing.Size(355, 32);
			((System.ComponentModel.ISupportInitialize)(this.wValue)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.wTrackBar)).EndInit();
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
	}
}
