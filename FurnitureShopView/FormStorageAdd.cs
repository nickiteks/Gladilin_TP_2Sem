using FurnitureShopBusinessLogic.BindingModels;
using FurnitureShopBusinessLogic.Interfaces;
using FurnitureShopBusinessLogic.ViewModels;
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
    public partial class FormStorageAdd : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        public int Id { set { id = value; } }
        private readonly IStorageLogic logic;
        private int? id;
        private Dictionary<string, int> StorageCmponents;
        public FormStorageAdd(IStorageLogic service)
        {
            InitializeComponent();
            dataGridViewComponents.Columns.Add("Id", "Id");
            dataGridViewComponents.Columns.Add("ComponentName", "Компонент");
            dataGridViewComponents.Columns.Add("Count", "Количество");
            dataGridViewComponents.Columns[0].Visible = false;
            dataGridViewComponents.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.logic = service;
        }

        private void FormStorageAdd_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    StorageViewModel view = logic.Read(new StorageBindingModel { Id = id.Value })[0];
                    if (view != null)
                    {
                        textBoxNameStorage.Text = view.StorageName;
                        StorageCmponents = view.StoragedComponents;
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
                StorageCmponents = new Dictionary<string, int>();
            }
        }
        private void LoadData()
        {
            try
            {
                if (StorageCmponents != null)
                {
                    dataGridViewComponents.Rows.Clear();
                    foreach (var pc in StorageCmponents)
                    {
                        dataGridViewComponents.Rows.Add(new object[] {"", pc.Key, pc.Value});
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxNameStorage.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                logic.CreateOrUpdate(new StorageBindingModel
                {
                    Id = id ?? null,
                    StorageName = textBoxNameStorage.Text,
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

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
