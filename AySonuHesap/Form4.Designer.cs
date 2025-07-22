namespace AySonuHesap
{
    partial class Form4
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem kişiYönetimiToolStripMenuItem;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Button btnNextMonth;
        private System.Windows.Forms.Button lblAyYil;
        private System.Windows.Forms.Button btnPrevMonth;
        private System.Windows.Forms.TableLayoutPanel tblMainPanel;
        private System.Windows.Forms.StatusStrip statusStrip1;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.kişiYönetimiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.btnNextMonth = new System.Windows.Forms.Button();
            this.lblAyYil = new System.Windows.Forms.Button();
            this.btnPrevMonth = new System.Windows.Forms.Button();
            this.tblMainPanel = new System.Windows.Forms.TableLayoutPanel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.menuStrip2.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 24);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1244, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuStrip2
            // 
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kişiYönetimiToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(1244, 24);
            this.menuStrip2.TabIndex = 1;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // kişiYönetimiToolStripMenuItem
            // 
            this.kişiYönetimiToolStripMenuItem.Name = "kişiYönetimiToolStripMenuItem";
            this.kişiYönetimiToolStripMenuItem.Size = new System.Drawing.Size(87, 20);
            this.kişiYönetimiToolStripMenuItem.Text = "Kişi Yönetimi";
            this.kişiYönetimiToolStripMenuItem.Click += new System.EventHandler(this.btnPersonManagement_Click);
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.LightSteelBlue;
            this.pnlHeader.Controls.Add(this.btnNextMonth);
            this.pnlHeader.Controls.Add(this.lblAyYil);
            this.pnlHeader.Controls.Add(this.btnPrevMonth);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 48);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1244, 50);
            this.pnlHeader.TabIndex = 2;
            // 
            // btnNextMonth
            // 
            this.btnNextMonth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNextMonth.Location = new System.Drawing.Point(1138, 12);
            this.btnNextMonth.Name = "btnNextMonth";
            this.btnNextMonth.Size = new System.Drawing.Size(75, 23);
            this.btnNextMonth.TabIndex = 2;
            this.btnNextMonth.Text = "Sonraki";
            this.btnNextMonth.UseVisualStyleBackColor = true;
            this.btnNextMonth.Click += new System.EventHandler(this.btnNextMonth_Click);
            // 
            // lblAyYil
            // 
            this.lblAyYil.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblAyYil.Enabled = false;
            this.lblAyYil.Location = new System.Drawing.Point(585, 12);
            this.lblAyYil.Name = "lblAyYil";
            this.lblAyYil.Size = new System.Drawing.Size(75, 23);
            this.lblAyYil.TabIndex = 1;
            this.lblAyYil.Text = "Bu Ay";
            this.lblAyYil.UseVisualStyleBackColor = true;
            // 
            // btnPrevMonth
            // 
            this.btnPrevMonth.Location = new System.Drawing.Point(25, 12);
            this.btnPrevMonth.Name = "btnPrevMonth";
            this.btnPrevMonth.Size = new System.Drawing.Size(75, 23);
            this.btnPrevMonth.TabIndex = 0;
            this.btnPrevMonth.Text = "Önceki";
            this.btnPrevMonth.UseVisualStyleBackColor = true;
            this.btnPrevMonth.Click += new System.EventHandler(this.btnPrevMonth_Click);
            // 
            // tblMainPanel
            // 
            this.tblMainPanel.AutoScroll = true;
            this.tblMainPanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tblMainPanel.ColumnCount = 2;
            this.tblMainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblMainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblMainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblMainPanel.Location = new System.Drawing.Point(0, 98);
            this.tblMainPanel.Name = "tblMainPanel";
            this.tblMainPanel.RowCount = 1;
            this.tblMainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblMainPanel.Size = new System.Drawing.Size(1244, 593);
            this.tblMainPanel.TabIndex = 3;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 691);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1244, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1244, 713);
            this.Controls.Add(this.tblMainPanel);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.menuStrip2);
            this.Name = "Form4";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Süt Takip Uygulaması";
            this.Load += new System.EventHandler(this.Form4_Load);
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.pnlHeader.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}