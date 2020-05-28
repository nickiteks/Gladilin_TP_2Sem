namespace FurnitureShopView
{
    partial class FormStorageComonent
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
            this.comboBoxComponent = new System.Windows.Forms.ComboBox();
            this.textBoxCount = new System.Windows.Forms.TextBox();
            this.labelKol = new System.Windows.Forms.Label();
            this.labelCom = new System.Windows.Forms.Label();
            this.labelStor = new System.Windows.Forms.Label();
            this.comboBoxStor = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(210, 98);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 11;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(129, 98);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 10;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // comboBoxComponent
            // 
            this.comboBoxComponent.FormattingEnabled = true;
            this.comboBoxComponent.Location = new System.Drawing.Point(102, 36);
            this.comboBoxComponent.Name = "comboBoxComponent";
            this.comboBoxComponent.Size = new System.Drawing.Size(235, 21);
            this.comboBoxComponent.TabIndex = 9;
            // 
            // textBoxCount
            // 
            this.textBoxCount.Location = new System.Drawing.Point(101, 63);
            this.textBoxCount.Name = "textBoxCount";
            this.textBoxCount.Size = new System.Drawing.Size(236, 20);
            this.textBoxCount.TabIndex = 8;
            // 
            // labelKol
            // 
            this.labelKol.AutoSize = true;
            this.labelKol.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelKol.Location = new System.Drawing.Point(15, 67);
            this.labelKol.Name = "labelKol";
            this.labelKol.Size = new System.Drawing.Size(86, 17);
            this.labelKol.TabIndex = 7;
            this.labelKol.Text = "Количество";
            // 
            // labelCom
            // 
            this.labelCom.AutoSize = true;
            this.labelCom.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelCom.Location = new System.Drawing.Point(15, 36);
            this.labelCom.Name = "labelCom";
            this.labelCom.Size = new System.Drawing.Size(81, 17);
            this.labelCom.TabIndex = 6;
            this.labelCom.Text = "Компонент";
            // 
            // labelStor
            // 
            this.labelStor.AutoSize = true;
            this.labelStor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelStor.Location = new System.Drawing.Point(15, 9);
            this.labelStor.Name = "labelStor";
            this.labelStor.Size = new System.Drawing.Size(48, 17);
            this.labelStor.TabIndex = 12;
            this.labelStor.Text = "Склад";
            // 
            // comboBoxStor
            // 
            this.comboBoxStor.FormattingEnabled = true;
            this.comboBoxStor.Location = new System.Drawing.Point(102, 9);
            this.comboBoxStor.Name = "comboBoxStor";
            this.comboBoxStor.Size = new System.Drawing.Size(235, 21);
            this.comboBoxStor.TabIndex = 13;
            // 
            // FormStorageComonent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 139);
            this.Controls.Add(this.comboBoxStor);
            this.Controls.Add(this.labelStor);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.comboBoxComponent);
            this.Controls.Add(this.textBoxCount);
            this.Controls.Add(this.labelKol);
            this.Controls.Add(this.labelCom);
            this.Name = "FormStorageComonent";
            this.Text = "Добавить компонет на склад";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.ComboBox comboBoxComponent;
        private System.Windows.Forms.TextBox textBoxCount;
        private System.Windows.Forms.Label labelKol;
        private System.Windows.Forms.Label labelCom;
        private System.Windows.Forms.Label labelStor;
        private System.Windows.Forms.ComboBox comboBoxStor;
    }
}