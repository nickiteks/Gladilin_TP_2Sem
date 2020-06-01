using FurnitureShopBusinessLogic;
using FurnitureShopBusinessLogic.BusnessLogics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace FurnitureShopView
{
    public partial class FormReportStorages : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly ReportLogic logic;
        public FormReportStorages(ReportLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
            dataGridViewStorages.Columns.Add("Склад", "Склад");
            dataGridViewStorages.Columns.Add("Компонент", "Компонент");
            dataGridViewStorages.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewStorages.Columns.Add("Количество", "Количество");
        }

        private void buttonSaveToExcelStorages_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog { Filter = "xlsx|*.xlsx" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        logic.SaveStoragesToExcelFile(new ReportBindingModel
                        {
                            FileName = dialog.FileName
                        });
                        MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void FormReportStorages_Load(object sender, EventArgs e)
        {
            try
            {
                var dict = logic.GetStorages();
                if (dict != null)
                {
                    dataGridViewStorages.Rows.Clear();
                    foreach (var storage in dict)
                    {
                        dataGridViewStorages.Rows.Add(storage.StorageName, "", "");
                        int totalCount = 0;
                        foreach (var mat in storage.Components)
                        {
                            dataGridViewStorages.Rows.Add("", mat.Key, mat.Value);
                            totalCount += mat.Value;
                        }
                        dataGridViewStorages.Rows.Add("Всего", "", totalCount);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
