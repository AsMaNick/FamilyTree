using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Family_Tree
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MainPage mainPage = new MainPage();
            if (mainPage.DialogResult == DialogResult.OK)
            {
                return;
            }
            Application.Run(mainPage);
        }
    }
}
