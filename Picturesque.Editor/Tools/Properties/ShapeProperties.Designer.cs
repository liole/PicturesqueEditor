namespace Picturesque.Editor.Tools.Properties
{
	partial class ShapeProperties
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
			this.xPxLabel = new System.Windows.Forms.Label();
			this.wValue = new System.Windows.Forms.NumericUpDown();
			this.fillBox = new System.Windows.Forms.CheckBox();
			this.strokeBox = new System.Windows.Forms.CheckBox();
			this.strokeType = new System.Windows.Forms.ComboBox();
			this.fillType = new System.Windows.Forms.ComboBox();
			this.fillInfo = new System.Windows.Forms.Label();
			this.poygonInfo = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.wValue)).BeginInit();
			this.SuspendLayout();
			// 
			// titleLabel
			// 
			this.titleLabel.AutoSize = true;
			this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.titleLabel.ForeColor = System.Drawing.Color.Gainsboro;
			this.titleLabel.Location = new System.Drawing.Point(3, 8);
			this.titleLabel.Name = "titleLabel";
			this.titleLabel.Size = new System.Drawing.Size(48, 16);
			this.titleLabel.TabIndex = 0;
			this.titleLabel.Text = "Shape";
			// 
			// titleSplitter
			// 
			this.titleSplitter.BackColor = System.Drawing.Color.Silver;
			this.titleSplitter.Location = new System.Drawing.Point(51, 6);
			this.titleSplitter.Name = "titleSplitter";
			this.titleSplitter.Size = new System.Drawing.Size(1, 24);
			this.titleSplitter.TabIndex = 1;
			// 
			// typeLabel
			// 
			this.typeLabel.AutoSize = true;
			this.typeLabel.Location = new System.Drawing.Point(54, 10);
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
            "Line",
            "Polygon",
            "Free form"});
			this.typeBox.Location = new System.Drawing.Point(94, 6);
			this.typeBox.Name = "typeBox";
			this.typeBox.Size = new System.Drawing.Size(84, 21);
			this.typeBox.TabIndex = 3;
			this.typeBox.SelectedIndexChanged += new System.EventHandler(this.typeBox_SelectedIndexChanged);
			// 
			// xPxLabel
			// 
			this.xPxLabel.AutoSize = true;
			this.xPxLabel.Location = new System.Drawing.Point(383, 13);
			this.xPxLabel.Name = "xPxLabel";
			this.xPxLabel.Size = new System.Drawing.Size(18, 13);
			this.xPxLabel.TabIndex = 8;
			this.xPxLabel.Text = "px";
			// 
			// wValue
			// 
			this.wValue.Location = new System.Drawing.Point(323, 6);
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
			this.wValue.TabIndex = 7;
			this.wValue.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.wValue.ValueChanged += new System.EventHandler(this.wValue_ValueChanged);
			// 
			// fillBox
			// 
			this.fillBox.AutoSize = true;
			this.fillBox.Location = new System.Drawing.Point(407, 9);
			this.fillBox.Name = "fillBox";
			this.fillBox.Size = new System.Drawing.Size(41, 17);
			this.fillBox.TabIndex = 9;
			this.fillBox.Text = "Fill:";
			this.fillBox.UseVisualStyleBackColor = true;
			this.fillBox.CheckedChanged += new System.EventHandler(this.fillBox_CheckedChanged);
			// 
			// strokeBox
			// 
			this.strokeBox.AutoSize = true;
			this.strokeBox.Checked = true;
			this.strokeBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.strokeBox.Location = new System.Drawing.Point(185, 9);
			this.strokeBox.Name = "strokeBox";
			this.strokeBox.Size = new System.Drawing.Size(60, 17);
			this.strokeBox.TabIndex = 10;
			this.strokeBox.Text = "Stroke:";
			this.strokeBox.UseVisualStyleBackColor = true;
			this.strokeBox.CheckedChanged += new System.EventHandler(this.strokeBox_CheckedChanged);
			// 
			// strokeType
			// 
			this.strokeType.BackColor = System.Drawing.SystemColors.Window;
			this.strokeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.strokeType.FormattingEnabled = true;
			this.strokeType.Items.AddRange(new object[] {
            "––––––––––––––",
            "– – – – – – – – –",
            "· · · · · · · · · · · · · ·",
            "– · – · – · – · – · –",
            "– · · – · · – · · – · ·"});
			this.strokeType.Location = new System.Drawing.Point(242, 6);
			this.strokeType.Name = "strokeType";
			this.strokeType.Size = new System.Drawing.Size(75, 21);
			this.strokeType.TabIndex = 11;
			this.strokeType.SelectedIndexChanged += new System.EventHandler(this.strokeType_SelectedIndexChanged);
			// 
			// fillType
			// 
			this.fillType.BackColor = System.Drawing.SystemColors.Window;
			this.fillType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.fillType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.fillType.Enabled = false;
			this.fillType.FormattingEnabled = true;
			this.fillType.Location = new System.Drawing.Point(445, 6);
			this.fillType.Name = "fillType";
			this.fillType.Size = new System.Drawing.Size(75, 21);
			this.fillType.TabIndex = 12;
			this.fillType.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.fillType_DrawItem);
			this.fillType.SelectedIndexChanged += new System.EventHandler(this.fillType_SelectedIndexChanged);
			// 
			// fillInfo
			// 
			this.fillInfo.AutoSize = true;
			this.fillInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.fillInfo.ForeColor = System.Drawing.Color.LightGray;
			this.fillInfo.Location = new System.Drawing.Point(526, 4);
			this.fillInfo.Name = "fillInfo";
			this.fillInfo.Size = new System.Drawing.Size(119, 26);
			this.fillInfo.TabIndex = 13;
			this.fillInfo.Text = "displaying only pattern\r\ncolor is selected globaly";
			// 
			// poygonInfo
			// 
			this.poygonInfo.AutoSize = true;
			this.poygonInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.poygonInfo.ForeColor = System.Drawing.Color.LightGreen;
			this.poygonInfo.Location = new System.Drawing.Point(651, 10);
			this.poygonInfo.Name = "poygonInfo";
			this.poygonInfo.Size = new System.Drawing.Size(137, 13);
			this.poygonInfo.TabIndex = 14;
			this.poygonInfo.Text = "Uses space to add a vertex";
			this.poygonInfo.Visible = false;
			// 
			// ShapeProperties
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.DimGray;
			this.Controls.Add(this.poygonInfo);
			this.Controls.Add(this.fillInfo);
			this.Controls.Add(this.fillType);
			this.Controls.Add(this.strokeType);
			this.Controls.Add(this.strokeBox);
			this.Controls.Add(this.fillBox);
			this.Controls.Add(this.xPxLabel);
			this.Controls.Add(this.wValue);
			this.Controls.Add(this.typeBox);
			this.Controls.Add(this.typeLabel);
			this.Controls.Add(this.titleSplitter);
			this.Controls.Add(this.titleLabel);
			this.ForeColor = System.Drawing.Color.White;
			this.Name = "ShapeProperties";
			this.Size = new System.Drawing.Size(809, 32);
			((System.ComponentModel.ISupportInitialize)(this.wValue)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label titleLabel;
		private System.Windows.Forms.Panel titleSplitter;
		private System.Windows.Forms.Label typeLabel;
		private System.Windows.Forms.ComboBox typeBox;
		private System.Windows.Forms.Label xPxLabel;
		private System.Windows.Forms.NumericUpDown wValue;
		private System.Windows.Forms.CheckBox fillBox;
		private System.Windows.Forms.CheckBox strokeBox;
		private System.Windows.Forms.ComboBox strokeType;
		private System.Windows.Forms.ComboBox fillType;
		private System.Windows.Forms.Label fillInfo;
		private System.Windows.Forms.Label poygonInfo;
	}
}
