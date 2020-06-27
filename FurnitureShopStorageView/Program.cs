using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FurnitureShopStorageView
{
    static class Program
    {
        public static bool isLogged = false;
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            APIClient.Connect();
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var formEnter = new FormEnter();
            formEnter.ShowDialog();

            if (isLogged)
            {
                Application.Run(new FormStorages());
            }
        }
    }
}
