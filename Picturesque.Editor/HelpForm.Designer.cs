namespace Picturesque.Editor
{
	partial class HelpForm
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
			this.header = new System.Windows.Forms.Panel();
			this.layersCat = new System.Windows.Forms.LinkLabel();
			this.toolsCat = new System.Windows.Forms.LinkLabel();
			this.projectCat = new System.Windows.Forms.LinkLabel();
			this.categoryLbl = new System.Windows.Forms.Label();
			this.title = new System.Windows.Forms.Label();
			this.rtf = new System.Windows.Forms.RichTextBox();
			this.header.SuspendLayout();
			this.SuspendLayout();
			// 
			// header
			// 
			this.header.Controls.Add(this.layersCat);
			this.header.Controls.Add(this.toolsCat);
			this.header.Controls.Add(this.projectCat);
			this.header.Controls.Add(this.categoryLbl);
			this.header.Controls.Add(this.title);
			this.header.Dock = System.Windows.Forms.DockStyle.Top;
			this.header.Location = new System.Drawing.Point(0, 0);
			this.header.Name = "header";
			this.header.Size = new System.Drawing.Size(384, 100);
			this.header.TabIndex = 0;
			// 
			// layersCat
			// 
			this.layersCat.AutoSize = true;
			this.layersCat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.layersCat.Location = new System.Drawing.Point(212, 60);
			this.layersCat.Name = "layersCat";
			this.layersCat.Size = new System.Drawing.Size(56, 20);
			this.layersCat.TabIndex = 4;
			this.layersCat.TabStop = true;
			this.layersCat.Text = "Layers";
			this.layersCat.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.layersCat_LinkClicked);
			// 
			// toolsCat
			// 
			this.toolsCat.AutoSize = true;
			this.toolsCat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.toolsCat.Location = new System.Drawing.Point(159, 60);
			this.toolsCat.Name = "toolsCat";
			this.toolsCat.Size = new System.Drawing.Size(47, 20);
			this.toolsCat.TabIndex = 3;
			this.toolsCat.TabStop = true;
			this.toolsCat.Text = "Tools";
			this.toolsCat.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.toolsCat_LinkClicked);
			// 
			// projectCat
			// 
			this.projectCat.AutoSize = true;
			this.projectCat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.projectCat.Location = new System.Drawing.Point(95, 60);
			this.projectCat.Name = "projectCat";
			this.projectCat.Size = new System.Drawing.Size(58, 20);
			this.projectCat.TabIndex = 2;
			this.projectCat.TabStop = true;
			this.projectCat.Text = "Project";
			this.projectCat.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.projectCat_LinkClicked);
			// 
			// categoryLbl
			// 
			this.categoryLbl.AutoSize = true;
			this.categoryLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.categoryLbl.Location = new System.Drawing.Point(12, 60);
			this.categoryLbl.Name = "categoryLbl";
			this.categoryLbl.Size = new System.Drawing.Size(77, 20);
			this.categoryLbl.TabIndex = 1;
			this.categoryLbl.Text = "Category:";
			// 
			// title
			// 
			this.title.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.title.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.title.ForeColor = System.Drawing.Color.SteelBlue;
			this.title.Location = new System.Drawing.Point(0, 10);
			this.title.Name = "title";
			this.title.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
			this.title.Size = new System.Drawing.Size(384, 35);
			this.title.TabIndex = 0;
			this.title.Text = "Picturesque Editor Help";
			this.title.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// rtf
			// 
			this.rtf.BackColor = System.Drawing.Color.White;
			this.rtf.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.rtf.Dock = System.Windows.Forms.DockStyle.Fill;
			this.rtf.Location = new System.Drawing.Point(0, 100);
			this.rtf.Name = "rtf";
			this.rtf.ReadOnly = true;
			this.rtf.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
			this.rtf.Size = new System.Drawing.Size(384, 361);
			this.rtf.TabIndex = 1;
			this.rtf.Text = "";
			// 
			// HelpForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(384, 461);
			this.Controls.Add(this.rtf);
			this.Controls.Add(this.header);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(300, 300);
			this.Name = "HelpForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.HelpForm_FormClosing);
			this.header.ResumeLayout(false);
			this.header.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel header;
		private System.Windows.Forms.LinkLabel layersCat;
		private System.Windows.Forms.LinkLabel toolsCat;
		private System.Windows.Forms.LinkLabel projectCat;
		private System.Windows.Forms.Label categoryLbl;
		private System.Windows.Forms.Label title;
		private System.Windows.Forms.RichTextBox rtf;
	}
}