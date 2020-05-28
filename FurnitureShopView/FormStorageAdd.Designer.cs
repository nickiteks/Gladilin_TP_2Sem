namespace FurnitureShopView
{
    partial class FormStorageAdd
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
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.textBoxNameStorage = new System.Windows.Forms.TextBox();
            this.labelNameStorage = new System.Windows.Forms.Label();
            this.dataGridViewComponents = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewComponents)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(334, 285);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(72, 24);
            this.buttonCancel.TabIndex = 18;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(256, 285);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(72, 24);
            this.buttonSave.TabIndex = 17;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // textBoxNameStorage
            // 
            this.textBoxNameStorage.Location = new System.Drawing.Point(97, 28);
            this.textBoxNameStorage.Name = "textBoxNameStorage";
            this.textBoxNameStorage.Size = new System.Drawing.Size(173, 20);
            this.textBoxNameStorage.TabIndex = 15;
            // 
            // labelNameStorage
            // 
            this.labelNameStorage.AutoSize = true;
            this.labelNameStorage.Location = new System.Drawing.Point(31, 31);
            this.labelNameStorage.Name = "labelNameStorage";
            this.labelNameStorage.Size = new System.Drawing.Size(60, 13);
            this.labelNameStorage.TabIndex = 14;
            this.labelNameStorage.Text = "Название:";
            // 
            // dataGridViewComponents
            // 
            this.dataGridViewComponents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewComponents.Location = new System.Drawing.Point(32, 83);
            this.dataGridViewComponents.Name = "dataGridViewComponents";
            this.dataGridViewComponents.Size = new System.Drawing.Size(374, 196);
            this.dataGridViewComponents.TabIndex = 0;
            // 
            // FormStorageAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 391);
            this.Controls.Add(this.dataGridViewComponents);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.textBoxNameStorage);
            this.Controls.Add(this.labelNameStorage);
            this.Name = "FormStorageAdd";
            this.Text = "Склад";
            this.Load += new System.EventHandler(this.FormStorageAdd_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewComponents)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.TextBox textBoxNameStorage;
        private System.Windows.Forms.Label labelNameStorage;
        private System.Windows.Forms.DataGridView dataGridViewComponents;
    }
}