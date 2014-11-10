using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pelicula_agregar_pelicula : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void cmd_Cancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("nomina_Pelicula.aspx");
    }
    protected void cmd_Agregar_Click(object sender, EventArgs e)
    {

        List<string> resultado = new List<string>();
        foreach (ListItem item in cbl_especial.Items)
        {
            if (item.Selected)
            {
                resultado.Add(item.Text);
            }
        }
        string caracteristicas = string.Join(",", resultado.ToArray());

        SqlConnection conexionSakila = new SqlConnection(ConfigurationManager.ConnectionStrings["sakilaConnectionString"].ToString());
        SqlCommand inserta_pelicula = new SqlCommand("insert into dbo.film (title,description,release_year,language_id,rental_duration,rental_rate,length,replacement_cost,rating,special_features) values(@v_nombre,@v_descripcion,@v_año,@v_idioma,@v_renta,@v_rating,@v_duracion,@v_costo,@v_clasificacion,@v_especial)", conexionSakila);
        inserta_pelicula.Parameters.AddWithValue("@v_nombre", txt_nombre.Text);
        inserta_pelicula.Parameters.AddWithValue("@v_descripcion", txt_descripcion.Text);
        inserta_pelicula.Parameters.AddWithValue("@v_año", txt_año.Text);
        inserta_pelicula.Parameters.AddWithValue("@v_idioma", ddl_idioma.SelectedValue);
        inserta_pelicula.Parameters.AddWithValue("@v_renta",Convert.ToInt32(txt_renta.Text));
        inserta_pelicula.Parameters.AddWithValue("@v_rating", Convert.ToDecimal(txt_rating.Text));
        inserta_pelicula.Parameters.AddWithValue("@v_duracion", Convert.ToInt32(txt_duracion.Text));
        inserta_pelicula.Parameters.AddWithValue("@v_costo", Convert.ToInt32(txt_costo.Text));
        inserta_pelicula.Parameters.AddWithValue("@v_clasificacion", ddl_clasificacion.SelectedValue);
        inserta_pelicula.Parameters.AddWithValue("@v_especial", caracteristicas);

        try
        {
            conexionSakila.Open();
            inserta_pelicula.ExecuteNonQuery();
            Response.Redirect("nomina_pelicula.aspx");
        }
        catch (Exception ex)
        {

            lbl_estado.Text = "Error al agregar " + ex.Message;
        }
    }
}