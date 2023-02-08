using System;
using System.Windows.Forms;

namespace CapaVista 
{
    // Esta clase desactiva y oculta o activa y muestra los botones de un formulario
    // dependiendo del nombre del boton presionado por el usuario
    class CV_Botonera
    {

        public static void btnFormularios(Form fAux, Button btn)
        {
            string nombre = btn.Name;
            switch (nombre)
            {
                case "btnAgregar":
                    foreach (Control c in fAux.Controls)
                    {
                        if (c is GroupBox | c is Panel)
                        {
                            foreach (Object x in c.Controls)
                            {
                                if (x is Button)
                                {
                                    if (((Button)x).Name == "btnAgregar")
                                    {
                                        ((Button)x).Enabled = false;
                                        ((Button)x).Visible = false;
                                    }
                                    if (((Button)x).Name == "btnGuardar")
                                    {
                                        ((Button)x).Enabled = true;
                                        ((Button)x).Visible = true;
                                    }
                                    if (((Button)x).Name == "btnModificar")
                                    {
                                        ((Button)x).Enabled = false;
                                        ((Button)x).Visible = false;
                                    }
                                    if (((Button)x).Name == "btnGuardaCambios")
                                    {
                                        ((Button)x).Enabled = false;
                                        ((Button)x).Visible = false;
                                    }
                                    if (((Button)x).Name == "btnCancelar")
                                    {
                                        ((Button)x).Enabled = true;
                                        ((Button)x).Visible = true;
                                    }
                                    if (((Button)x).Name == "btnEliminar")
                                    {
                                        ((Button)x).Enabled = false;
                                        ((Button)x).Visible = false;
                                    }
                                }
                            }
                        }
                    }
                    break;
                case "btnGuardar":
                    foreach (Control c in fAux.Controls)
                    {
                        if (c is GroupBox | c is Panel)
                        {
                            foreach (object x in c.Controls)
                            {
                                if (x is Button)
                                {
                                    if (((Button)x).Name == "btnAgregar")
                                    {
                                        ((Button)x).Enabled = true;
                                        ((Button)x).Visible = true;
                                    }
                                    if (((Button)x).Name == "btnGuardar")
                                    {
                                        ((Button)x).Enabled = false;
                                        ((Button)x).Visible = false;
                                    }
                                    if (((Button)x).Name == "btnModificar")
                                    {
                                        ((Button)x).Enabled = true;
                                        ((Button)x).Visible = true;
                                    }
                                    if (((Button)x).Name == "btnGuardaCambios")
                                    {
                                        ((Button)x).Enabled = false;
                                        ((Button)x).Visible = false;
                                    }
                                    if (((Button)x).Name == "btnCancelar")
                                    {
                                        ((Button)x).Enabled = false;
                                        ((Button)x).Visible = false;
                                    }
                                    if (((Button)x).Name == "btnEliminar")
                                    {
                                        ((Button)x).Enabled = true;
                                        ((Button)x).Visible = true;
                                    }
                                }
                            }
                        }
                    }
                    break;
                case "btnModificar":
                    foreach (Control c in fAux.Controls)
                    {
                        if (c is GroupBox | c is Panel)
                        {
                            foreach (object x in c.Controls)
                            {
                                if (x is Button)
                                {
                                    if (((Button)x).Name == "btnAgregar")
                                    {
                                        ((Button)x).Enabled = false;
                                        ((Button)x).Visible = false;
                                    }
                                    if (((Button)x).Name == "btnGuardar")
                                    {
                                        ((Button)x).Enabled = false;
                                        ((Button)x).Visible = false;
                                    }
                                    if (((Button)x).Name == "btnModificar")
                                    {
                                        ((Button)x).Enabled = false;
                                        ((Button)x).Visible = false;
                                    }
                                    if (((Button)x).Name == "btnGuardaCambios")
                                    {
                                        ((Button)x).Enabled = true;
                                        ((Button)x).Visible = true;
                                    }
                                    if (((Button)x).Name == "btnCancelar")
                                    {
                                        ((Button)x).Enabled = true;
                                        ((Button)x).Visible = true;
                                    }
                                    if (((Button)x).Name == "btnEliminar")
                                    {
                                        ((Button)x).Enabled = false;
                                        ((Button)x).Visible = false;
                                    }
                                }
                            }
                        }
                    }
                    break;
                case "btnGuardaCambios":
                    foreach (Control c in fAux.Controls)
                    {
                        if (c is GroupBox | c is Panel)
                        {
                            foreach (object x in c.Controls)
                            {
                                if (x is Button)
                                {
                                    if (((Button)x).Name == "btnAgregar")
                                    {
                                        ((Button)x).Enabled = true;
                                        ((Button)x).Visible = true;
                                    }
                                    if (((Button)x).Name == "btnGuardar")
                                    {
                                        ((Button)x).Enabled = false;
                                        ((Button)x).Visible = false;
                                    }
                                    if (((Button)x).Name == "btnModificar")
                                    {
                                        ((Button)x).Enabled = true;
                                        ((Button)x).Visible = true;
                                    }
                                    if (((Button)x).Name == "btnGuardaCambios")
                                    {
                                        ((Button)x).Enabled = false;
                                        ((Button)x).Visible = false;
                                    }
                                    if (((Button)x).Name == "btnCancelar")
                                    {
                                        ((Button)x).Enabled = false;
                                        ((Button)x).Visible = false;
                                    }
                                    if (((Button)x).Name == "btnEliminar")
                                    {
                                        ((Button)x).Enabled = true;
                                        ((Button)x).Visible = true;
                                    }
                                }
                            }
                        }
                    }
                    break;
                case "btnEliminar":
                    foreach (Control c in fAux.Controls)
                    {
                        if (c is GroupBox | c is Panel)
                        {
                            foreach (object x in c.Controls)
                            {

                            }
                        }
                    }
                    break;
                case "btnCancelar":
                    foreach (Control c in fAux.Controls)
                    {
                        if (c is GroupBox | c is Panel)
                        {
                            foreach (object x in c.Controls)
                            {
                                if (x is Button)
                                {
                                    if (((Button)x).Name == "btnAgregar")
                                    {
                                        ((Button)x).Enabled = true;
                                        ((Button)x).Visible = true;
                                    }
                                    if (((Button)x).Name == "btnGuardar")
                                    {
                                        ((Button)x).Enabled = false;
                                        ((Button)x).Visible = false;
                                    }
                                    if (((Button)x).Name == "btnModificar")
                                    {
                                        ((Button)x).Enabled = true;
                                        ((Button)x).Visible = true;
                                    }
                                    if (((Button)x).Name == "btnGuardaCambios")
                                    {
                                        ((Button)x).Enabled = false;
                                        ((Button)x).Visible = false;
                                    }
                                    if (((Button)x).Name == "btnCancelar")
                                    {
                                        ((Button)x).Enabled = false;
                                        ((Button)x).Visible = false;
                                    }
                                    if (((Button)x).Name == "btnEliminar")
                                    {
                                        ((Button)x).Enabled = true;
                                        ((Button)x).Visible = true;
                                    }
                                }
                            }
                        }
                    }
                    break;
            }
        }
    }
}
