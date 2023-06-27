using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GaleanoDataAcess
{
    internal class ConectionX
    {
        SqlConnection sql = new SqlConnection(@"server=LAPTOP-6C5T7I88\SQLEXPRESS; database=PROYECTO_GALEANO; integrated security=true");
        public string SQL = @"server=LAPTOP-6C5T7I88\SQLEXPRESS; database=PROYECTO_GALEANO; integrated security=true";
        public string fecha;
        public int Usuarios;
        public string numeroDeZona;
        private List<int> codigos;

        public ConectionX() {
            try
            {
                sql.Open();
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message, "!!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public DataTable MostrarDatos()
        {
            using (SqlDataAdapter adapter = new SqlDataAdapter("SP_GRID", sql))
            {
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        public void registroINSERT(string codigo, string nombre, string apellido, string zona, double cuota, double mora, double donacion)
        {
            string query = String.Format("INSERT INTO USUARIOS VALUES('{0}', '{1}', '{2}', '{3}') \nINSERT INTO PAGOS (CODIGO_CLIENTE, CUOTA, MORA, DONACION) VALUES('{4}', {5}, {6}, {7}) \nINSERT INTO DATOSCORTE (CODIGO_CLIENTE, HAPAGADO, FUERASISTEMA) VALUES ('{8}', 'NO', 'NO') ", codigo, nombre, apellido, zona, codigo, cuota, mora, donacion, codigo);
            int i = 0;
            var x = MessageBox.Show(query, "!!!!!!", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            
            if(x == DialogResult.OK)
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand(@query, sql))
                    {
                        cmd.CommandType = System.Data.CommandType.Text;
                        i = cmd.ExecuteNonQuery();
                        if (i != 0)
                        {
                            MessageBox.Show("SUCESSFULL!!.", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("No se ha podido realizar el registro.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception a)
                {
                    MessageBox.Show(a.Message, "Warning!!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }


        }
        public void eliminar(string codigo)
        {
            string eliminar = "DELETE FROM USUARIOS WHERE CODIGO_CLIENTE = @CODIGO_CLIENTE"
              + " DELETE FROM PAGOS WHERE CODIGO_CLIENTE = @CODIGO_CLIENTE"
              + " DELETE FROM DATOSCORTE WHERE CODIGO_CLIENTE = @CODIGO_CLIENTE";
            
            using (SqlCommand cmd3 = new SqlCommand(@eliminar, sql))
            {
                cmd3.Parameters.AddWithValue("@CODIGO_CLIENTE", codigo);
                cmd3.ExecuteNonQuery();
            }
            MessageBox.Show("Los datos fueron eliminados con exito");
        }

        public void marcarComoInactivo(string codigo)
        {
            string query = "UPDATE DATOSCORTE SET FUERASISTEMA = 'SI' WHERE CODIGO_CLIENTE = @CODIGO_CLIENTE";

            using (SqlCommand cmd3 = new SqlCommand(query, sql))
            {
                cmd3.Parameters.AddWithValue("@CODIGO_CLIENTE", codigo);
                cmd3.ExecuteNonQuery();
            }
        }

        public DataTable llenarGridInactivos()
        {
            using (SqlDataAdapter adapter = new SqlDataAdapter("SP_GRIDINACTIVOS", sql))
            {
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        public void marcarActivo(string codigo)
        {

            string actualizar = "UPDATE DATOSCORTE SET CODIGO_CLIENTE=@CODIGO_CLIENTE, FUERASISTEMA=@FUERASISTEMA WHERE CODIGO_CLIENTE=@CODIGO_CLIENTE";

            SqlCommand sistema = new SqlCommand(actualizar, sql);
            sistema.Parameters.AddWithValue("@CODIGO_CLIENTE", codigo);
            sistema.Parameters.AddWithValue("@FUERASISTEMA", "NO");



            sistema.ExecuteNonQuery();
            MessageBox.Show("Los datos fueron actualizados con exito");
        }

        public DataTable NoPagados()
        {
            SqlDataAdapter adapter = new SqlDataAdapter("SP_NOPAGADOS", sql);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }
        public void MarcarComoPagado(string codigo)
        {
            string actualizar = "UPDATE DATOSCORTE SET CODIGO_CLIENTE = @CODIGO_CLIENTE, HAPAGADO=@HAPAGADO WHERE CODIGO_CLIENTE=@CODIGO_CLIENTE";
            SqlCommand cmd2 = new SqlCommand(actualizar, sql);
            cmd2.Parameters.AddWithValue("@CODIGO_CLIENTE", codigo);
            cmd2.Parameters.AddWithValue("@HAPAGADO", "SI");

            cmd2.ExecuteNonQuery();
        }

        public void MarcarComoNoPagado(string codigo)
        {
            string actualizar = "UPDATE DATOSCORTE SET CODIGO_CLIENTE = @CODIGO_CLIENTE, HAPAGADO=@HAPAGADO WHERE CODIGO_CLIENTE=@CODIGO_CLIENTE";
            SqlCommand cmd2 = new SqlCommand(actualizar, sql);
            cmd2.Parameters.AddWithValue("@CODIGO_CLIENTE", codigo);
            cmd2.Parameters.AddWithValue("@HAPAGADO", "NO");

            cmd2.ExecuteNonQuery();
        }
        public DataTable TablaUsuariosDeReportes()
        {
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM USUARIOS ORDER BY CAST(CODIGO_CLIENTE AS INT) ASC;", sql);
            adapter.SelectCommand.CommandType = CommandType.Text;
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }

        public DataTable Pagados()
        {
            string query = "SELECT U.CODIGO_CLIENTE, U.NOMBRES, U.APELLIDOS, U.ZONA, P.HAPAGADO\n" +
            "FROM USUARIOS U JOIN DATOSCORTE P\n" +
            "ON U.CODIGO_CLIENTE = P.CODIGO_CLIENTE\n" +
            "WHERE HAPAGADO = 'SI' ORDER BY CAST(P.CODIGO_CLIENTE AS INT) ASC;" ;
            SqlDataAdapter adapter = new SqlDataAdapter(query, sql);
            adapter.SelectCommand.CommandType = CommandType.Text;
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }

        public void guardarFecha(string fecha)
        {
            try
            {
                MessageBox.Show("Hoy la nueva fecha de corte será " + fecha);
                SqlCommand cmd = new SqlCommand("UPDATE DATOSCORTE SET FECHACORTE = '" + fecha + "'", sql);
                cmd.ExecuteNonQuery();
            }
            catch(Exception a)
            {
                MessageBox.Show(a.Message);
            }
        }
        public void GetFecha()
        {
            string ins = @"SELECT FECHACORTE FROM DATOSCORTE WHERE CODIGO_CLIENTE = 1";
           
            using (SqlConnection conn = new SqlConnection(SQL))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(@ins, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            leerFecha((IDataRecord)reader);
                        }
                        reader.Close();
                    }

                }
            }
        }
        private void leerFecha(IDataRecord data)
        {
            this.fecha = Convert.ToString(data[0]);
        }
        private void CantUsuarios(IDataRecord data)
        {
            this.Usuarios = Convert.ToInt32(data[0]);
        }

        public void ModificacionesPorFechaDeCorte()
        {
            /// VERIFICAR SI A PAGADO
            string ins = @"SELECT COUNT(*) FROM USUARIOS";
            using (SqlConnection conn = new SqlConnection(SQL))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(@ins, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CantUsuarios((IDataRecord)reader);
                        }
                        reader.Close();
                    }
                }
            }

            using (SqlConnection conn = new SqlConnection(SQL))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT CODIGO_CLIENTE ,HAPAGADO FROM DATOSCORTE", conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        int columnas = reader.FieldCount;
                        int rows = Usuarios;

                        string[,] matrix = new string[rows, columnas];

                        int rowIndex = 0;
                        while (reader.Read())
                        {
                            for (int i = 0; i < columnas; i++)
                            {
                                if (rowIndex < rows && i < columnas)
                                {
                                    matrix[rowIndex, i] = reader[i].ToString();
                                }
                            }
                            rowIndex++;
                        }

                        int rowCount = matrix.GetLength(0);
                        //int columnCount = matrix.GetLength(1);

                        for (int i = 0; i < rowCount; i++)
                        {
                            if (matrix[i, 1] == "NO")
                            {
                                //AGREGAR LA BARRA DE CARGAR Y CAMBIAR LOS VALORES A LA CONSTANTE REAL 
                                using (SqlCommand command = new SqlCommand("UPDATE PAGOS SET MORA = CUOTA FROM PAGOS JOIN DATOSCORTE ON PAGOS.CODIGO_CLIENTE = DATOSCORTE.CODIGO_CLIENTE WHERE DATOSCORTE.HAPAGADO = 'NO' AND DATOSCORTE.CODIGO_CLIENTE = '" + Convert.ToString(matrix[i, 0]) + "'", sql))
                                {
                                    command.ExecuteNonQuery();
                                }
                            }

                        }
                        reader.Close();
                    }
                }
            }
        }

        public List<int> CodigosLista()
        {
            using (SqlConnection conn = new SqlConnection(SQL))
            {
                conn.Open();
                string query = "SELECT * FROM USUARIOS ORDER BY CAST(CODIGO_CLIENTE AS INT) ASC;";
                
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        codigos = new List<int>();
                        while (reader.Read())
                        {
                            codigos.Add(Convert.ToInt32(reader["CODIGO_CLIENTE"]));
                        }
                        reader.Close();
                    }
                }
            }
            return codigos;
        }

    }
}
