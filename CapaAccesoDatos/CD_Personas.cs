using System.Data;
using System.Data.OleDb;

namespace CapaAccesoDatos
{
    public class CD_Personas : CD_Conexion
    {
        //CD_Conexion conexion = new CD_Conexion();
        OleDbDataReader DR;
        DataTable DT = new DataTable();
        OleDbCommand comando = new OleDbCommand();

        #region ATRIBUTOS
        private string ayn;
        private int idpersona;
        private string apellido;
        private string nombre;
        private int tipodoc;
        private int nrodoc;
        private string telefono;
        private string correo;
        private string calle;
        private string nro;
        private string piso;
        private string dto;
        private int idlocalidad;
        private int idprovincia;
        #endregion

        #region PROPERTIES

        public string AyN
            {
                set { ayn = value; }
            }

        public int IdPersona
        {
            get => idpersona; //Expresion Lambda (Se suprime el Return y las llaves)
            set { idpersona = value; }
        }

        public string Apellido 
        {
            get => apellido; 
            set {apellido = value;}
        }

        public string Nombre
        {
            get => nombre;
            set {nombre = value;}
        }

        public int TipoDoc
        {
            get => tipodoc;
            set {tipodoc = value;}
        }

        public int NroDoc
        {
            get => nrodoc; 
            set {nrodoc = value;}
        }

        public string Telefono
        {
            get => telefono; 
            set {telefono = value;}
        }

        public string Correo
        {
            get => correo;
            set {correo = value;}
        }

        public string Calle
        {
            get => calle;
            set {calle = value;}
        }

        public string Nro
        {
            get => nro;
            set {nro = value;}
        }

        public string Piso
        {
            get => piso;
            set {piso = value;}
        }

        public string Dto
        {
            get => dto;
            set {dto = value;}
        }

        public int IdLocalidad
        {
            get => idlocalidad;
            set {idlocalidad = value;}
        }

        public int IdProvincia
        {
            get => idprovincia;
            set {idprovincia = value;}
        }
        #endregion

        #region METODOS

