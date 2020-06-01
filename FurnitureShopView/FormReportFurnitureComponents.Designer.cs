namespace FurnitureShopView
{
    partial class FormReportFurnitureComponents
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.ReportFurnitureComponentViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.buttonCreateToPdf = new System.Windows.Forms.Button();
            this.buttonCreate = new System.Windows.Forms.Button();
            this.reportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.ReportFurnitureComponentViewModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonCreateToPdf
            // 
            this.buttonCreateToPdf.Location = new System.Drawing.Point(351, 12);
            this.buttonCreateToPdf.Name = "buttonCreateToPdf";
            this.buttonCreateToPdf.Size = new System.Drawing.Size(84, 20);
            this.buttonCreateToPdf.TabIndex = 5;
            this.buttonCreateToPdf.Text = "В PDF";
            this.buttonCreateToPdf.UseVisualStyleBackColor = true;
            this.buttonCreateToPdf.Click += new System.EventHandler(this.buttonCreateToPdf_Click);
            // 
            // buttonCreate
            // 
            this.buttonCreate.Location = new System.Drawing.Point(221, 12);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(93, 20);
            this.buttonCreate.TabIndex = 4;
            this.buttonCreate.Text = "Сформировать";
            this.buttonCreate.UseVisualStyleBackColor = true;
            this.buttonCreate.Click += new System.EventHandler(this.buttonCreate_Click);
            // 
            // reportViewer
            // 
            reportDataSource1.Name = "DataSetFurniture";
            reportDataSource1.Value = this.ReportFurnitureComponentViewModelBindingSource;
            this.reportViewer.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer.LocalReport.ReportEmbeddedResource = "AbstractShopView.Report.rdlc";
            this.reportViewer.Location = new System.Drawing.Point(39, 105);
            this.reportViewer.Name = "reportViewer";
            this.reportViewer.ServerReport.BearerToken = null;
            this.reportViewer.Size = new System.Drawing.Size(593, 289);
            this.reportViewer.TabIndex = 6;
            // 
            // FormReportFurnitureComponents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer);
            this.Controls.Add(this.buttonCreateToPdf);
            this.Controls.Add(this.buttonCreate);
            this.Name = "FormReportFurnitureComponents";
            this.Text = "Материалы по мебели";
            this.Load += new System.EventHandler(this.FormReportFurnitureComponents_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ReportFurnitureComponentViewModelBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonCreateToPdf;
        private System.Windows.Forms.Button buttonCreate;
        private System.Windows.Forms.BindingSource ReportFurnitureComponentViewModelBindingSource;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer;
    }
}