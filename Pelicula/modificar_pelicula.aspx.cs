using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pelicula_modificar_pelicula : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int id = Convert.ToInt16(Request.QueryString["c"].ToString());
        SqlConnection recuperar_datos = new SqlConnection(ConfigurationManager.ConnectionStrings["sakilaConnectionString"].ToString());
        SqlCommand consulta_datos = new SqlCommand("select a.title,a.description,a.release_year,a.length,a.replacement_cost,a.rental_rate,a.rental_duration,a.rating,a.language_id,a.special_features from dbo.film AS a where a.film_id=@v_codigo", recuperar_datos);
        consulta_datos.Parameters.AddWithValue("@v_codigo", id);
        recuperar_datos.Open();

        try
        {

            SqlDataReader obtiene_datos = consulta_datos.ExecuteReader();
            obtiene_datos.Read();
            if (obtiene_datos.HasRows)
            {
                txt_nombre.Text = obtiene_datos.GetString(0).ToString();
                txt_descripcion.Text = obtiene_datos.GetString(1).ToString();
                txt_año.Text = obtiene_datos.GetString(2).ToString();
                int duracion =  Convert.ToInt16(obtiene_datos["length"]);
                txt_duracion.Text = "" + duracion;
                int costo = Convert.ToInt16(obtiene_datos["replacement_cost"]);
                txt_costo.Text = "" + costo;
                int rating = Convert.ToInt16 (obtiene_datos["rental_rate"]);
                txt_rating.Text = "" + rating;
                int duracionRenta = Convert.ToInt16(obtiene_datos["rental_duration"]);
                txt_renta.Text = "" + duracionRenta;
                ddl_clasificacion.SelectedValue = obtiene_datos.GetString(7).ToString();
                ddl_idioma.SelectedIndex =Convert.ToInt16(obtiene_datos["language_id"].ToString()) -1;
                string caracteristicas = obtiene_datos["special_features"].ToString();
                string[] matriz_caracteristicas = caracteristicas.Split(',');
                foreach (string s in matriz_caracteristicas)
                {
                    foreach (ListItem item in cbl_especial.Items)
                    {
                        if (item.Value.Equals(s))
                        {
                            item.Selected = true;
                        }
                    }
                }
            }
            else
            {
                txt_nombre.Text = "sin datos";
                txt_descripcion.Text = "sin datos";
                txt_año.Text = "0";
                txt_duracion.Text = "0";
                txt_costo.Text = "0";
                txt_rating.Text = "0";
                txt_renta.Text = "0";
                ddl_idioma.SelectedValue = "sin datos";
                ddl_clasificacion.SelectedValue = "sin datos";
            }
        }
        catch (Exception ex)
        {
            lbl_estado.Text = "Se ha producido un problema al obtener los datos. " + ex.Message;

        }
        recuperar_datos.Close();

    }
    protected void cmd_Agregar_Click(object sender, EventArgs e)
    {

        string nombre = Request.Form["ctl00$ContentPlaceHolder1$txt_nombre"].ToString();
        string descripcion = Request.Form["ctl00$ContentPlaceHolder1$txt_descripcion"].ToString();
        int año = Convert.ToInt32(Request.Form["ctl00$ContentPlaceHolder1$txt_año"]);
        int idioma = Convert.ToInt32(Request.Form["ctl00$ContentPlaceHolder1$ddl_idioma"]);
        int renta = Convert.ToInt32(Request.Form["ctl00$ContentPlaceHolder1$txt_renta"]);
        int rating = Convert.ToInt32(Request.Form["ctl00$ContentPlaceHolder1$txt_rating"]);
        int duracion = Convert.ToInt32(Request.Form["ctl00$ContentPlaceHolder1$txt_duracion"]);
        int costo = Convert.ToInt32(Request.Form["ctl00$ContentPlaceHolder1$txt_costo"]);
        string clasificacion = Request.Form["ctl00$ContentPlaceHolder1$ddl_clasificacion"].ToString();
            List<string> contenido = new List<string>();
            foreach (ListItem item in cbl_especial.Items)
            {
                if (item.Selected)
                {
                    contenido.Add(item.Text);
                }
            }
            string caracteristicas = string.Join(",", contenido.ToArray());
            int id = Convert.ToInt16(Request.QueryString["c"].ToString());
            SqlConnection actualizar_pelicula = new SqlConnection(ConfigurationManager.ConnectionStrings["sakilaConnectionString"].ToString());
            SqlCommand inserta_pelicula = new SqlCommand("update dbo.film SET title=@v_nombre,description=@v_descripcion,release_year=@v_año,language_id=@v_idioma,rental_duration=@v_renta,rental_rate=@v_rating,length=@v_duracion,replacement_cost=@v_costo,rating=@v_clasificacion,special_features=@v_especial where film_id=@v_id", actualizar_pelicula);
            inserta_pelicula.Parameters.AddWithValue("@v_id", id);
            inserta_pelicula.Parameters.AddWithValue("@v_nombre", nombre);
            inserta_pelicula.Parameters.AddWithValue("@v_descripcion", descripcion);
            inserta_pelicula.Parameters.AddWithValue("@v_año", año);
            inserta_pelicula.Parameters.AddWithValue("@v_idioma", idioma);
            inserta_pelicula.Parameters.AddWithValue("@v_renta", renta);
            inserta_pelicula.Parameters.AddWithValue("@v_rating", rating);
            inserta_pelicula.Parameters.AddWithValue("@v_duracion", duracion);
            inserta_pelicula.Parameters.AddWithValue("@v_costo", costo);
            inserta_pelicula.Parameters.AddWithValue("@v_clasificacion", clasificacion);
            inserta_pelicula.Parameters.AddWithValue("@v_especial", caracteristicas);

            try
            {
                actualizar_pelicula.Open();
                inserta_pelicula.ExecuteNonQuery();
                Response.Redirect("nomina_pelicula.aspx");
            }
            catch (Exception ex)
            {
                lbl_estado.Text = "ERROR AL AGREGAR" + ex.Message;
            }
        }
    protected void cmd_Cancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("nomina_pelicula.aspx");
    }
}