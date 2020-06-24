namespace FurnitureShopView
{
    partial class FormMain
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
            this.buttonCreateOrder = new System.Windows.Forms.Button();
            this.buttonTakeOrderInWork = new System.Windows.Forms.Button();
            this.buttonOrderReady = new System.Windows.Forms.Button();
            this.buttonPayOrder = new System.Windows.Forms.Button();
            this.buttonRef = new System.Windows.Forms.Button();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.справочникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.компонентыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.списокИзделийToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.складыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьНаСкладToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчетыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.мебельToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.заказыПоМебелиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.компонентыПоМебелиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.компонентыПоМебелиToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.компонентыНаСкладахToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.складыToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.buttonStorageAdd = new System.Windows.Forms.Button();
            this.запускРаботToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.исполнителиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonCreateOrder
            // 
            this.buttonCreateOrder.Location = new System.Drawing.Point(772, 61);
            this.buttonCreateOrder.Name = "buttonCreateOrder";
            this.buttonCreateOrder.Size = new System.Drawing.Size(206, 25);
            this.buttonCreateOrder.TabIndex = 0;
            this.buttonCreateOrder.Text = "Создать заказ";
            this.buttonCreateOrder.UseVisualStyleBackColor = true;
            this.buttonCreateOrder.Click += new System.EventHandler(this.buttonCreateOrder_Click);
            // 
            // buttonTakeOrderInWork
            // 
            this.buttonTakeOrderInWork.Location = new System.Drawing.Point(772, 92);
            this.buttonTakeOrderInWork.Name = "buttonTakeOrderInWork";
            this.buttonTakeOrderInWork.Size = new System.Drawing.Size(206, 25);
            this.buttonTakeOrderInWork.TabIndex = 1;
            this.buttonTakeOrderInWork.Text = "Отдать на выполнение";
            this.buttonTakeOrderInWork.UseVisualStyleBackColor = true;
            this.buttonTakeOrderInWork.Click += new System.EventHandler(this.buttonTakeOrderInWork_Click);
            // 
            // buttonOrderReady
            // 
            this.buttonOrderReady.Location = new System.Drawing.Point(772, 123);
            this.buttonOrderReady.Name = "buttonOrderReady";
            this.buttonOrderReady.Size = new System.Drawing.Size(206, 25);
            this.buttonOrderReady.TabIndex = 2;
            this.buttonOrderReady.Text = "Заказ готов";
            this.buttonOrderReady.UseVisualStyleBackColor = true;
            this.buttonOrderReady.Click += new System.EventHandler(this.buttonOrderReady_Click);
            // 
            // buttonPayOrder
            // 
            this.buttonPayOrder.Location = new System.Drawing.Point(772, 154);
            this.buttonPayOrder.Name = "buttonPayOrder";
            this.buttonPayOrder.Size = new System.Drawing.Size(206, 25);
            this.buttonPayOrder.TabIndex = 3;
            this.buttonPayOrder.Text = "Заказ оплачен";
            this.buttonPayOrder.UseVisualStyleBackColor = true;
            this.buttonPayOrder.Click += new System.EventHandler(this.buttonPayOrder_Click);
            // 
            // buttonRef
            // 
            this.buttonRef.Location = new System.Drawing.Point(772, 185);
            this.buttonRef.Name = "buttonRef";
            this.buttonRef.Size = new System.Drawing.Size(206, 25);
            this.buttonRef.TabIndex = 4;
            this.buttonRef.Text = "Обновить список";
            this.buttonRef.UseVisualStyleBackColor = true;
            this.buttonRef.Click += new System.EventHandler(this.buttonRef_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.справочникиToolStripMenuItem,
            this.добавитьНаСкладToolStripMenuItem,
            this.отчетыToolStripMenuItem,
            this.запускРаботToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1004, 24);
            this.menuStrip.TabIndex = 5;
            this.menuStrip.Text = "menuStrip1";
            // 
            // справочникиToolStripMenuItem
            // 
            this.справочникиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.компонентыToolStripMenuItem,
            this.списокИзделийToolStripMenuItem,
            this.складыToolStripMenuItem,
            this.исполнителиToolStripMenuItem});
            this.справочникиToolStripMenuItem.Name = "справочникиToolStripMenuItem";
            this.справочникиToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.справочникиToolStripMenuItem.Text = "Справочники";
            // 
            // компонентыToolStripMenuItem
            // 
            this.компонентыToolStripMenuItem.Name = "компонентыToolStripMenuItem";
            this.компонентыToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.компонентыToolStripMenuItem.Text = "Компоненты";
            this.компонентыToolStripMenuItem.Click += new System.EventHandler(this.компонентыToolStripMenuItem_Click);
            // 
            // списокИзделийToolStripMenuItem
            // 
            this.списокИзделийToolStripMenuItem.Name = "списокИзделийToolStripMenuItem";
            this.списокИзделийToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.списокИзделийToolStripMenuItem.Text = "Список изделий";
            this.списокИзделийToolStripMenuItem.Click += new System.EventHandler(this.списокИзделийToolStripMenuItem_Click);
            // 
            // складыToolStripMenuItem
            // 
            this.складыToolStripMenuItem.Name = "складыToolStripMenuItem";
            this.складыToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.складыToolStripMenuItem.Text = "Склады";
            this.складыToolStripMenuItem.Click += new System.EventHandler(this.СкладыToolStripMenuItem_Click);
            // 
            // добавитьНаСкладToolStripMenuItem
            // 
            this.добавитьНаСкладToolStripMenuItem.Name = "добавитьНаСкладToolStripMenuItem";
            this.добавитьНаСкладToolStripMenuItem.Size = new System.Drawing.Size(121, 20);
            this.добавитьНаСкладToolStripMenuItem.Text = "Добавить на склад";
            this.добавитьНаСкладToolStripMenuItem.Click += new System.EventHandler(this.добавитьНаСкладToolStripMenuItem_Click);
            // 
            // отчетыToolStripMenuItem
            // 
            this.отчетыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.мебельToolStripMenuItem,
            this.заказыПоМебелиToolStripMenuItem,
            this.компонентыПоМебелиToolStripMenuItem,
            this.компонентыПоМебелиToolStripMenuItem1,
            this.компонентыНаСкладахToolStripMenuItem,
            this.складыToolStripMenuItem1});
            this.отчетыToolStripMenuItem.Name = "отчетыToolStripMenuItem";
            this.отчетыToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.отчетыToolStripMenuItem.Text = "Отчеты";
            // 
            // мебельToolStripMenuItem
            // 
            this.мебельToolStripMenuItem.Name = "мебельToolStripMenuItem";
            this.мебельToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.мебельToolStripMenuItem.Text = "Мебель";
            this.мебельToolStripMenuItem.Click += new System.EventHandler(this.мебельToolStripMenuItem_Click);
            // 
            // заказыПоМебелиToolStripMenuItem
            // 
            this.заказыПоМебелиToolStripMenuItem.Name = "заказыПоМебелиToolStripMenuItem";
            this.заказыПоМебелиToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.заказыПоМебелиToolStripMenuItem.Text = "Заказы по мебели";
            this.заказыПоМебелиToolStripMenuItem.Click += new System.EventHandler(this.заказыПоМебелиToolStripMenuItem_Click);
            // 
            // компонентыПоМебелиToolStripMenuItem
            // 
            this.компонентыПоМебелиToolStripMenuItem.Name = "компонентыПоМебелиToolStripMenuItem";
            this.компонентыПоМебелиToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.компонентыПоМебелиToolStripMenuItem.Text = "Компоненты по мебели";
            this.компонентыПоМебелиToolStripMenuItem.Click += new System.EventHandler(this.компонентыПоМебелиToolStripMenuItem_Click);
            // 
            // компонентыПоМебелиToolStripMenuItem1
            // 
            this.компонентыПоМебелиToolStripMenuItem1.Name = "компонентыПоМебелиToolStripMenuItem1";
            this.компонентыПоМебелиToolStripMenuItem1.Size = new System.Drawing.Size(211, 22);
            this.компонентыПоМебелиToolStripMenuItem1.Text = "Компоненты по складам";
            this.компонентыПоМебелиToolStripMenuItem1.Click += new System.EventHandler(this.компонентыПоСкладамToolStripMenuItem_Click);
            // 
            // компонентыНаСкладахToolStripMenuItem
            // 
            this.компонентыНаСкладахToolStripMenuItem.Name = "компонентыНаСкладахToolStripMenuItem";
            this.компонентыНаСкладахToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.компонентыНаСкладахToolStripMenuItem.Text = "Компоненты на складах";
            this.компонентыНаСкладахToolStripMenuItem.Click += new System.EventHandler(this.компонентыНаСкладахToolStripMenuItem_Click);
            // 
            // складыToolStripMenuItem1
            // 
            this.складыToolStripMenuItem1.Name = "складыToolStripMenuItem1";
            this.складыToolStripMenuItem1.Size = new System.Drawing.Size(211, 22);
            this.складыToolStripMenuItem1.Text = "Склады";
            this.складыToolStripMenuItem1.Click += new System.EventHandler(this.складыToolStripMenuItem1_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(12, 29);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(754, 397);
            this.dataGridView.TabIndex = 6;
            // 
            // buttonStorageAdd
            // 
            this.buttonStorageAdd.Location = new System.Drawing.Point(772, 216);
            this.buttonStorageAdd.Name = "buttonStorageAdd";
            this.buttonStorageAdd.Size = new System.Drawing.Size(206, 24);
            this.buttonStorageAdd.TabIndex = 7;
            this.buttonStorageAdd.Text = "Добавить на склад";
            this.buttonStorageAdd.UseVisualStyleBackColor = true;
            this.buttonStorageAdd.Click += new System.EventHandler(this.ButtonStorageAdd_Click);
            // 
            // запускРаботToolStripMenuItem
            // 
            this.запускРаботToolStripMenuItem.Name = "запускРаботToolStripMenuItem";
            this.запускРаботToolStripMenuItem.Size = new System.Drawing.Size(92, 20);
            this.запускРаботToolStripMenuItem.Text = "Запуск работ";
            this.запускРаботToolStripMenuItem.Click += new System.EventHandler(this.запускРаботToolStripMenuItem_Click);
            // 
            // исполнителиToolStripMenuItem
            // 
            this.исполнителиToolStripMenuItem.Name = "исполнителиToolStripMenuItem";
            this.исполнителиToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.исполнителиToolStripMenuItem.Text = "Исполнители";
            this.исполнителиToolStripMenuItem.Click += new System.EventHandler(this.исполнителиToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 449);
            this.Controls.Add(this.buttonStorageAdd);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.buttonRef);
            this.Controls.Add(this.buttonPayOrder);
            this.Controls.Add(this.buttonOrderReady);
            this.Controls.Add(this.buttonTakeOrderInWork);
            this.Controls.Add(this.buttonCreateOrder);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "FormMain";
            this.Text = "Магазин мебели";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCreateOrder;
        private System.Windows.Forms.Button buttonTakeOrderInWork;
        private System.Windows.Forms.Button buttonOrderReady;
        private System.Windows.Forms.Button buttonPayOrder;
        private System.Windows.Forms.Button buttonRef;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem справочникиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem компонентыToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.ToolStripMenuItem списокИзделийToolStripMenuItem;
        private System.Windows.Forms.Button buttonStorageAdd;
        private System.Windows.Forms.ToolStripMenuItem складыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem добавитьНаСкладToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отчетыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem мебельToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem заказыПоМебелиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem компонентыПоМебелиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem компонентыПоМебелиToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem компонентыНаСкладахToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem складыToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem запускРаботToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem исполнителиToolStripMenuItem;
    }
}