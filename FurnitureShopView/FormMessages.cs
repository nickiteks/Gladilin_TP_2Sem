﻿using FurnitureShopBusinessLogic.Interfaces;
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
    public partial class FormMessages : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly IMessageInfoLogic messageLogic;
        public FormMessages(IMessageInfoLogic messageInfo)
        {
            InitializeComponent();
            this.messageLogic = messageInfo;
        }

        private void FormMessages_Load(object sender, EventArgs e)
        {
            try
            {
                Program.ConfigGrid(messageLogic.Read(null), dataGridView);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
