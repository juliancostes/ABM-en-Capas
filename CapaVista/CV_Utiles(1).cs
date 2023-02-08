using System.Windows.Forms;

namespace CapaVista
{
    class CV_Utiles
    {
        public static void BloquearControles(Form FRM)
        {
            foreach (Control c in FRM.Controls)
            {
                if (c is TextBox)
                {
                    ((TextBox)c).Enabled = false;
                }
                if (c is ComboBox)
                {
                    ((ComboBox)c).Enabled = false;
                }
                if (c is GroupBox | c is Panel)
                {
                    BC2(c);
                }
            }
        }

        private static void BC2(Control x)
        {
            foreach (Control h in x.Controls)
            {
                if (h is TextBox)
                {
                    ((TextBox)h).Enabled = false;
                }
                if (h is ComboBox)
                {
                    ((ComboBox)h).Enabled = false;
                }
            }
        }


        public static void DesbloquearControles(Form FRM)
        {
            foreach (Control c in FRM.Controls)
            {
                if (c is TextBox)
                {
                    ((TextBox)c).Enabled = true;
                }
                if (c is ComboBox)
                {
                    ((ComboBox)c).Enabled = true;
                }
                if (c is GroupBox | c is Panel)
                {
                    DC2(c);
                }
            }
        }

        private static void DC2(Control x)
        {
            foreach (Control h in x.Controls)
            {
                if (h is TextBox)
                {
                    ((TextBox)h).Enabled = true;
                }
                if (h is ComboBox)
                {
                    ((ComboBox)h).Enabled = true;
                }
            }
        }

        public static void LimpiarControles(Form FRM)
        {
            foreach (Control c in FRM.Controls)
            {
                if (c is TextBox)
                {
                    ((TextBox)c).Text = null;
                }
                if (c is ComboBox)
                {
                    ((ComboBox)c).Text = null;
                }
                if (c is GroupBox | c is Panel)
                {
                    LC2(c);
                }
            }
        }

        private static void LC2(Control x)
        {
            foreach (Control h in x.Controls)
            {
                if (h is TextBox)
                {
                    ((TextBox)h).Text = null;
                }
                if (h is ComboBox)
                {
                    ((ComboBox)h).Text = null;
                }
            }
        }

    }
}
