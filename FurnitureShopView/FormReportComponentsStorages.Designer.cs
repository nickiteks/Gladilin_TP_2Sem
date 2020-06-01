namespace FurnitureShopView
{
    partial class FormReportComponentsStorages
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
            this.ReportComponentStorageViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.buttonMakePdfMaterialStorages = new System.Windows.Forms.Button();
            this.buttonMakeReportMaterialStorages = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ReportComponentStorageViewModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // ReportComponentStorageViewModelBindingSource
            // 
            this.ReportComponentStorageViewModelBindingSource.DataSource = typeof(FurnitureShopBusinessLogic.ViewModels.ReportComponentStorageViewModel);
            // 
            // reportViewer
            // 
            reportDataSource1.Name = "DataSetStorage";
            reportDataSource1.Value = this.ReportComponentStorageViewModelBindingSource;
            this.reportViewer.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer.LocalReport.ReportEmbeddedResource = "AbstractShopView.ReportStorage.rdlc";
            this.reportViewer.Location = new System.Drawing.Point(99, 76);
            this.reportViewer.Name = "reportViewer";
            this.reportViewer.ServerReport.BearerToken = null;
            this.reportViewer.Size = new System.Drawing.Size(602, 328);
            this.reportViewer.TabIndex = 10;
            // 
            // buttonMakePdfMaterialStorages
            // 
            this.buttonMakePdfMaterialStorages.Location = new System.Drawing.Point(416, 47);
            this.buttonMakePdfMaterialStorages.Name = "buttonMakePdfMaterialStorages";
            this.buttonMakePdfMaterialStorages.Size = new System.Drawing.Size(84, 20);
            this.buttonMakePdfMaterialStorages.TabIndex = 9;
            this.buttonMakePdfMaterialStorages.Text = "В PDF";
            this.buttonMakePdfMaterialStorages.UseVisualStyleBackColor = true;
            this.buttonMakePdfMaterialStorages.Click += new System.EventHandler(this.buttonMakePdfComponentStorages_Click);
            // 
            // buttonMakeReportMaterialStorages
            // 
            this.buttonMakeReportMaterialStorages.Location = new System.Drawing.Point(286, 47);
            this.buttonMakeReportMaterialStorages.Name = "buttonMakeReportMaterialStorages";
            this.buttonMakeReportMaterialStorages.Size = new System.Drawing.Size(93, 20);
            this.buttonMakeReportMaterialStorages.TabIndex = 8;
            this.buttonMakeReportMaterialStorages.Text = "Сформировать";
            this.buttonMakeReportMaterialStorages.UseVisualStyleBackColor = true;
            this.buttonMakeReportMaterialStorages.Click += new System.EventHandler(this.buttonMakeReportComponentStorages_Click);
            // 
            // FormReportComponentsStorages
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer);
            this.Controls.Add(this.buttonMakePdfMaterialStorages);
            this.Controls.Add(this.buttonMakeReportMaterialStorages);
            this.Name = "FormReportComponentsStorages";
            this.Text = "Компоненты на складах";
            ((System.ComponentModel.ISupportInitialize)(this.ReportComponentStorageViewModelBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer;
        private System.Windows.Forms.Button buttonMakePdfMaterialStorages;
        private System.Windows.Forms.Button buttonMakeReportMaterialStorages;
        private System.Windows.Forms.BindingSource ReportComponentStorageViewModelBindingSource;
    }
}