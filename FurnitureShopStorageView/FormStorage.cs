using FurnitureShopBusinessLogic.BindingModels;
using FurnitureShopBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FurnitureShopStorageView
{
    public partial class FormStorage : Form
    {
        public int Id { set { id = value; } }

        private int? id;

        private Dictionary<string, int> storageComponents;

        public FormStorage()
        {
            InitializeComponent();
        }

        private void FormCar_Load(object sender, EventArgs e)
        {
            dataGridView.Columns.Add("Id", "Id");
            dataGridView.Columns.Add("Компонент", "Компонент");
            dataGridView.Columns.Add("Количество", "Количество");
            dataGridView.Columns[0].Visible = false;
            dataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            if (id.HasValue)
            {
                try
                {
                    StorageViewModel view = APIClient.GetRequest<StorageViewModel>($"api/storage/getstorage?storageId={id.Value}");
                    if (view != null)
                    {
                        storageNameTextBox.Text = view.StorageName;
                        storageComponents = view.StoragedComponents;
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                storageComponents = new Dictionary<string, int>();
            }
        }

        private void LoadData()
        {
            try
            {
                if (storageComponents != null)
                {
                    dataGridView.Rows.Clear();
                    foreach (var storageComponent in storageComponents)
                    {
                        dataGridView.Rows.Add(new object[] { storageComponent.Key, storageComponent.Key, storageComponent.Value });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(storageNameTextBox.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                APIClient.PostRequest<StorageBindingModel>("api/storage/createorupdatestorage", new StorageBindingModel
                {
                    Id = id,
                    StorageName = storageNameTextBox.Text
                });
                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cancleButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
