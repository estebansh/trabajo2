using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Cliente_eliminar_cliente : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var idCliente = Request.QueryString["c"].ToString();
        lbl_estado.Text = idCliente;
    }
    protected void cmd_Cancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("nomina_cliente.aspx");
    }
    protected void cmd_Eliminar_Click(object sender, EventArgs e)
    {
        SqlConnection conexionInacap = new SqlConnection(ConfigurationManager.ConnectionStrings["sakilaConnectionString"].ToString());
        SqlCommand elimina_carrera = new SqlCommand("delete from dbo.customer where customer_id=@v_idcliente", conexionInacap);
        elimina_carrera.Parameters.AddWithValue("@v_idcliente", lbl_estado.Text);

        try
        {
            conexionInacap.Open();
            elimina_carrera.ExecuteNonQuery();
            Response.Redirect("nomina_cliente.aspx");
        }
        catch (Exception ex)
        {

            lbl_estado.Text = "NO PUEDE ELIMARSE PORQUE EXISTEN REGISTROS ASIGNADOS A ESTE CLIENTE";
        }
    }
}