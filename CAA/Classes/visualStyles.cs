using MetroFramework.Components;
using MetroFramework.Forms;
using MetroFramework.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Classes
{
    public static class visualStyles
    {
        private static void iterControls(Control control, MetroStyleManager msmMain)
        {
            foreach (Control item in control.Controls)
            {
                iterControls(item, msmMain);
                if (item is IMetroControl)
                    ((IMetroControl)item).StyleManager = msmMain;
            }
        }

        /// <summary>
        /// Función para aplicar estilos visuales a los formularios y controles contenidos en él
        /// </summary>
        /// <param name="frm">Formulario</param>
        /// <param name="baseStyle">Manejador de estilo Base</param>
        /// <param name="msmMain">Manejador de estilo del formulario</param>
        public static void apply(Control frm, MetroStyleManager baseStyle, MetroStyleManager msmMain)
        {
            msmMain.Owner = (ContainerControl)frm;
            msmMain = baseStyle;
            try
            {
                ((MetroForm)frm).StyleManager = msmMain;
            }
            catch (Exception){}            
            visualStyles.iterControls(frm, msmMain);
        }

    }
}
