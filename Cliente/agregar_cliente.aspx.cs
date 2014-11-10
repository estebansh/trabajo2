using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Cliente_agregar_cliente : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void cmd_Cancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("nomina_cliente.aspx");
    }
    protected void cmd_Agregar_Click(object sender, EventArgs e)
    {
        SqlConnection conexionSakila = new SqlConnection(ConfigurationManager.ConnectionStrings["sakilaConnectionString"].ToString());
        SqlCommand inserta_cliente = new SqlCommand("insert into dbo.customer(first_name,last_name,email,store_id,address_id) values(@v_nombre,@v_apellido,@v_email,@v_tienda,@v_direccion)", conexionSakila);
        inserta_cliente.Parameters.AddWithValue("@v_nombre", txt_nombre.Text);
        inserta_cliente.Parameters.AddWithValue("@v_apellido", txt_apellido.Text);
        inserta_cliente.Parameters.AddWithValue("@v_direccion", ddl_direccion.SelectedValue);
        inserta_cliente.Parameters.AddWithValue("@v_tienda", ddl_tienda.SelectedValue);
        inserta_cliente.Parameters.AddWithValue("@v_email", txt_correo.Text);

        try
        {
            conexionSakila.Open();
            inserta_cliente.ExecuteNonQuery();
            Response.Redirect("nomina_cliente.aspx");
        }
        catch (Exception ex)
        {

            lbl_estado.Text = "Error al agregar " + ex.Message;
        }
    }
}