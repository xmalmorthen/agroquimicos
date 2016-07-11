using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Controls;
using Classes;

namespace CAA.Views.UserControls
{
    public partial class ucMenu : MetroUserControl
    {
        public ucMenu()
        {
            InitializeComponent();
            this.init();
        }

        private void init()
        {
            visualStyles.apply(this, Properties.Settings.Default.mainStyle, msmMain);
        }
    }
}
