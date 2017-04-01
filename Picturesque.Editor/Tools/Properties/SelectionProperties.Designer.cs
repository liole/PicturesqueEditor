namespace Picturesque.Editor.Tools.Properties
{
	partial class SelectionProperties
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
			this.typeLabel = new System.Windows.Forms.Label();
			this.typeBox = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// titleLabel
			// 
			this.titleLabel.AutoSize = true;
			this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.titleLabel.ForeColor = System.Drawing.Color.Gainsboro;
			this.titleLabel.Location = new System.Drawing.Point(3, 8);
			this.titleLabel.Name = "titleLabel";
			this.titleLabel.Size = new System.Drawing.Size(64, 16);
			this.titleLabel.TabIndex = 0;
			this.titleLabel.Text = "Selection";
			// 
			// titleSplitter
			// 
			this.titleSplitter.BackColor = System.Drawing.Color.Silver;
			this.titleSplitter.Location = new System.Drawing.Point(66, 6);
			this.titleSplitter.Name = "titleSplitter";
			this.titleSplitter.Size = new System.Drawing.Size(1, 24);
			this.titleSplitter.TabIndex = 1;
			// 
			// typeLabel
			// 
			this.typeLabel.AutoSize = true;
			this.typeLabel.Location = new System.Drawing.Point(69, 10);
			this.typeLabel.Name = "typeLabel";
			this.typeLabel.Size = new System.Drawing.Size(34, 13);
			this.typeLabel.TabIndex = 2;
			this.typeLabel.Text = "Type:";
			// 
			// typeBox
			// 
			this.typeBox.BackColor = System.Drawing.SystemColors.Window;
			this.typeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.typeBox.FormattingEnabled = true;
			this.typeBox.Items.AddRange(new object[] {
            "Rectangle",
            "Ellipse",
            "Free form"});
			this.typeBox.Location = new System.Drawing.Point(109, 6);
			this.typeBox.Name = "typeBox";
			this.typeBox.Size = new System.Drawing.Size(121, 21);
			this.typeBox.TabIndex = 3;
			this.typeBox.SelectedIndexChanged += new System.EventHandler(this.typeBox_SelectedIndexChanged);
			// 
			// SelectionProperties
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.DimGray;
			this.Controls.Add(this.typeBox);
			this.Controls.Add(this.typeLabel);
			this.Controls.Add(this.titleSplitter);
			this.Controls.Add(this.titleLabel);
			this.ForeColor = System.Drawing.Color.White;
			this.Name = "SelectionProperties";
			this.Size = new System.Drawing.Size(252, 32);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label titleLabel;
		private System.Windows.Forms.Panel titleSplitter;
		private System.Windows.Forms.Label typeLabel;
		private System.Windows.Forms.ComboBox typeBox;
	}
}
