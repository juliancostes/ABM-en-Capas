using System;
using System.Drawing;
using System.Windows.Forms;
using CapaNegocio; // se deve instanciar la capa inferior luego de agregarla como referencia

namespace CapaVista
{
    public partial class frmPersonas : Form
    {
        //Instancio los objetos de las clses que utilizo en el form
        CN_Personas Pers = new CN_Personas();
        CV_Validar_Mail ValidaCorreo = new CV_Validar_Mail();

        public frmPersonas()
        {
            InitializeComponent();
        }

        private void frmPersonas_Load(object sender, EventArgs e)
        {
            LlenarCombo(cmbLocalidad, "Localidades", "Id_Loc", "Localidad");
            LlenarCombo(cmbProvincia, "Provincias", "Id_Provincia", "Provincia");
            LlenarCombo(cmbTipoDoc, "TipoDoc", "Id", "Tipo");
          
            //CV_Utiles.BloquearControles(this);  //recordar que no instancio el objeto de  la clase  porque el metodo es estatico
            CV_Botonera.btnFormularios(this, btnCancelar);
        }

 

        #region BOTONES

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                PasarDatos(false);

                Pers.InsertarPersona();

                CV_Botonera.btnFormularios(this, btnGuardaCambios);
                CV_Utiles.BloquearControles(this);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se guardaron los datos por: \n" + ex);
            }

            errorProvider1.Dispose();
            errorProvider2.Dispose();

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            CV_Utiles.DesbloquearControles(this);
            CV_Utiles.LimpiarControles(this);
            CV_Botonera.btnFormularios(this, btnAgregar);
            txtApellido.Select();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            CV_Botonera.btnFormularios(this, btnCancelar);
            CV_Utiles.BloquearControles(this);
            CV_Utiles.LimpiarControles(this);

            errorProvider1.Dispose();
            errorProvider2.Dispose();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            CV_Botonera.btnFormularios(this, btnModificar);
            CV_Utiles.DesbloquearControles(this);
            txtApellido.Select();
        }

        private void btnGuardaCambios_Click(object sender, EventArgs e)
        {
            try
            {
                PasarDatos(true);

                Pers.ModificarPersona();

                CV_Botonera.btnFormularios(this, btnGuardaCambios);
                CV_Utiles.BloquearControles(this);

            }
            catch (Exception ex)
            {
                MessageBox.Show("No se guardaron los datos por: \n" + ex);
            }
            errorProvider1.Dispose();
            errorProvider2.Dispose();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            var resultado = MessageBox.Show("esta seguro de ELIMINAR definitivamente \n" +
                                            " a la persona : " + txtApellido.Text + " " + txtNombres.Text  + "?",
                                                        "ELIMINAR PERSONA",
                                                        MessageBoxButtons.OKCancel,
                                                        MessageBoxIcon.Question);
            if (resultado == DialogResult.OK )
            {
                Pers.IdPersona = lblID.Text;
                Pers.EliminarPersona();
                CV_Utiles.LimpiarControles(this);
                lblID.Text = "0";
            }
            else
            {
                MessageBox.Show("Eliminacion Cancelada por el usuario","", MessageBoxButtons.OK , MessageBoxIcon.Stop );
            }
        }

        #endregion


        #region Validaciones_Nivel_Formulario

        private void txtApellido_Validated(object sender, EventArgs e)
        {
            if (this.txtApellido.Text.Length == 0)
            {
                errorProvider2.Dispose();
                errorProvider1.SetError(this.txtApellido, "Debe tener un valor");
            }
            else
            {
                errorProvider1.Dispose();
                errorProvider1.SetError(this.txtApellido, "");
                errorProvider2.SetError(this.txtApellido, "CORRECTO");
            }
        }

        private void txtNombres_Validated(object sender, EventArgs e)
        {
            if (this.txtNombres.Text.Length == 0)
            {
                errorProvider2.Dispose();
                errorProvider1.SetError(this.txtNombres, "El campo Nombre no puede tener un valor vacio");
            }
            else
            {
                errorProvider1.Dispose();
                errorProvider1.SetError(this.txtNombres, "");
                errorProvider2.SetError(this.txtNombres, "CORRECTO");
            }
        }

         private void txtCorreo_TextChanged(object sender, EventArgs e)
        {
            CV_Validar_Mail val = new CV_Validar_Mail();
            val.Correo = txtCorreo.Text;
            if (val.Valid() != true)
            {
                txtCorreo.ForeColor = Color.Red;
            }
            else
            {
                txtCorreo.ForeColor = Color.Black;
            }
        }
        #endregion

        #region METODOS

 
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
            CMB.SelectedIndex = -1;
        }

        private void PasarDatos(bool origen)
        {
            if (origen == true)
            { 
                Pers.IdPersona = lblID.Text;
            }
            else
            {
                Pers.IdPersona = "0";
            }
            Pers.Apellido = txtApellido.Text;
            Pers.Nombre = txtNombres.Text;
            if (cmbTipoDoc.SelectedItem == null)
            {
                Pers.TipoDoc = "0";
            }
            else
            {
                Pers.TipoDoc = cmbTipoDoc.SelectedValue.ToString();
            }
            Pers.NroDoc = txtNroDoc.Text;
            Pers.Telefono = txtTelefono.Text;
            Pers.Correo = txtCorreo.Text;
            Pers.Calle = txtCalle.Text;
            Pers.Nro = txtNro.Text;
            Pers.Piso = txtPiso.Text;
            Pers.Dto = txtDto.Text;
            if (cmbLocalidad.SelectedItem == null)
            {
                Pers.IdLocalidad = "0";
            }
            else
            {
                Pers.IdLocalidad = cmbLocalidad.SelectedValue.ToString();
            }
            if (cmbProvincia.SelectedItem == null)
            {
                Pers.IdProvincia = "0";
            }
            else
            {
                Pers.IdProvincia = cmbProvincia.SelectedValue.ToString();
            }
        }

        #endregion

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            frmBuscarPersona frmBuscar = new frmBuscarPersona();
            
            frmBuscar.PersonaPasada += new frmBuscarPersona.CargarPersona(Ejecutar);

            frmBuscar.ShowDialog();
        }

        public void Ejecutar(int ID, string apellido, string nombre, int idtipodoc,
            int nrodoc, string telefono, string correo, string calle, string numero, string piso,
            string dto, int idlocalidada, int idprovincia)
        {
            lblID.Text = ID.ToString();
            txtApellido.Text = apellido;
            txtNombres.Text = nombre;
            cmbTipoDoc.SelectedValue = idtipodoc;
            txtNroDoc.Text = nrodoc.ToString();
            txtTelefono.Text = telefono;
            txtCorreo.Text = correo;
            txtCalle.Text = calle;
            txtNro.Text = numero;
            txtPiso.Text = piso;
            txtDto.Text = dto;
            cmbLocalidad.SelectedValue = idlocalidada;
            cmbProvincia.SelectedValue = idprovincia;

        }

        private void grpPersonas_Enter(object sender, EventArgs e)
        {

        }
    }
}