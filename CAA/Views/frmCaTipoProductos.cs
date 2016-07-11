using CAA.Models;
using CAA.Models.DataBases;
using Classes;
using DAL;
using DevExpress.XtraEditors;
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
    public partial class frmCaTipoProductos : MetroForm
    {
        private DAL<bdCAAEntities, caTiposProductos, caTiposProductos> dal = new DAL<bdCAAEntities, caTiposProductos, caTiposProductos>();
        private caTiposProductos newReg;

        private frmStatus frm;
        private frmStatus Frm { 
            get{ 
                return frm; 
            }
            set{
            frm = value;

            btnAdd.Visible = value == frmStatus.Normal;
            btnEdit.Visible = value == frmStatus.Normal && BindingSource.Current != null;
            btnDelete.Visible = value == frmStatus.Normal && BindingSource.Current != null;
            btnClean.Visible = value == frmStatus.Add || value == frmStatus.Edit;
            btnSave.Visible = value == frmStatus.Add || value == frmStatus.Edit;
            btnCancel.Visible = value == frmStatus.Add || value == frmStatus.Edit;

            panel1.Enabled = value != frmStatus.Normal;
            splitContainer1.Panel2.Enabled = value == frmStatus.Normal;

            if (frm.Equals(frmStatus.Add) || frm.Equals(frmStatus.Edit)) 
                tipoProductoTextBox.Focus();
        } 
        }

        public frmCaTipoProductos()
        {
            InitializeComponent();
            this.init();
        }

        private void init()
        {
            visualStyles.apply(this, Properties.Settings.Default.mainStyle, msmMain);
            
            this.populate();

            Frm = frmStatus.Normal;
        }

        private void populate()
        {
            List<caTiposProductos> regs = dal.Get(qry => qry.isActive.Equals(true)).ToList();
            BindingSource.DataSource = regs;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Frm = frmStatus.Add;
            newReg = BindingSource.AddNew() as caTiposProductos;
            newReg.isActive = true;
            isActiveCheckEdit.Checked = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Confirme la cancelación", "Cancelar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (Frm.Equals(frmStatus.Add))
                    BindingSource.CancelEdit();
                else
                {
                    dal.discardChanges<caTiposProductos>(BindingSource.Current as caTiposProductos);
                    BindingSource.ResetCurrentItem();
                }
                Frm = frmStatus.Normal;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Frm = frmStatus.Edit;
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            BindingSource.CancelEdit();
            btnAdd_Click(null, null);            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Frm = frmStatus.Delete;
            try
            {
                if (MessageBox.Show(this, "Confirme la eliminación", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    dal.DeleteFromEntity((caTiposProductos)BindingSource.Current);
                    dal.Save();

                    Frm = frmStatus.Deleted;

                    populate();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Frm = frmStatus.Normal;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            #region FORM VALIDATIONS

            foreach (Control x in panel1.Controls)
            {
                if (x is TextBox)
                    if (((TextBox)x).Tag != null)
                        if (((TextBox)x).Tag.Equals(1) && string.IsNullOrEmpty(((TextBox)x).Text.Trim()) ) {
                            MessageBox.Show(this, "Falta información", "Formulario incompleto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            ((TextBox)x).Focus();
                            return;
                        }
            }

            #endregion FORM VALIDATIONS

            try
            {
                string principalValue = tipoProductoTextBox.Text.Trim();
                switch (Frm)
                {
                    case frmStatus.Add:
                        if (dal.Get(qry => qry.TipoProducto.Equals(principalValue)).Count() > 0)
                            throw new DataException("La información introducida ya se encuentra registrada, favor de revisar.");

                        dal.InsertFromEntity(newReg);
                        Frm = frmStatus.Added;
                        break;
                    case frmStatus.Edit:
                        dal.Update((caTiposProductos)BindingSource.Current);
                        Frm = frmStatus.Edited;
                        break;
                }
                dal.Save();
                Frm = frmStatus.Normal;
                MessageBox.Show(this, "Registro guardado con éxito", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (DataException dtaex) {
                MessageBox.Show(this, dtaex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                //TODO: Implementar NLOG
                MessageBox.Show(this, "Error al intentar guardar el registro", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            populate();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {

        }

    }
}
