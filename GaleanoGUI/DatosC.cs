using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Globalization;

namespace GaleanoDataAcess
{
    class DatosC : ConectionX
    {
        public string CODIGO_CLIENTE;
        private string NOMBRECOMPLETO;
        private int ZONA;
        private double MULTA;
        private double MORA;
        private double DONACION;
        private double TOTAL;
        private double CUOTA;
        private string CUENTABANCO;
        private DateTime FECHA;
        private string x;
        public string fecha2;

        public DatosC(string dato)
        {
            this.CODIGO_CLIENTE = dato;
            x = "WHERE CODIGO_CLIENTE = '" + CODIGO_CLIENTE + "'";
        }

        public string nombre()
        {
            string query = "SELECT NOMBRES + ' ' + APELLIDOS FROM USUARIOS AS NOMBRECOMPLETO " + x;

            using (SqlConnection conn = new SqlConnection(SQL))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read()) { IDataRecord data = reader; this.NOMBRECOMPLETO = Convert.ToString(data[0]); }
                    }
                }
            }

            return NOMBRECOMPLETO;
        }

        public string getZona()
        {
            string query = "SELECT ZONA FROM USUARIOS " + x;

            using (SqlConnection conn = new SqlConnection(SQL))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read()) 
                        { 
                            IDataRecord data = reader; 
                            this.ZONA = Convert.ToInt32(data[0]); 
                        }
                        reader.Close();
                    }
                }
            }

            switch (ZONA)
            {
                case 1: return "1 (Geleano)";
                case 2: return "2 (Salinas)";
                case 3: return "3 (Santa Marta)";
                case 4: return "4 (Cuatro Milpas)";
                
                default:
                    throw new Exception("Selección de zona inválida.");
            }
        }

        public double getMulta()
        {
            string query = "SELECT MULTA FROM PAGOS " + x;

            using (SqlConnection conn = new SqlConnection(SQL))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        { 
                            IDataRecord data = reader; 
                            this.MULTA = Convert.ToDouble(data[0]);
                        }
                        reader.Close();
                    }
                }
            }
            return MULTA;
        }

        public double getMora()
        {
            string query = "SELECT Mora FROM PAGOS " + x;

            using (SqlConnection conn = new SqlConnection(SQL))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {

                        while (reader.Read()) { IDataRecord data = reader; this.MORA = Convert.ToDouble(data[0]); }
                        reader.Close();                    
                    }
                }
            }
            return MORA;
        }

        public double getDonacion()
        {
            string query = "SELECT DONACION FROM PAGOS " + x;

            using (SqlConnection conn = new SqlConnection(SQL))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read()) 
                        { 
                            IDataRecord data = reader; 
                            this.DONACION = Convert.ToDouble(data[0]); 
                        }
                        reader.Close();
                    }
                }
  
            }
            return DONACION;
        }

        public double getCUOTA()
        {
            string query = "SELECT CUOTA FROM PAGOS " + x;
            
            using (SqlConnection conn = new SqlConnection(SQL))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            IDataRecord data = reader;
                            this.CUOTA = Convert.ToDouble(data[0]);
                        }
                        reader.Close();
                    }
                }
            }
            return CUOTA;
        }

        public double getTOTAL()
        {
            string query = "SELECT SUM(MULTA + MORA + DONACION + CUOTA) FROM PAGOS " + x;
            
            using (SqlConnection conn = new SqlConnection(SQL))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            IDataRecord data = reader;
                            object valueFromDatabase = data[0];// Obtener el valor de la base de datos

                            if (DBNull.Value.Equals(valueFromDatabase))
                            {
                                // El valor es DBNull, puedes asignar un valor por defecto o manejarlo de otra manera
                                // Por ejemplo:
                                double defaultValue = 0.00;
                                this.TOTAL = defaultValue;
                            }
                            else
                            {
                                // El valor no es DBNull, puedes realizar la conversión segura
                                this.TOTAL = Convert.ToDouble(valueFromDatabase);
                            }

                        }
                    }
                } 
            }
            return TOTAL;
        }

        public string GetBanco()
        {
            string query = "SELECT * FROM BANCO";
            using (SqlConnection conn = new SqlConnection(SQL))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read()) { IDataRecord data = reader; this.CUENTABANCO = Convert.ToString(data[0]); }
                        reader.Close();
                    }
                }
            }
            return CUENTABANCO;
        }

        public string GetFechaRegistro()
        {
            string fecha = "";
            string query = "SELECT FECHACORTE FROM DATOSCORTE WHERE CODIGO_CLIENTE = 1";

            using (SqlConnection conn = new SqlConnection(SQL))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            IDataRecord record = reader;
                            fecha = record[0].ToString();
                        }
                        reader.Close();
                    }
                }    
            }

            int mes = Convert.ToInt32(fecha[4].ToString());

            switch (mes)
            {
                case 1: return "Enero";
                case 2: return "Febrero";
                case 3: return "Marzo";
                case 4: return "Abril";
                case 5: return "Mayo";
                case 6: return "Junio";
                case 7: return "Julio";
                case 8: return "Agosto";
                case 9: return "Septiembre";
                case 10: return "Octubre";
                case 11: return "Noviembre";
                case 12: return "Diciembre";
                default: return "Error!";
            }
        }

        public int CrearReportePorCodigoCliente()
        {
            using (SqlConnection conn = new SqlConnection(SQL))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT FECHACORTE FROM DATOSCORTE WHERE CODIGO_CLIENTE = '1'", conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            IDataRecord data = reader;
                            this.FECHA = Convert.ToDateTime(data[0]);
                        }
                        reader.Close();

                        fecha2 = FECHA.ToString("yyyy-dd-MM");
                    }
                    //MessageBox.Show(fecha);
                }
            }

            using (SqlConnection conn = new SqlConnection(SQL))
            {
                conn.Open();
                string cuota = getCUOTA().ToString("0.00", CultureInfo.InvariantCulture);
                string mora = getMora().ToString("0.00", CultureInfo.InvariantCulture);
                string donacion = getDonacion().ToString("0.00", CultureInfo.InvariantCulture);
                string multa = getMulta().ToString("0.00", CultureInfo.InvariantCulture);

                string query = "INSERT INTO REPORTES(CODIGO_CLIENTE, FECHA_CREACION, CUOTA, MORA, DONACION, MULTA, HAPAGADO) VALUES(@CodigoCliente, @FechaCreacion, @Cuota, @Mora, @Donacion, @Multa, 'SI') SELECT SCOPE_IDENTITY();";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CodigoCliente", CODIGO_CLIENTE);
                    cmd.Parameters.AddWithValue("@FechaCreacion", fecha2);
                    cmd.Parameters.AddWithValue("@Cuota", cuota);
                    cmd.Parameters.AddWithValue("@Mora", mora);
                    cmd.Parameters.AddWithValue("@Donacion", donacion);
                    cmd.Parameters.AddWithValue("@Multa", multa);

                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        public string limiteFecha()
        {
            return FECHA.ToString("dd/MM/yyyy");
        }
    }
}
