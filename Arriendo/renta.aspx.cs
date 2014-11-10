using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class renta : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int id_film = Convert.ToInt32(Request.Form["ctl00$ContentPlaceHolder1$ddl_pelicula"]);
        int id_store = Convert.ToInt32(Request.Form["ctl00$ContentPlaceHolder1$ddl_tienda"]);
        SqlConnection recuperar_datos = new SqlConnection(ConfigurationManager.ConnectionStrings["sakilaConnectionString"].ToString());
        SqlCommand consulta_datos = new SqlCommand("SELECT TOP 1 inventory_id FROM dbo.inventory where store_id=@v_tienda and film_id=@v_film ORDER BY NEWID();", recuperar_datos);
        consulta_datos.Parameters.AddWithValue("@v_film", id_film);
        consulta_datos.Parameters.AddWithValue("@v_tienda", id_store);
        recuperar_datos.Open();

        try
        {

            SqlDataReader obtiene_datos = consulta_datos.ExecuteReader();
            obtiene_datos.Read();
            var id_inventory = obtiene_datos["inventory_id"].ToString();
            hdn_idinventory.Value = id_inventory;
        }
        catch (Exception ex)
        {
            lbl_estado.Text = "Se ha producido un problema al obtener los datos. " + ex.Message;

        }
        recuperar_datos.Close();
    }
    protected void txt_cancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("/Pelicula/nomina_Pelicula.aspx");
    }
}