        public DataTable BuscarPersona()
        {
            
            string condicion = null;
            if ( !string.IsNullOrEmpty(ayn) )
            {
                condicion = " Personas.Apellido + Personas.Nombre Like '%" + ayn.Trim() + "%'";
            }
            else if (nrodoc != 0)
            {
                condicion = " TipoDoc = " + tipodoc + " and NroDoc =" + nrodoc;
            }

            //Armo la consulta SQL
            string sSql;
            if (condicion == null)
            {
                sSql = "Select * from Personas";


                //sSql = "SELECT Alumnos.Id_Alumno, Alumnos.Apellido, Alumnos.Nombres, Alumnos.tipo_Doc," +
                //    " TipoDoc.TipoDoc, Alumnos.Nro_Doc, Alumnos.CUIL, Alumnos.Id_Nacionalidad," +
                //    " Nacionalidades.Nacionalidad, Alumnos.Dir_Calle, Alumnos.Dir_Nro, Alumnos.Dir_Piso," +
                //    " Alumnos.Dir_Dto, Alumnos.Id_Localidad , TipoDoc.Id_TipoDoc, Nacionalidades.Id_Nacionalidad," +
                //    " Localidades.Id_Localidad , Localidades.Localidad, Localidades.CodPost, Localidades.Id_Partido," +
                //    " Partidos.Id_Partido , Partidos.Partido, Partidos.Id_Provincia , Provincias.Id_Provincia," +
                //    " Provincias.Provincia" +
                //    " FROM((Provincias INNER JOIN Partidos ON Provincias.[Id_Provincia] = Partidos.[Id_Provincia])" +
                //    " INNER JOIN Localidades ON Partidos.[Id_Partido] = Localidades.[Id_Partido])" +
                //    " INNER JOIN(TipoDoc INNER JOIN (Nacionalidades " +
                //    " INNER JOIN Alumnos ON Nacionalidades.[Id_Nacionalidad] = Alumnos.[Id_Nacionalidad]) " +
                //    " ON TipoDoc.[Id_TipoDoc] = Alumnos.[tipo_Doc]) " +
                //    " ON Localidades.[Id_Localidad] = Alumnos.[Id_Localidad]";
            }
            else
            {
                sSql = "Select * from Personas where " + condicion;

                //sSql = "SELECT Alumnos.Id_Alumno, Alumnos.Apellido, Alumnos.Nombres, Alumnos.tipo_Doc, TipoDoc.TipoDoc, " +
                //    " Alumnos.Nro_Doc, Alumnos.CUIL, Alumnos.Id_Nacionalidad, Nacionalidades.Nacionalidad," +
                //    " Alumnos.Dir_Calle, Alumnos.Dir_Nro, Alumnos.Dir_Piso, Alumnos.Dir_Dto, Alumnos.Id_Localidad," +
                //    " TipoDoc.Id_TipoDoc, Nacionalidades.Id_Nacionalidad , Localidades.Id_Localidad," +
                //    " Localidades.Localidad, Localidades.CodPost, Localidades.Id_Partido , Partidos.Id_Partido," +
                //    " Partidos.Partido, Partidos.Id_Provincia , Provincias.Id_Provincia , Provincias.Provincia" +
                //    " FROM((Provincias INNER JOIN Partidos ON Provincias.[Id_Provincia] = Partidos.[Id_Provincia])" +
                //    " INNER JOIN Localidades ON Partidos.[Id_Partido] = Localidades.[Id_Partido])" +
                //    " INNER JOIN(TipoDoc INNER JOIN (Nacionalidades" +
                //    " INNER JOIN Alumnos ON Nacionalidades.[Id_Nacionalidad] = Alumnos.[Id_Nacionalidad])" +
                //    " ON TipoDoc.[Id_TipoDoc] = Alumnos.[tipo_Doc])" +
                //    " ON Localidades.[Id_Localidad] = Alumnos.[Id_Localidad]" +
                //    " where " + Condicion;
            }

            //comando.Connection = conexion.AbrirConexion();
            //comando.CommandText = sSql;
            //DR = comando.ExecuteReader();

                DT.Clear();
                OleDbDataAdapter da = new OleDbDataAdapter(sSql, AbrirConexion());
                da.Fill(DT);
                CerrarConexion();
                return DT;
        }

        public DataTable Mostrar()
        {
            comando.Connection = AbrirConexion();
            comando.CommandText = "Select * from Personas ";
            DR = comando.ExecuteReader();
            DT.Load(DR);
            CerrarConexion();
            return DT;
        }

        public void InsertarPersona()
        {
            string sSql = "INSERT INTO Personas " +
               "(Apellido, Nombre, TipoDoc, NroDoc, Telefono, Correo, Calle, Nro, Piso, Dto, IdLocalidad, IdProvincia) " +
                "values" +
                " ('" + apellido + "','" + nombre + "'," + tipodoc + "," + nrodoc +
                ",'" +telefono + "','" + correo + "','" + calle + "','" + nro +
                "','" + piso + "','" + dto + "'," + idlocalidad+ ", " + idprovincia + ")";
            Ejecutar(sSql);
        }

        public void ModificarPersona()
        {
            string sSql = "UPDATE Personas set " +
                "Apellido='" + apellido + "', Nombre='" + nombre  + "', TipoDoc =" + tipodoc  +
                ", NroDoc = " + nrodoc  + ", Telefono = '" + telefono + "', Correo = '" + correo  +
                "', Calle = '" + calle + "', Nro = '" + nro + "', Piso = '" + piso + "', Dto = '" + dto +
                "', IdLocalidad = " + idlocalidad + ", IdProvincia = " + idprovincia  +
                " WHERE Id =" + idpersona;
            Ejecutar(sSql);
        }

        public void EliminarPersona()
        {
            string sSql = "DELETE FROM Personas WHERE Id =" + idpersona;
            Ejecutar(sSql);

        }

        private void Ejecutar(string sSQL)
        {
            OleDbCommand cmd = new OleDbCommand(sSQL, AbrirConexion());
            cmd.ExecuteNonQuery();
            CerrarConexion();
        }
        #endregion
    }
}
