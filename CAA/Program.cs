using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CAA.Models.DataBases;

namespace CAA
{
    static class Program
    {
        public static bdCAAEntities bd = new bdCAAEntities();

        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Properties.Settings.Default.mainStyle = new MetroFramework.Components.MetroStyleManager();
            Properties.Settings.Default.mainStyle.Style = MetroFramework.MetroColorStyle.Orange;
            Properties.Settings.Default.mainStyle.Theme = MetroFramework.MetroThemeStyle.Light;

            Application.Run(new frmCaTipoProductos());
        }
    }
}
