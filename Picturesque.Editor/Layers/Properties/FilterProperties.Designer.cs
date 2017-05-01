namespace Picturesque.Editor.Layers.Properties
{
	partial class FilterProperties
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
			this.typeLbl = new System.Windows.Forms.Label();
			this.filterType = new System.Windows.Forms.ComboBox();
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
			this.okBtn.Location = new System.Drawing.Point(12, 105);
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
			this.cancelBtn.Location = new System.Drawing.Point(104, 105);
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
			// typeLbl
			// 
			this.typeLbl.AutoSize = true;
			this.typeLbl.Location = new System.Drawing.Point(12, 47);
			this.typeLbl.Name = "typeLbl";
			this.typeLbl.Size = new System.Drawing.Size(55, 13);
			this.typeLbl.TabIndex = 9;
			this.typeLbl.Text = "Filter type:";
			// 
			// filterType
			// 
			this.filterType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.filterType.FormattingEnabled = true;
			this.filterType.Items.AddRange(new object[] {
            "Grayscale",
            "Sepia",
            "Negative"});
			this.filterType.Location = new System.Drawing.Point(12, 64);
			this.filterType.Name = "filterType";
			this.filterType.Size = new System.Drawing.Size(156, 21);
			this.filterType.TabIndex = 10;
			this.filterType.SelectedIndexChanged += new System.EventHandler(this.filterType_SelectedIndexChanged);
			// 
			// FilterProperties
			// 
			this.AcceptButton = this.okBtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.DimGray;
			this.CancelButton = this.cancelBtn;
			this.ClientSize = new System.Drawing.Size(185, 148);
			this.Controls.Add(this.filterType);
			this.Controls.Add(this.typeLbl);
			this.Controls.Add(this.nameLbl);
			this.Controls.Add(this.nameTb);
			this.Controls.Add(this.cancelBtn);
			this.Controls.Add(this.okBtn);
			this.ForeColor = System.Drawing.Color.White;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FilterProperties";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Layer properties";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button okBtn;
		private System.Windows.Forms.Button cancelBtn;
		private System.Windows.Forms.TextBox nameTb;
		private System.Windows.Forms.Label nameLbl;
		private System.Windows.Forms.Label typeLbl;
		private System.Windows.Forms.ComboBox filterType;
	}
}