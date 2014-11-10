using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Cliente_modificar_cliente : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int id = Convert.ToInt16(Request.QueryString["c"].ToString());
        SqlConnection recuperar_datos = new SqlConnection(ConfigurationManager.ConnectionStrings["sakilaConnectionString"].ToString());
        SqlCommand consulta_datos = new SqlCommand("select a.first_name,a.last_name,a.email,a.store_id,a.address_id from dbo.customer AS a where a.customer_id=@v_codigo", recuperar_datos);
        consulta_datos.Parameters.AddWithValue("@v_codigo", id);
        recuperar_datos.Open();

        try
        {

            SqlDataReader obtiene_datos = consulta_datos.ExecuteReader();
            obtiene_datos.Read();
            if (obtiene_datos.HasRows)
            {
                txt_nombre.Text = obtiene_datos.GetString(0).ToString();
                txt_apellido.Text = obtiene_datos.GetString(1).ToString();
                txt_correo.Text = obtiene_datos.GetString(2).ToString();
                ddl_tienda.SelectedIndex = Convert.ToInt16(obtiene_datos["store_id"].ToString()) - 1;
                ddl_direccion.SelectedIndex = Convert.ToInt16(obtiene_datos["address_id"].ToString()) - 1;
            }
            else
            {
                txt_nombre.Text = "sin datos";
                txt_apellido.Text = "sin datos";
                txt_correo.Text = "sin datos";
                ddl_direccion.SelectedValue = "sin datos";
            }
        }
        catch (Exception ex)
        {
            lbl_estado.Text = "Se ha producido un problema al obtener los datos. " + ex.Message;

        }
        recuperar_datos.Close();

    }
    protected void cmd_Cancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("nomina_cliente.aspx");
    }
    protected void cmd_actualizar_Click(object sender, EventArgs e)
    {
        Ingreso();
    }

    protected void Ingreso()
    {
        string nombre = (Request.Form["ctl00$ContentPlaceHolder1$txt_nombre"]);
        string apellido = (Request.Form["ctl00$ContentPlaceHolder1$txt_apellido"]);
        string correo = (Request.Form["ctl00$ContentPlaceHolder1$txt_correo"]);
        int direccion = Convert.ToInt32(Request.Form["ctl00$ContentPlaceHolder1$ddl_direccion"]);
        int tienda = Convert.ToInt32(Request.Form["ctl00$ContentPlaceHolder1$ddl_tienda"]);
        int id = Convert.ToInt16(Request.QueryString["c"].ToString());
        SqlConnection actualizar_cliente = new SqlConnection(ConfigurationManager.ConnectionStrings["sakilaConnectionString"].ToString());
        SqlCommand consulta_datos = new SqlCommand("update dbo.customer set first_name=@v_nombre, last_name = @v_apellido, email=@v_email, address_id=@v_direccion , store_id=@v_tienda where customer_id=@v_codigo", actualizar_cliente);
        consulta_datos.Parameters.AddWithValue("@v_codigo", id);
        consulta_datos.Parameters.AddWithValue("@v_nombre", nombre);
        consulta_datos.Parameters.AddWithValue("@v_apellido", apellido);
        consulta_datos.Parameters.AddWithValue("@v_direccion", direccion);
        consulta_datos.Parameters.AddWithValue("@v_tienda", tienda);
        consulta_datos.Parameters.AddWithValue("@v_email", correo);

        try
        {
            actualizar_cliente.Open();
            consulta_datos.ExecuteNonQuery();
            Response.Redirect("nomina_cliente.aspx");
        }
        catch (Exception ex)
        {

            lbl_estado.Text = "Error al agregar " + ex.Message;
        }
    }
}
    