namespace FurnitureShopView
{
    partial class FormReportStorages
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
            this.buttonSaveToExcelStorages = new System.Windows.Forms.Button();
            this.dataGridViewStorages = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStorages)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonSaveToExcelStorages
            // 
            this.buttonSaveToExcelStorages.Location = new System.Drawing.Point(25, 6);
            this.buttonSaveToExcelStorages.Name = "buttonSaveToExcelStorages";
            this.buttonSaveToExcelStorages.Size = new System.Drawing.Size(137, 23);
            this.buttonSaveToExcelStorages.TabIndex = 5;
            this.buttonSaveToExcelStorages.Text = "Сохранить в Excel";
            this.buttonSaveToExcelStorages.UseVisualStyleBackColor = true;
            this.buttonSaveToExcelStorages.Click += new System.EventHandler(this.buttonSaveToExcelStorages_Click);
            // 
            // dataGridViewStorages
            // 
            this.dataGridViewStorages.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewStorages.Location = new System.Drawing.Point(12, 35);
            this.dataGridViewStorages.Name = "dataGridViewStorages";
            this.dataGridViewStorages.Size = new System.Drawing.Size(514, 418);
            this.dataGridViewStorages.TabIndex = 4;
            // 
            // FormReportStorages
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 490);
            this.Controls.Add(this.buttonSaveToExcelStorages);
            this.Controls.Add(this.dataGridViewStorages);
            this.Name = "FormReportStorages";
            this.Text = "Компоненты по складам";
            this.Load += new System.EventHandler(this.FormReportStorages_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStorages)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonSaveToExcelStorages;
        private System.Windows.Forms.DataGridView dataGridViewStorages;
    }
}