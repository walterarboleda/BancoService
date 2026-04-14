using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using System.Data;

namespace BancoService
{
    [WebService(Namespace = "http://banco.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class BancoService : System.Web.Services.WebService
    {
        // Cadena de conexión a tu servidor local
        string connectionString = @"Server=DESKTOP-GJDFMRJ\SQLEXPRESS;Database=BANCO;Integrated Security=True";

        [WebMethod]
        public bool VerificarSaldoParaCompra(string numeroCuenta, string tipoCuenta, decimal montoCompra)
        {
            bool puedeComprar = false;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // Consulta para validar cuenta, tipo y si el saldo es suficiente
                string query = "SELECT Saldo FROM Cuenta WHERE NumeroCuenta = @num AND TipoCuenta = @tipo";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@num", numeroCuenta);
                cmd.Parameters.AddWithValue("@tipo", tipoCuenta);

                try
                {
                    conn.Open();
                    object resultado = cmd.ExecuteScalar();

                    if (resultado != null)
                    {
                        decimal saldoActual = Convert.ToDecimal(resultado);
                        // Verificamos si el saldo alcanza para la compra
                        if (saldoActual >= montoCompra)
                        {
                            puedeComprar = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Manejo de errores (opcional)
                    throw new Exception("Error en la consulta: " + ex.Message);
                }
            }

            return puedeComprar;
        }
    }
}   