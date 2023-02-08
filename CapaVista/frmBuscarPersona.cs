using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaVista
{
    public partial class frmBuscarPersona : Form
    {

        public delegate void CargarPersona(int ID, string apellido, string nombre, int idtipodoc, 
            int nrodoc, string telefono, string correo, string calle, string numero, string piso,
            string dto, int idlocalidada, int idprovincia);
        public event CargarPersona PersonaPasada;

        public frmBuscarPersona()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Pasar();
            this.Dispose();
        }

        private void frmBuscarPersona_Load(object sender, EventArgs e)
        {


            LlenarCombo(cmbTipoDoc, "TipoDoc", "Id", "Tipo");

            //Acomodo el dataGridView a mi necesidad
            dgvResultado.SelectionMode = DataGridViewSelectionMode.FullRowSelect; //Selecciona toda la fila
            dgvResultado.ReadOnly = true; //hace que la grilla no se pueda editar
            dgvResultado.MultiSelect = false; //desactiva la seleccion multiple
            dgvResultado.AllowUserToAddRows = false; //desactiva  la ultima fila 
            txtApellido.Select();

        }

        private void LlenarCombo(ComboBox CMB, string NombreTabla, string CampoID, string CampoDescrip, string Condicion = "")
        {
            CN_LlenarCombos LC = new CN_LlenarCombos();

            LC.NomTabla = NombreTabla;
            LC.CampoId = CampoID;
            LC.CampoDescrip = CampoDescrip;
            LC.Condicion = Condicion;

            CMB.DataSource = LC.Cargar();

            CMB.DisplayMember = CampoDescrip;
            CMB.ValueMember = CampoID;
        }


        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                CN_Personas Pers = new CN_Personas();
                Pers.AyN = txtApellido.Text + " " + txtNombre.Text;
                dgvResultado.DataSource = Pers.BuscarPersona();
            }
        }

        private void txtNro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                CN_Personas Pers = new CN_Personas();
                Pers.TipoDoc = cmbTipoDoc.SelectedValue.ToString();
                Pers.NroDoc = txtNro.Text;
                dgvResultado.DataSource = Pers.BuscarPersona();
            }
        }

        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                CN_Personas Pers = new CN_Personas();
                Pers.AyN = txtApellido.Text + " " + txtNombre.Text ;
                dgvResultado.DataSource = Pers.BuscarPersona();
            }
        }

        private void Pasar()
        {
            PersonaPasada(
            Convert.ToInt32(dgvResultado.Rows[dgvResultado.SelectedRows[0].Index].Cells["Id"].Value.ToString()),
            dgvResultado.Rows[dgvResultado.SelectedRows[0].Index].Cells["Apellido"].Value.ToString(),
            dgvResultado.Rows[dgvResultado.SelectedRows[0].Index].Cells["Nombre"].Value.ToString(),
            Convert.ToInt32(dgvResultado.Rows[dgvResultado.SelectedRows[0].Index].Cells["TipoDoc"].Value.ToString()),
            Convert.ToInt32(dgvResultado.Rows[dgvResultado.SelectedRows[0].Index].Cells["NroDoc"].Value.ToString()),
            dgvResultado.Rows[dgvResultado.SelectedRows[0].Index].Cells["Telefono"].Value.ToString(),
            dgvResultado.Rows[dgvResultado.SelectedRows[0].Index].Cells["Correo"].Value.ToString(),
            dgvResultado.Rows[dgvResultado.SelectedRows[0].Index].Cells["Calle"].Value.ToString(),
            dgvResultado.Rows[dgvResultado.SelectedRows[0].Index].Cells["Nro"].Value.ToString(),
            dgvResultado.Rows[dgvResultado.SelectedRows[0].Index].Cells["Piso"].Value.ToString(),
            dgvResultado.Rows[dgvResultado.SelectedRows[0].Index].Cells["Dto"].Value.ToString(),
            Convert.ToInt32(dgvResultado.Rows[dgvResultado.SelectedRows[0].Index].Cells["IdLocalidad"].Value.ToString()),
            Convert.ToInt32(dgvResultado.Rows[dgvResultado.SelectedRows[0].Index].Cells["IdProvincia"].Value.ToString())
            );
        }

        private void dgvResultado_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Pasar();
            this.Dispose();
        }
    }
}
