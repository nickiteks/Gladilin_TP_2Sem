namespace FurnirureShopView
{
    partial class FormImplementer
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
            this.workingTimeTextBox = new System.Windows.Forms.TextBox();
            this.fioTextBox = new System.Windows.Forms.TextBox();
            this.fioLabel = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.pauseTimeTextBox = new System.Windows.Forms.TextBox();
            this.pauseTimeLabel = new System.Windows.Forms.Label();
            this.workingTimeLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // workingTimeTextBox
            // 
            this.workingTimeTextBox.Location = new System.Drawing.Point(171, 49);
            this.workingTimeTextBox.Name = "workingTimeTextBox";
            this.workingTimeTextBox.Size = new System.Drawing.Size(241, 20);
            this.workingTimeTextBox.TabIndex = 22;
            // 
            // fioTextBox
            // 
            this.fioTextBox.Location = new System.Drawing.Point(171, 21);
            this.fioTextBox.Name = "fioTextBox";
            this.fioTextBox.Size = new System.Drawing.Size(241, 20);
            this.fioTextBox.TabIndex = 21;
            // 
            // fioLabel
            // 
            this.fioLabel.AutoSize = true;
            this.fioLabel.Location = new System.Drawing.Point(32, 28);
            this.fioLabel.Name = "fioLabel";
            this.fioLabel.Size = new System.Drawing.Size(37, 13);
            this.fioLabel.TabIndex = 20;
            this.fioLabel.Text = "ФИО:";
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(337, 105);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 19;
            this.cancelButton.Text = "Отмена";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(256, 105);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 18;
            this.saveButton.Text = "Сохранить";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // pauseTimeTextBox
            // 
            this.pauseTimeTextBox.Location = new System.Drawing.Point(171, 79);
            this.pauseTimeTextBox.Name = "pauseTimeTextBox";
            this.pauseTimeTextBox.Size = new System.Drawing.Size(241, 20);
            this.pauseTimeTextBox.TabIndex = 17;
            // 
            // pauseTimeLabel
            // 
            this.pauseTimeLabel.AutoSize = true;
            this.pauseTimeLabel.Location = new System.Drawing.Point(32, 79);
            this.pauseTimeLabel.Name = "pauseTimeLabel";
            this.pauseTimeLabel.Size = new System.Drawing.Size(91, 13);
            this.pauseTimeLabel.TabIndex = 16;
            this.pauseTimeLabel.Text = "Время на отдых:";
            // 
            // workingTimeLabel
            // 
            this.workingTimeLabel.AutoSize = true;
            this.workingTimeLabel.Location = new System.Drawing.Point(32, 52);
            this.workingTimeLabel.Name = "workingTimeLabel";
            this.workingTimeLabel.Size = new System.Drawing.Size(123, 13);
            this.workingTimeLabel.TabIndex = 15;
            this.workingTimeLabel.Text = "Время на выполнения:";
            // 
            // FormImpementer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 161);
            this.Controls.Add(this.workingTimeTextBox);
            this.Controls.Add(this.fioTextBox);
            this.Controls.Add(this.fioLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.pauseTimeTextBox);
            this.Controls.Add(this.pauseTimeLabel);
            this.Controls.Add(this.workingTimeLabel);
            this.Name = "FormImpementer";
            this.Text = "Работник";
            this.Load += new System.EventHandler(this.FormImpementer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox workingTimeTextBox;
        private System.Windows.Forms.TextBox fioTextBox;
        private System.Windows.Forms.Label fioLabel;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.TextBox pauseTimeTextBox;
        private System.Windows.Forms.Label pauseTimeLabel;
        private System.Windows.Forms.Label workingTimeLabel;
    }
}
