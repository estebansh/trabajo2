using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Text;

public partial class login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Verificacion();
    }

    protected bool consulta(string v_usuario_ingresado, string clave_encriptada)
    {
        SqlConnection conexionsakila = new SqlConnection(ConfigurationManager.ConnectionStrings["sakilaConnectionString"].ToString());
        SqlCommand selecionar_user = new SqlCommand("select 1 from dbo.staff where username = @v_username and password = @v_password", conexionsakila);
        selecionar_user.Parameters.AddWithValue("@v_username", v_usuario_ingresado);
        selecionar_user.Parameters.AddWithValue("@v_password", clave_encriptada);

        try
        {
            conexionsakila.Open();
            SqlDataReader validacion = selecionar_user.ExecuteReader();
            validacion.Read();
            if (validacion.HasRows)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    protected void Verificacion()
    {
            string v_usuario_ingresado = (Request.Form["ctl00$ContentPlaceHolder1$txt_user"].ToString());
            string v_clave_ingresada = (Request.Form["ctl00$ContentPlaceHolder1$txt_password"].ToString());

            if (String.IsNullOrEmpty(v_usuario_ingresado) || String.IsNullOrEmpty(v_clave_ingresada))
            {
                lbl_resultado.Text = "LOS CAMPOS ESTAN VACIOS"; 
            }
            else
            {
                string clave_encriptada = encriptarSha1(v_clave_ingresada);
                Boolean existe_resultado = consulta(v_usuario_ingresado, clave_encriptada);
                try
                {
                    if (existe_resultado)
                    {
                        Response.Redirect("Pelicula/nomina_Pelicula.aspx");
                    }
                    else
                    {
                        lbl_resultado.Text = "USUARIO O PASSWORD INCORRECTOS";
                    }
                }
                catch (Exception ex)
                {
                    lbl_resultado.Text = "ERROR DE USUARIO" + ex.Message;
                }
            }
        }

    private string encriptarSha1(string v_clave_ingresada)
    {
        UTF8Encoding codificacionCaracteres = new UTF8Encoding();
        byte[] bytes_clave_ingresada = codificacionCaracteres.GetBytes(v_clave_ingresada);

        SHA1CryptoServiceProvider encriptarSHA1 = new SHA1CryptoServiceProvider();
        string clave_encriptada = BitConverter.ToString(encriptarSHA1.ComputeHash(bytes_clave_ingresada)).Replace("-", "");
        return clave_encriptada;
    }
    }