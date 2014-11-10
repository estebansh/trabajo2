using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class eliminar_Pelicula : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var idPelicula = Request.QueryString["c"].ToString();
        lbl_estado.Text = idPelicula;
    }
    protected void cmd_Cancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("nomina_Pelicula.aspx");
    }
    protected void cmd_Eliminar_Click(object sender, EventArgs e)
    {
        SqlConnection conexionInacap = new SqlConnection(ConfigurationManager.ConnectionStrings["sakilaConnectionString"].ToString());
        SqlCommand elimina_carrera = new SqlCommand("delete from dbo.film where film_id=@v_idfilm", conexionInacap);
        elimina_carrera.Parameters.AddWithValue("@v_idfilm", lbl_estado.Text);

        try
        {
            conexionInacap.Open();
            elimina_carrera.ExecuteNonQuery();
            Response.Redirect("nomina_Pelicula.aspx");
        }
        catch (Exception ex)
        {

            lbl_estado.Text = "NO SE PUEDE ELIMINAR PORQUE EXISTEN REGISTROS ASIGNADOS A ESTA PELICULA ";
        }
    }
}