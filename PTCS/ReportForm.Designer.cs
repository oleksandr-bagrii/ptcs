namespace PTCS
{
    partial class ReportForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportForm));
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblCP = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTP = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblZM = new System.Windows.Forms.ToolStripStatusLabel();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.robinson_PhoneBookDS = new PhoneBook.Robinson_PhoneBookDS();
            this.phoneBookBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.phoneBookTableAdapter = new PhoneBook.Robinson_PhoneBookDSTableAdapters.PhoneBookTableAdapter();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.robinson_PhoneBookDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.phoneBookBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblCP,
            this.toolStripStatusLabel3,
            this.lblTP,
            this.lblZM});
            this.statusStrip1.Location = new System.Drawing.Point(0, 461);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(775, 24);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            this.statusStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.statusStrip1_ItemClicked);
            // 
            // lblCP
            // 
            this.lblCP.Name = "lblCP";
            this.lblCP.Size = new System.Drawing.Size(82, 19);
            this.lblCP.Text = "Current Page.:";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None;
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(0, 19);
            this.toolStripStatusLabel3.Text = "toolStripStatusLabel3";
            // 
            // lblTP
            // 
            this.lblTP.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.lblTP.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.lblTP.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.lblTP.Image = ((System.Drawing.Image)(resources.GetObject("lblTP.Image")));
            this.lblTP.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.lblTP.Margin = new System.Windows.Forms.Padding(220, 3, 0, 2);
            this.lblTP.Name = "lblTP";
            this.lblTP.Size = new System.Drawing.Size(90, 19);
            this.lblTP.Text = "Total Page No.:";
            // 
            // lblZM
            // 
            this.lblZM.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.lblZM.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.lblZM.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.lblZM.Margin = new System.Windows.Forms.Padding(160, 3, 0, 2);
            this.lblZM.Name = "lblZM";
            this.lblZM.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblZM.Size = new System.Drawing.Size(82, 19);
            this.lblZM.Text = "Zoom Factor:";
            this.lblZM.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource3.Name = "DSContactList";
            reportDataSource3.Value = this.phoneBookBindingSource1;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "PhoneBook.PBReoprt.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(775, 485);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.ZoomChange += new Microsoft.Reporting.WinForms.ZoomChangedEventHandler(this.reportViewer1_ZoomChange);
            this.reportViewer1.PageNavigation += new Microsoft.Reporting.WinForms.PageNavigationEventHandler(this.reportViewer1_PageNavigation);
            this.reportViewer1.RenderingComplete += new Microsoft.Reporting.WinForms.RenderingCompleteEventHandler(this.reportViewer1_RenderingComplete);
            this.reportViewer1.StatusChanged += new System.EventHandler<System.EventArgs>(this.reportViewer1_StatusChanged);
            // 
            // robinson_PhoneBookDS
            // 
            this.robinson_PhoneBookDS.DataSetName = "Robinson_PhoneBookDS";
            this.robinson_PhoneBookDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // phoneBookBindingSource1
            // 
            this.phoneBookBindingSource1.DataMember = "PhoneBook";
            this.phoneBookBindingSource1.DataSource = this.robinson_PhoneBookDS;
            // 
            // phoneBookTableAdapter
            // 
            this.phoneBookTableAdapter.ClearBeforeFill = true;
            // 
            // ReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(775, 485);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.reportViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ReportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phone Report";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ReportForm_FormClosed);
            this.Load += new System.EventHandler(this.ReportForm_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.robinson_PhoneBookDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.phoneBookBindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblCP;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel lblTP;
        private System.Windows.Forms.ToolStripStatusLabel lblZM;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private PhoneBook.Robinson_PhoneBookDS robinson_PhoneBookDS;
        private System.Windows.Forms.BindingSource phoneBookBindingSource1;
        private PhoneBook.Robinson_PhoneBookDSTableAdapters.PhoneBookTableAdapter phoneBookTableAdapter;
       
    }
}