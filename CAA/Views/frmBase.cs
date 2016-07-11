using Classes;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CAA
{
    public partial class frmBase : MetroForm
    {
        public frmBase()
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
